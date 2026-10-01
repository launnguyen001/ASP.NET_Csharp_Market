using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    // DbContext đại diện cho phiên làm việc với cơ sở dữ liệu SQL Server
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        // Khai báo các bảng dữ liệu ánh xạ từ Model
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;

        // Cấu hình dữ liệu mồi ban đầu (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Nạp sẵn 5 nhóm món của tiệm vào SQL Server ngay khi tạo bảng
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Trà Sữa Truyền Thống", Description = "Trà sữa truyền thống, sữa tươi, sữa đậm" },
                new Category { CategoryId = 2, CategoryName = "Trà Sữa Đá Xay", Description = "Trà xay đá, đá xay viên, sinh tố" },
                new Category { CategoryId = 3, CategoryName = "Trà Trái Cây & Thơm", Description = "Trà đào cam sả, trà vải, trà thanh long" },
                new Category { CategoryId = 4, CategoryName = "Bánh Ngọt & Ăn Vặt", Description = "Bánh mì chà, bánh ngọt, đồ ăn vặt" },
                new Category { CategoryId = 5, CategoryName = "Cà Phê & Đồ Uống Khác", Description = "Cà phê, nước ép, trà nóng" }
            );

            // Nạp sẵn 3 khách hàng thành viên mẫu
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn A", PhoneNumber = "0901122334", Address = "12 Lê Lợi, Q.1, TP.HCM", MembershipRank = "Vàng", RewardPoints = 150 },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị B", PhoneNumber = "0918877665", Address = "45 Nguyễn Huệ, Q.1, TP.HCM", MembershipRank = "Bạc", RewardPoints = 50 },
                new Customer { CustomerId = 3, CustomerName = "Lê Văn C", PhoneNumber = "0983344556", Address = "78 Hai Bà Trưng, Q.5, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 10 }
            );
        }
    }
}