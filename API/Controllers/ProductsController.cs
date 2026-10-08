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
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. READ: Lấy toàn bộ sản phẩm (GET /api/products)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Products.AsNoTracking()
                .OrderBy(p => p.ProductId)
                .Select(p => new ProductListItemDto
                {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty
                })
                .ToListAsync();
            return Ok(list);
        }

        // 2. READ: Tra cứu 1 sản phẩm theo mã vạch cho quầy POS (GET /api/products/barcode/{barcode})
        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            var product = await _context.Products.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Barcode == barcode);

            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm có mã vạch này!" });
            }
            return Ok(product);
        }

        // 3. SEARCH: Tìm theo từ khóa + lọc theo nhóm hàng (GET /api/products/search?keyword=...&categoryId=...)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? keyword, [FromQuery] int? categoryId)
        {
            var query = _context.Products.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p => p.ProductName.Contains(keyword) || p.Barcode.Contains(keyword));
            }
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            var list = await query
                .OrderBy(p => p.ProductId)
                .Select(p => new ProductListItemDto
                {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty
                })
                .ToListAsync();
            return Ok(list);
        }

        // 4. CREATE: Thêm sản phẩm mới (POST /api/products) - Admin & Warehouse
        [HttpPost]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Create([FromBody] ProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Barcode) || string.IsNullOrWhiteSpace(request.ProductName))
            {
                return BadRequest(new { message = "Mã vạch và tên sản phẩm không được để trống!" });
            }

            bool barcodeExists = await _context.Products.AnyAsync(p => p.Barcode == request.Barcode.Trim());
            if (barcodeExists)
            {
                return Conflict(new { message = "Mã vạch sản phẩm đã tồn tại!" });
            }

            var product = new Product
            {
                Barcode = request.Barcode.Trim(),
                ProductName = request.ProductName.Trim(),
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByBarcode), new { barcode = product.Barcode }, product);
        }

        // 5. UPDATE: Cập nhật sản phẩm (PUT /api/products/{id}) - Admin & Warehouse
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần sửa!" });
            }

            bool barcodeExists = await _context.Products.AnyAsync(p => p.Barcode == request.Barcode.Trim() && p.ProductId != id);
            if (barcodeExists)
            {
                return Conflict(new { message = "Mã vạch sản phẩm đã tồn tại!" });
            }

            product.Barcode = request.Barcode.Trim();
            product.ProductName = request.ProductName.Trim();
            product.Price = request.Price;
            product.StockQuantity = request.StockQuantity;
            product.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE: Xóa sản phẩm (DELETE /api/products/{id}) - Admin & Warehouse
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần xóa!" });
            }

            // Không cho xóa sản phẩm đã phát sinh trong hóa đơn bán hàng
            bool hasOrders = await _context.OrderItems.AnyAsync(oi => oi.ProductId == id);
            if (hasOrders)
            {
                return BadRequest(new { message = "Sản phẩm đã có trong hóa đơn bán hàng, không thể xóa!" });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    // DTO hiển thị phía Client
    public class ProductListItemDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class ProductRequest
    {
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
