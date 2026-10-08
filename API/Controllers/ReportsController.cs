using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bắt buộc phải có Token mới gọi được các API trong Controller này
    public class ReportsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ReportsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // Báo cáo doanh thu nhanh theo ngày (GET /api/reports/quick?date=yyyy-MM-dd)
        // Chỉ Admin mới được xem dữ liệu tài chính
        [HttpGet("quick")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetQuickReport([FromQuery] DateTime? date)
        {
            var day = (date ?? DateTime.Today).Date;

            var orders = await _context.Orders.AsNoTracking()
                .Where(o => o.OrderDate >= day && o.OrderDate < day.AddDays(1))
                .ToListAsync();

            // Top sản phẩm bán chạy nhất trong ngày
            var bestSeller = await _context.OrderItems.AsNoTracking()
                .Where(oi => oi.Order.OrderDate >= day && oi.Order.OrderDate < day.AddDays(1))
                .GroupBy(oi => new { oi.ProductId, oi.Product.ProductName })
                .Select(g => new { g.Key.ProductName, QuantitySold = g.Sum(x => x.Quantity) })
                .OrderByDescending(x => x.QuantitySold)
                .FirstOrDefaultAsync();

            return Ok(new QuickReportDto
            {
                ReportDate = day,
                TotalOrders = orders.Count,
                TotalRevenue = orders.Sum(o => o.TotalAmount),
                BestSeller = bestSeller == null ? "Chưa có dữ liệu" : $"{bestSeller.ProductName} ({bestSeller.QuantitySold} suất)"
            });
        }

        // Danh sách doanh thu theo từng ngày trong khoảng (GET /api/reports/revenue?from=...&to=...) - Chỉ Admin
        [HttpGet("revenue")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRevenue([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var start = (from ?? DateTime.Today.AddDays(-7)).Date;
            var end = (to ?? DateTime.Today).Date;

            var orders = await _context.Orders.AsNoTracking()
                .Where(o => o.OrderDate >= start && o.OrderDate < end.AddDays(1))
                .ToListAsync();

            var result = orders
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Orders = g.Count(),
                    Revenue = g.Sum(x => x.TotalAmount)
                })
                .OrderBy(x => x.Date)
                .ToList();

            return Ok(result);
        }
    }

    public class QuickReportDto
    {
        public DateTime ReportDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public string BestSeller { get; set; } = string.Empty;
    }
}
