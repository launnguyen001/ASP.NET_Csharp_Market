using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Helpers;

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
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;

        // Cấu hình dữ liệu mồi ban đầu (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tên đăng nhập phải là duy nhất trên toàn hệ thống
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            // Một hóa đơn có nhiều dòng sản phẩm; xóa hóa đơn thì xóa luôn các dòng chi tiết
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Chi tiết hóa đơn tham chiếu sản phẩm: không cho xóa sản phẩm đã từng bán
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Khách hàng thành viên: xóa khách thì giữ lại hóa đơn (bỏ liên kết)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Nạp sẵn 15 tài khoản nhân viên mẫu phân quyền theo bảng kiểm thử (Buổi 4)
            string defaultHash = PasswordHasher.Hash("123456");
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin01", PasswordHash = defaultHash, FullName = "Nguyễn Quản Trị", Email = "admin01@minimart.vn", Role = "Admin", IsActive = true },
                new User { UserId = 2, Username = "admin02", PasswordHash = defaultHash, FullName = "Trần Giám Đốc", Email = "admin02@minimart.vn", Role = "Admin", IsActive = true },
                new User { UserId = 3, Username = "cashier01", PasswordHash = defaultHash, FullName = "Lê Thu Ngân", Email = "cashier01@minimart.vn", Role = "Cashier", IsActive = true },
                new User { UserId = 4, Username = "cashier02", PasswordHash = defaultHash, FullName = "Phạm Bán Hàng", Email = "cashier02@minimart.vn", Role = "Cashier", IsActive = true },
                new User { UserId = 5, Username = "cashier03", PasswordHash = defaultHash, FullName = "Hoàng Thu Ngân", Email = "cashier03@minimart.vn", Role = "Cashier", IsActive = true },
                new User { UserId = 6, Username = "cashier04", PasswordHash = defaultHash, FullName = "Vũ Thị Quầy", Email = "cashier04@minimart.vn", Role = "Cashier", IsActive = true },
                new User { UserId = 7, Username = "cashier05", PasswordHash = defaultHash, FullName = "Đỗ Bán Lẻ", Email = "cashier05@minimart.vn", Role = "Cashier", IsActive = true },
                new User { UserId = 8, Username = "ware01", PasswordHash = defaultHash, FullName = "Ngô Quản Kho", Email = "ware01@minimart.vn", Role = "Warehouse", IsActive = true },
                new User { UserId = 9, Username = "ware02", PasswordHash = defaultHash, FullName = "Bùi Kiểm Kê", Email = "ware02@minimart.vn", Role = "Warehouse", IsActive = true },
                new User { UserId = 10, Username = "ware03", PasswordHash = defaultHash, FullName = "Dương Thủ Kho", Email = "ware03@minimart.vn", Role = "Warehouse", IsActive = true },
                new User { UserId = 11, Username = "ware04", PasswordHash = defaultHash, FullName = "Lý Nhập Hàng", Email = "ware04@minimart.vn", Role = "Warehouse", IsActive = true },
                new User { UserId = 12, Username = "admin_backup", PasswordHash = defaultHash, FullName = "Đặng Hỗ Trợ", Email = "admin_backup@minimart.vn", Role = "Admin", IsActive = true },
                new User { UserId = 13, Username = "cashier06", PasswordHash = defaultHash, FullName = "Hồ Ca Chiều", Email = "cashier06@minimart.vn", Role = "Cashier", IsActive = true },
                new User { UserId = 14, Username = "ware05", PasswordHash = defaultHash, FullName = "Trương Vận Chuyển", Email = "ware05@minimart.vn", Role = "Warehouse", IsActive = true },
                new User { UserId = 15, Username = "supervisor", PasswordHash = defaultHash, FullName = "Mai Giám Sát", Email = "supervisor@minimart.vn", Role = "Admin", IsActive = true }
            );

            // Nạp sẵn 15 nhóm món của tiệm trà sữa & ăn vặt vào SQL Server
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Trà Sữa Truyền Thống", Description = "Trà sữa truyền thống, sữa tươi, sữa đậm" },
                new Category { CategoryId = 2, CategoryName = "Trà Sữa Đá Xay", Description = "Trà xay đá, đá xay viên, sinh tố" },
                new Category { CategoryId = 3, CategoryName = "Trà Trái Cây & Thơm", Description = "Trà đào cam sả, trà vải, trà thanh long" },
                new Category { CategoryId = 4, CategoryName = "Trà Sữa Phô Mai", Description = "Trà sữa phô mai, cheese foam, kem cheese" },
                new Category { CategoryId = 5, CategoryName = "Trà Sữa Trân Châu", Description = "Trân châu đường, trân châu trắng, trân châu tuyết" },
                new Category { CategoryId = 6, CategoryName = "Trà Ô Long", Description = "Trà ô long nhật, trà ô long sữa, đen đá" },
                new Category { CategoryId = 7, CategoryName = "Trà Lài & Trà Sen", Description = "Trà lài, trà sen, trà lài sen" },
                new Category { CategoryId = 8, CategoryName = "Cà Phê", Description = "Cà phê đen, bạc xỉu, cà phê sữa đá" },
                new Category { CategoryId = 9, CategoryName = "Cà Phê Đặc Sản", Description = "Cà phê robusta Tây Nguyên, arabica Đắk Lắk" },
                new Category { CategoryId = 10, CategoryName = "Nước Ép Trái Cây", Description = "Nước cam, nước dứa, nước ổi, nước xoài" },
                new Category { CategoryId = 11, CategoryName = "Sữa Tươi & Sữa Chua", Description = "Sữa tươi, sữa chua uống, sữa đậm" },
                new Category { CategoryId = 12, CategoryName = "Bánh Ngọt", Description = "Bánh mì chà, bánh chuối, bánh bông lan" },
                new Category { CategoryId = 13, CategoryName = "Bánh Mì & Bánh Tráng Miệng", Description = "Bánh mì trứng, bánh mì xúc xích, bánh tráng" },
                new Category { CategoryId = 14, CategoryName = "Đồ Ăn Vặt", Description = "Snack, bánh quy, kẹo, trái cây khô" },
                new Category { CategoryId = 15, CategoryName = "Trà Nóng & Đồ Uống Khác", Description = "Trà nóng, nước khoáng, nước có ga, sữa chua uống" }
            );

            // Nạp sẵn 15 khách hàng thành viên mẫu
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn An", PhoneNumber = "0901122334", Address = "12 Lê Lợi, Q.1, TP.HCM", MembershipRank = "Vàng", RewardPoints = 1520 },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị Bích", PhoneNumber = "0918877665", Address = "45 Nguyễn Huệ, Q.1, TP.HCM", MembershipRank = "Bạc", RewardPoints = 860 },
                new Customer { CustomerId = 3, CustomerName = "Lê Văn Chiến", PhoneNumber = "0983344556", Address = "78 Hai Bà Trưng, Q.5, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 340 },
                new Customer { CustomerId = 4, CustomerName = "Phạm Thị Dung", PhoneNumber = "0935566778", Address = "15 Lý Thường Kiệt, Q.1, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 3200 },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Minh Đức", PhoneNumber = "0909988776", Address = "200 Trần Hưng Đạo, Q.5, TP.HCM", MembershipRank = "Vàng", RewardPoints = 1450 },
                new Customer { CustomerId = 6, CustomerName = "Võ Thị Giang", PhoneNumber = "0911223344", Address = "36 Nguyễn Văn Trỗi, Phú Nhuận, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 125 },
                new Customer { CustomerId = 7, CustomerName = "Đặng Quốc Huy", PhoneNumber = "0967445566", Address = "88 Cách Mạng Tháng 8, Q.10, TP.HCM", MembershipRank = "Bạc", RewardPoints = 720 },
                new Customer { CustomerId = 8, CustomerName = "Bùi Khánh Linh", PhoneNumber = "0972334455", Address = "5 Phạm Ngũ Lão, Q.5, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 2850 },
                new Customer { CustomerId = 9, CustomerName = "Đỗ Anh Tuấn", PhoneNumber = "0905667788", Address = "120 Pasteur, Q.3, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 60 },
                new Customer { CustomerId = 10, CustomerName = "Ngô Thị Mai", PhoneNumber = "0948112233", Address = "72 Lê Văn Sỹ, Q.3, TP.HCM", MembershipRank = "Bạc", RewardPoints = 940 },
                new Customer { CustomerId = 11, CustomerName = "Trịnh Bảo Ngọc", PhoneNumber = "0933445566", Address = "250 Điện Biên Phủ, Q.7, TP.HCM", MembershipRank = "Vàng", RewardPoints = 1680 },
                new Customer { CustomerId = 12, CustomerName = "Ngô Minh Quân", PhoneNumber = "0966778899", Address = "9 Nguyễn Thị Minh Khai, Q.1, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 15 },
                new Customer { CustomerId = 13, CustomerName = "Lý Hoàng Phong", PhoneNumber = "0975556677", Address = "310 Cách Mạng Tháng 8, Q.10, TP.HCM", MembershipRank = "Bạc", RewardPoints = 610 },
                new Customer { CustomerId = 14, CustomerName = "Phan Ngọc Oanh", PhoneNumber = "0988223344", Address = "17 Trần Phú, Q.5, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 4100 },
                new Customer { CustomerId = 15, CustomerName = "Vũ Đình Phúc", PhoneNumber = "0901445566", Address = "64 Nguyễn Đình Chiểu, Q.3, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 200 }
            );

            // Nạp sẵn 15 sản phẩm mẫu, phân bổ theo 15 nhóm món ở trên
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "8936011110001", ProductName = "Trà Sữa Truyền Thống (Size L)", Price = 35000, StockQuantity = 120, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "8936011110002", ProductName = "Trà Sữa Truyền Thống Ít Đường", Price = 35000, StockQuantity = 95, CategoryId = 1 },
                new Product { ProductId = 3, Barcode = "8936011110003", ProductName = "Trà Đào Cam Sả (Size M)", Price = 42000, StockQuantity = 80, CategoryId = 3 },
                new Product { ProductId = 4, Barcode = "8936011110004", ProductName = "Trà Sữa Đá Xay Dưa Hấu", Price = 45000, StockQuantity = 75, CategoryId = 2 },
                new Product { ProductId = 5, Barcode = "8936011110005", ProductName = "Trà Sữa Phô Mai Matcha", Price = 52000, StockQuantity = 60, CategoryId = 4 },
                new Product { ProductId = 6, Barcode = "8936011110006", ProductName = "Trà Sữa Trân Châu Đường", Price = 39000, StockQuantity = 140, CategoryId = 5 },
                new Product { ProductId = 7, Barcode = "8936011110007", ProductName = "Trà Ô Long Nhật (Size L)", Price = 38000, StockQuantity = 110, CategoryId = 6 },
                new Product { ProductId = 8, Barcode = "8936011110008", ProductName = "Trà Sen Nóng", Price = 30000, StockQuantity = 65, CategoryId = 7 },
                new Product { ProductId = 9, Barcode = "8936011110009", ProductName = "Cà Phê Đen Đá", Price = 25000, StockQuantity = 200, CategoryId = 8 },
                new Product { ProductId = 10, Barcode = "8936011110010", ProductName = "Bạc Xỉu", Price = 30000, StockQuantity = 175, CategoryId = 8 },
                new Product { ProductId = 11, Barcode = "8936011110011", ProductName = "Cà Phê Arabica Đắk Lắk 100g", Price = 125000, StockQuantity = 40, CategoryId = 9 },
                new Product { ProductId = 12, Barcode = "8936011110012", ProductName = "Nước Cam Ép Tươi 500ml", Price = 28000, StockQuantity = 90, CategoryId = 10 },
                new Product { ProductId = 13, Barcode = "8936011110013", ProductName = "Sữa Tươi UHT 1L", Price = 32000, StockQuantity = 130, CategoryId = 11 },
                new Product { ProductId = 14, Barcode = "8936011110014", ProductName = "Bánh Mì Chà Nướng", Price = 22000, StockQuantity = 70, CategoryId = 12 },
                new Product { ProductId = 15, Barcode = "8936011110015", ProductName = "Bánh Mì Trứng Ống Laflin", Price = 30000, StockQuantity = 85, CategoryId = 13 }
            );
        }
    }
}