using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bắt buộc phải có Token mới gọi được các API trong Controller này
    public class OrdersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public OrdersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. CHECKOUT: Thanh toán giỏ hàng tại quầy POS (POST /api/orders/checkout)
        // Chỉ Admin và Cashier (Thu ngân) mới được phép thanh toán
        [HttpPost("checkout")]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest request)
        {
            if (request.Items == null || request.Items.Count == 0)
            {
                return BadRequest(new { message = "Giỏ hàng đang trống, không thể thanh toán!" });
            }

            // Lấy danh sách sản phẩm thật từ CSDL theo các Id trong giỏ (không tin giá phía Client)
            var productIds = request.Items.Select(i => i.ProductId).Distinct().ToList();
            var products = await _context.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToDictionaryAsync(p => p.ProductId);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                CashierUsername = string.IsNullOrWhiteSpace(request.CashierUsername)
                    ? (User.Identity?.Name ?? string.Empty)
                    : request.CashierUsername.Trim(),
                TotalAmount = 0
            };

            decimal total = 0;
            foreach (var item in request.Items)
            {
                if (item.Quantity <= 0)
                {
                    return BadRequest(new { message = "Số lượng sản phẩm phải lớn hơn 0!" });
                }

                if (!products.TryGetValue(item.ProductId, out var product))
                {
                    return NotFound(new { message = $"Sản phẩm ID = {item.ProductId} không tồn tại trong hệ thống!" });
                }

                if (product.StockQuantity < item.Quantity)
                {
                    return BadRequest(new { message = $"Sản phẩm \"{product.ProductName}\" chỉ còn {product.StockQuantity} trong kho, không đủ số lượng bán!" });
                }

                // Trừ tồn kho
                product.StockQuantity -= item.Quantity;

                decimal lineTotal = product.Price * item.Quantity;
                total += lineTotal;

                order.Items.Add(new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,   // Luôn dùng giá hiện tại trong CSDL
                    LineTotal = lineTotal
                });
            }

            // Gắn khách hàng thành viên nếu khách có nhập số điện thoại
            if (!string.IsNullOrWhiteSpace(request.CustomerPhone))
            {
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(c => c.PhoneNumber == request.CustomerPhone.Trim());
                if (customer == null)
                {
                    return NotFound(new { message = "Không tìm thấy khách hàng thành viên có số điện thoại này!" });
                }

                order.CustomerId = customer.CustomerId;
                // Tích điểm: cứ mỗi 1.000đ tích 1 điểm
                customer.RewardPoints += (int)(total / 1000);
            }

            order.TotalAmount = total;
            order.CashReceived = request.CashReceived;
            order.ChangeAmount = request.CashReceived - total;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                orderId = order.OrderId,
                totalAmount = order.TotalAmount,
                cashReceived = order.CashReceived,
                changeAmount = order.ChangeAmount,
                message = "Thanh toán thành công và đã in hóa đơn!"
            });
        }

        // 2. READ: Lịch sử hóa đơn bán hàng (GET /api/orders?date=yyyy-MM-dd) - Chỉ Admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] DateTime? date)
        {
            var query = _context.Orders.AsNoTracking().Include(o => o.Items).AsQueryable();
            if (date.HasValue)
            {
                var day = date.Value.Date;
                query = query.Where(o => o.OrderDate >= day && o.OrderDate < day.AddDays(1));
            }

            var list = await query.OrderByDescending(o => o.OrderDate).ToListAsync();
            return Ok(list.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                CashierUsername = o.CashierUsername,
                TotalAmount = o.TotalAmount,
                CashReceived = o.CashReceived,
                ChangeAmount = o.ChangeAmount,
                ItemCount = o.Items.Sum(i => i.Quantity)
            }));
        }

        // 3. READ: Chi tiết một hóa đơn (GET /api/orders/{id}) - Chỉ Admin
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _context.Orders.AsNoTracking()
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound(new { message = "Không tìm thấy hóa đơn!" });
            }

            return Ok(new
            {
                order.OrderId,
                order.OrderDate,
                order.CashierUsername,
                order.CustomerId,
                order.TotalAmount,
                order.CashReceived,
                order.ChangeAmount,
                Items = order.Items.Select(i => new
                {
                    i.ProductId,
                    ProductName = i.Product.ProductName,
                    i.Quantity,
                    i.UnitPrice,
                    i.LineTotal
                })
            });
        }
    }

    public class CheckoutItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Giá phía Client gửi lên, Server sẽ không dùng để tính
    }

    public class CheckoutRequest
    {
        public string? CashierUsername { get; set; }
        public string? CustomerPhone { get; set; }
        public decimal CashReceived { get; set; }
        public List<CheckoutItem> Items { get; set; } = new();
    }

    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CashierUsername { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal CashReceived { get; set; }
        public decimal ChangeAmount { get; set; }
        public int ItemCount { get; set; }
    }
}
