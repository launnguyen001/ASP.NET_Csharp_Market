# Hệ Thống Quản Lý Tiệm Trà Sữa & Ăn Vặt (Tea Shop & Snack Bar Management System)

**Sinh viên:** Nguyễn Ngọc Lầu — **MSSV:** 2124110129
**Lớp:** CCQ2411D

**Đồ án môn:** Lập trình Ứng dụng .NET Core

**Branch:** `buoi_4` — **Quy trình POS đầy đủ**: Bảng `Users` + `Orders`, phân quyền 3 vai trò, màn hình Single-Form, bán hàng tại quầy

---

## 1. Giới thiệu

Xây dựng hệ thống **Quản lý Bán lẻ & Tồn kho** cho tiệm trà sữa & ăn vặt theo mô hình phân tầng **Client - Server**:

- **Backend (Web API):** xử lý nghiệp vụ, quản lý dữ liệu, xác thực JWT.
- **Frontend (WinForms):** giao diện người dùng, giao tiếp với Backend qua `HttpClient`.

### Tóm tắt tiến độ 4 buổi

| Buổi | Nội dung chính |
|---|---|
| Buổi 2 | Bảo mật **JWT (Stateless Authentication)** & **Phân quyền** theo Role. Dữ liệu lưu **In-Memory**. |
| Buổi 3 | Chuyển dữ liệu sang **SQL Server thật** qua **Entity Framework Core**, thêm bảng **Products** & **Customers**, **Migration + Data Seeding**, màn hình **Quản lý khách hàng**. |
| **Buổi 4** | Bảng **Users** (đăng nhập từ CSDL, mật khẩu băm **SHA-256**), bảng **Orders/OrderItems** + nghiệp vụ **checkout POS**, CRUD **Products**, báo cáo doanh thu, và **giao diện Single-Form** với phân quyền theo vai trò. |

Ở Buổi 4, hệ thống đi vào **nghiệp vụ bán hàng thật**: quầy POS quét mã vạch → tạo hóa đơn → trừ tồn kho → tích điểm khách hàng → báo cáo doanh thu.

---

## 2. Kiến trúc Solution

```
Lau_Market
├── API/                     # Backend: ASP.NET Core Web API (.NET 8)
│   ├── Controllers/
│   │   ├── AuthController.cs           # Đăng nhập tra CSDL → cấp JWT (BỔ SUNG Buổi 4)
│   │   ├── CategoriesController.cs     # CRUD nhóm hàng + endpoint phân quyền demo
│   │   ├── CustomersController.cs      # CRUD khách hàng + tìm kiếm
│   │   ├── ProductsController.cs       # CRUD sản phẩm, tra barcode (MỚI Buổi 4)
│   │   ├── OrdersController.cs         # Checkout POS + lịch sử hóa đơn (MỚI Buổi 4)
│   │   ├── ReportsController.cs        # Báo cáo doanh thu (MỚI Buổi 4)
│   │   ├── UsersController.cs          # Quản trị tài khoản nhân viên (MỚI Buổi 4)
│   │   └── RolesController.cs          # CRUD vai trò (In-Memory, bài tập mở rộng)
│   ├── Data/
│   │   └── SupermarketDbContext.cs     # 6 DbSet + Data Seeding (4×15 bản ghi)
│   ├── Helpers/
│   │   └── PasswordHasher.cs           # Băm/so khớp SHA-256 (MỚI Buổi 4)
│   ├── Migrations/                      # 6 migration do EF Core sinh ra
│   │   ├── ..._InitialCreateDatabase.cs
│   │   ├── ..._AddCustomersTable.cs
│   │   ├── ..._UpdateCategoriesForTeaShop.cs
│   │   ├── ..._Seed15CategoriesAndCustomers.cs
│   │   ├── ..._Seed15Products.cs
│   │   ├── ..._AddUsersAndOrdersTables.cs      # ← Buổi 4
│   │   └── SupermarketDbContextModelSnapshot.cs
│   ├── Models/
│   │   ├── Category.cs / Product.cs / Customer.cs
│   │   ├── User.cs                     # Tài khoản nhân viên (MỚI Buổi 4)
│   │   ├── Order.cs / OrderItem.cs     # Hóa đơn & chi tiết (MỚI Buổi 4)
│   │   └── Role.cs
│   ├── appsettings.json                # ConnectionStrings + JwtSettings:Secret
│   ├── Program.cs                      # Đăng ký DbContext, JwtBearer, Swagger
│   └── Properties/launchSettings.json
└── FE/                      # Frontend: Windows Forms (.NET 8)
    ├── FormLogin.*                     # Đăng nhập (Form khởi chạy đầu tiên)
    ├── FormMainShell.*                 # Khung điều khiển Single-Form + sidebar (MỚI)
    ├── FormPOS.*                       # Quầy bán hàng & thu ngân (MỚI)
    ├── FormProductManagement.*         # Quản lý sản phẩm & tồn kho (MỚI)
    ├── FormUserManagement.*            # Quản trị tài khoản & phân quyền (MỚI)
    ├── FormQuickReport.*               # Báo cáo doanh thu nhanh (MỚI)
    ├── FormCategoryManagement.*        # Quản lý danh mục nhóm hàng
    ├── FormCustomerManagement.*        # Quản lý khách hàng & tích điểm
    ├── FormRoleManagement.*            # Quản lý vai trò (In-Memory)
    ├── SessionManager.cs               # JWT + Role + Username + FullName
    ├── ApiClientService.cs             # HttpClient dùng chung + Bearer Token
    └── Program.cs                      # Mở FormLogin trước
```

---

## 3. Thay đổi chính ở Buổi 4

| # | Nội dung | Thành phần |
|---|---|---|
| 1 | **Đăng nhập từ SQL Server** — bỏ hoàn toàn chuỗi hardcode, mật khẩu lưu dạng băm SHA-256 | `Users` table, `PasswordHasher`, `AuthController` |
| 2 | **CRUD Sản phẩm** — có DTO, kiểm tra barcode trùng, chặn xóa sản phẩm đã bán | `ProductsController`, `FormProductManagement` |
| 3 | **Bán hàng tại quầy POS** — quét mã vạch, giỏ hàng, thanh toán, trừ tồn kho, tích điểm | `Orders`/`OrderItems`, `OrdersController`, `FormPOS` |
| 4 | **Quản trị tài khoản** — tạo/sửa/xóa, đặt lại mật khẩu, khóa/mở khóa | `UsersController`, `FormUserManagement` |
| 5 | **Báo cáo doanh thu** — tổng quan theo ngày + top sản phẩm bán chạy | `ReportsController`, `FormQuickReport` |
| 6 | **Giao diện Single-Form** — 1 khung chính, sidebar phân quyền theo vai trò | `FormMainShell` |

---

## 4. Backend — Chi tiết Buổi 4

### 4.1. Bảng `Users` & băm mật khẩu

`API/Helpers/PasswordHasher.cs` — băm bằng **SHA-256**, trả về chuỗi hex 64 ký tự:

```csharp
public static string Hash(string password)
{
    using var sha = SHA256.Create();
    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
    return Convert.ToHexString(bytes);
}

public static bool Verify(string password, string passwordHash) =>
    string.Equals(Hash(password), passwordHash, StringComparison.OrdinalIgnoreCase);
```

- Cột `PasswordHash` có `[StringLength(64)]` — **không bao giờ** lưu/ trả về mật khẩu gốc.
- Tất cả API trả về tài khoản đều dùng `UserDto` **loại bỏ `PasswordHash`**.
- Tên đăng nhập bắt buộc duy nhất: `modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique()`.
- Seed **15 tài khoản** (mật khẩu đều là `123456`): 4 Admin, 7 Cashier, 4 Warehouse.

Tài khoản mẫu tiêu biểu:

| Tài khoản | Mật khẩu | Vai trò | Ghi chú |
|---|---|---|---|
| `admin01` | `123456` | Admin | Toàn quyền (mặc định khi test) |
| `cashier01` | `123456` | Cashier | Bán hàng tại quầy POS |
| `ware01` | `123456` | Warehouse | Quản lý sản phẩm & kho |

### 4.2. `AuthController` — đăng nhập tra CSDL

```csharp
var user = await _context.Users.AsNoTracking()
    .FirstOrDefaultAsync(u => u.Username == request.Username);

if (user == null || !PasswordHasher.Verify(request.Password, user.PasswordHash))
    return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });

if (!user.IsActive)   // tài khoản bị khóa
    return Unauthorized(new { success = false, message = "Tài khoản đã bị khóa! ..." });
```

Phản hồi thành công chứa: `token`, `role`, `username`, `fullName` → `SessionManager` lưu lại toàn bộ.

### 4.3. `ProductsController` — CRUD sản phẩm

| Endpoint | Quyền | Điểm nhấn |
|---|---|---|
| `GET /api/products` | Token | Projection sang `ProductListItemDto` (kèm `CategoryName`) |
| `GET /api/products/barcode/{barcode}` | Token | Tra cứu nhanh cho máy quét POS |
| `GET /api/products/search?keyword=&categoryId=` | Token | Lọc đồng thời theo **từ khóa** (tên/mã vạch) và **nhóm hàng** |
| `POST` / `PUT` | Admin, Warehouse | Validate rỗng + **trùng barcode** → `409 Conflict` |
| `DELETE` | Admin, Warehouse | Chặn xóa sản phẩm đã xuất hiện trong `OrderItems` → `400` |

### 4.4. `OrdersController` — nghiệp vụ thanh toán (quan trọng nhất)

`POST /api/orders/checkout` (Admin, Cashier) thực hiện theo đúng thứ tự nghiệp vụ:

1. **Không tin giá phía Client** — load lại `Product` từ CSDL theo `ProductId`, dùng `product.Price` để tính tiền.
2. Validate: giỏ không rỗng, `Quantity > 0`, sản phẩm còn tồn.
3. **Trừ tồn kho** ngay trong vòng lặp (`product.StockQuantity -= item.Quantity`).
4. Nếu khách nhập **số điện thoại** → tìm `Customers`, gán `CustomerId` và **tích điểm: mỗi 1.000đ = 1 điểm**.
5. Ghi `TotalAmount`, `CashReceived`, `ChangeAmount` rồi `SaveChangesAsync()` **một lần duy nhất** (toàn bộ thay đổi nằm trong cùng một transaction ngầm của EF Core).

```csharp
var products = await _context.Products
    .Where(p => productIds.Contains(p.ProductId))
    .ToDictionaryAsync(p => p.ProductId);   // 1 query thay vì N query

product.StockQuantity -= item.Quantity;      // trừ tồn kho
decimal lineTotal = product.Price * item.Quantity;
order.Items.Add(new OrderItem {
    ProductId = product.ProductId,
    Quantity = item.Quantity,
    UnitPrice = product.Price,               // lưu lại giá tại thời điểm bán
    LineTotal = lineTotal
});
```

Lưu ý cấu hình quan hệ trong `SupermarketDbContext.OnModelCreating`:

| Quan hệ | DeleteBehavior | Lý do |
|---|---|---|
| `Order` 1 — N `OrderItem` | **Cascade** | Xóa hóa đơn thì xóa luôn dòng chi tiết |
| `OrderItem` N — 1 `Product` | **Restrict** | Không cho xóa sản phẩm đã từng bán |
| `Order` N — 1 `Customer` | **SetNull** | Xóa khách hàng vẫn giữ lại lịch sử hóa đơn (hóa đơn thành khách vãng lai) |

### 4.5. `UsersController` — quản trị tài khoản (chỉ Admin)

| Endpoint | Chức năng | Biện pháp bảo vệ |
|---|---|---|
| `GET /api/users`, `GET /api/users/{id}` | Danh sách / chi tiết | Trả `UserDto`, không lộ `PasswordHash` |
| `POST /api/users` | Tạo tài khoản | Validate vai trò ∈ {Admin, Cashier, Warehouse}, trùng tên → `409` |
| `PUT /api/users/{id}` | Sửa thông tin / đổi vai trò | Chuẩn hóa hoa-thường (`admin` → `Admin`) |
| `PUT /api/users/{id}/reset-password` | Đặt lại mật khẩu | Băm lại rồi ghi đè `PasswordHash` |
| `PUT /api/users/{id}/toggle-lock` | Khóa / mở khóa | **Chặn tự khóa chính mình** đang đăng nhập |
| `DELETE /api/users/{id}` | Xóa vĩnh viễn | **Chặn xóa chính mình** |

### 4.6. `ReportsController` — báo cáo (chỉ Admin)

| Endpoint | Trả về |
|---|---|
| `GET /api/reports/quick?date=yyyy-MM-dd` | `{ ReportDate, TotalOrders, TotalRevenue, BestSeller }` — tổng hợp hóa đơn trong ngày + sản phẩm bán chạy nhất ( LINQ `GroupBy` + `Sum` ) |
| `GET /api/reports/revenue?from=&to=` | Mảng `{ Date, Orders, Revenue }` nhóm theo từng ngày (mặc định 7 ngày gần nhất) |

### 4.7. Migration

Đã có **6 migration**; migration mới của Buổi 4 tạo 3 bảng `Users`, `Orders`, `OrderItems`:

| Migration | Nội dung |
|---|---|
| `InitialCreateDatabase` | Tạo `Categories` + `Products` (FK `Products.CategoryId`) |
| `AddCustomersTable` | Tạo `Customers` + 3 khách mẫu |
| `UpdateCategoriesForTeaShop` | Đổi 5 nhóm món sang mô hình tiệm trà sữa |
| `Seed15CategoriesAndCustomers` | Mở rộng 15 nhóm món + 15 khách hàng |
| `Seed15Products` | Nạp 15 sản phẩm mẫu |
| **`AddUsersAndOrdersTables`** | **Tạo `Users`, `Orders`, `OrderItems`** + FK (`Orders.CustomerId` → SetNull, `OrderItems.OrderId` → Cascade, `OrderItems.ProductId` → Restrict) + seed 15 tài khoản |

```bash
dotnet ef migrations add <TenMigration> --project API
dotnet ef database update --project API
```

### 4.8. Data Seeding hiện tại

| Bảng | Số bản ghi | Nội dung |
|---|---|---|
| `Categories` | 15 | 15 nhóm món tiệm trà sữa & ăn vặt |
| `Products` | 15 | barcode `89360111100xx`, giá 22.000đ – 125.000đ, tồn kho 40 – 200 |
| `Customers` | 15 | phân hạng Chuẩn / Bạc / Vàng / Kim Cương |
| `Users` | **15** | **3 vai trò**: 4 Admin, 7 Cashier, 4 Warehouse — mật khẩu `123456` (đã băm SHA-256) |

---

## 5. Model (Entity)

### 5.1. `User` — Tài khoản nhân viên (MỚI)

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `UserId` | `int` | Mã định danh (Identity 1,1) |
| `Username` | `string` | `[Required]`, `[StringLength(50)]`, **index duy nhất** |
| `PasswordHash` | `string` | `[StringLength(64)]` — chuỗi hex SHA-256 |
| `FullName` | `string` | `[Required]`, `[StringLength(100)]` |
| `Email` | `string?` | `[StringLength(100)]` |
| `Role` | `string` | `Admin` / `Cashier` / `Warehouse` |
| `IsActive` | `bool` | `false` = tài khoản bị khóa, không đăng nhập được |

### 5.2. `Order` — Hóa đơn bán hàng (MỚI)

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `OrderId` | `int` | Mã hóa đơn (Identity 1,1) |
| `OrderDate` | `DateTime` | Thời điểm bán |
| `CashierUsername` | `string` | Tài khoản thu ngân (**chuỗi**, không FK — tránh mất hóa đơn khi xóa user) |
| `CustomerId` | `int?` | `null` = khách vãng lai |
| `TotalAmount` | `decimal(18,2)` | Tổng tiền |
| `CashReceived` | `decimal(18,2)` | Tiền khách đưa |
| `ChangeAmount` | `decimal(18,2)` | Tiền thừa |
| `Items` | `ICollection<OrderItem>` | Dòng chi tiết (1-N, Cascade) |

### 5.3. `OrderItem` — Chi tiết hóa đơn (MỚI)

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `OrderItemId` | `int` | Mã dòng chi tiết |
| `OrderId` | `int` | FK → `Orders` (Cascade) |
| `ProductId` | `int` | FK → `Products` (**Restrict**) |
| `Quantity` | `int` | Số lượng bán |
| `UnitPrice` | `decimal(18,2)` | **Giá tại thời điểm bán** (không ảnh hưởng khi đổi giá sau) |
| `LineTotal` | `decimal(18,2)` | Thành tiền dòng |

### 5.4. Các Model giữ nguyên từ Buổi 3

- **`Category`**: `CategoryId`, `CategoryName` (`[Required]`, 100), `Description` (255), `Products` (`[JsonIgnore]`).
- **`Product`**: `Barcode` (50), `ProductName` (150), `Price`, `StockQuantity`, `CategoryId` (FK) + navigation `Category`.
- **`Customer`**: `CustomerName`, `PhoneNumber` (`varchar(15)`), `Address`, `RewardPoints`, `MembershipRank`.
- **`Role`**: `Id`, `RoleName`, `Description` — chỉ dùng cho `RolesController` In-Memory.

---

## 6. Bảo mật JWT & Phân quyền

### 6.1. Xác thực không trạng thái (giữ nguyên từ Buổi 2)

- Server **không lưu Session**; định danh (Username, Role) được mã hoá thành **JWT Token** (HS256, khóa lấy từ `JwtSettings:Secret`, hạn **2 giờ**).
- Client lưu token trong `SessionManager` và đính kèm mọi request qua `Authorization: Bearer <token>`.

### 6.2. Ma trận phân quyền 3 vai trò

| Chức năng | Admin | Cashier | Warehouse |
|---|:---:|:---:|:---:|
| Bán hàng POS (`FormPOS`, checkout) | ✅ | ✅ | ❌ |
| Quản lý khách hàng & tích điểm | ✅ | ✅ | ❌ |
| Quản lý danh mục nhóm hàng | ✅ | ❌ | ✅ |
| Quản lý sản phẩm & tồn kho | ✅ | ❌ | ✅ |
| Báo cáo doanh thu | ✅ | ❌ | ❌ |
| Quản trị tài khoản người dùng | ✅ | ❌ | ❌ |

Phân quyền được thực hiện ở **hai lớp**:

1. **Lớp API** — `[Authorize(Roles = "...")]` trên từng action (bảo vệ thực sự).
2. **Lớp giao diện** — `FormMainShell.ApplyRolePermissions()` ẩn/hiện nút sidebar theo vai trò, *như một lời nhắc thân thiện* (không phải lớp bảo vệ).

```csharp
// FormMainShell.cs — ẩn nút theo vai trò
case "CASHIER":
    btnPOS.Visible = true;
    btnCustomer.Visible = true;
    btnCategory.Visible = false;
    btnProduct.Visible = false;
    btnReports.Visible = false;
    btnUserManage.Visible = false;
    break;
```

### 6.3. Bảo vệ theo Controller

| Controller | Cách bảo vệ |
|---|---|
| `AuthController` | Endpoint công khai (không cần token) |
| `ProductsController`, `OrdersController`, `UsersController`, `ReportsController`, `CustomersController`, `RolesController` | `[Authorize]` — bắt buộc có token |
| `POST /api/orders/checkout` | `[Authorize(Roles = "Admin,Cashier")]` |
| `POST/PUT/DELETE /api/products` | `[Authorize(Roles = "Admin,Warehouse")]` |
| Toàn bộ `/api/users`, `/api/reports` | `[Authorize(Roles = "Admin")]` |
| `GET /api/orders`, `GET /api/orders/{id}` | `[Authorize(Roles = "Admin")]` |
| `GET /api/categories/admin-dashboard` | `[Authorize(Roles = "Admin")]` |
| `GET /api/categories/staff-pos` | `[Authorize(Roles = "Admin,Cashier")]` |
| `POST/PUT/DELETE /api/categories`, `/api/customers` | `[Authorize(Roles = "Admin")]` |

---

## 7. Danh sách Endpoint

> Tất cả (trừ `POST /api/auth/login`) đều yêu cầu `Bearer Token`.

### 7.1. Auth — `/api/auth`

| Phương thức | Đường dẫn | Quyền | Chức năng |
|---|---|---|---|
| `POST` | `/api/auth/login` | Công khai | Đăng nhập tra CSDL → JWT + Role + FullName |

### 7.2. Products — `/api/products` **(MỚI Buổi 4)**

| Phương thức | Đường dẫn | Quyền | Chức năng |
|---|---|---|---|
| `GET` | `/api/products` | Token | Toàn bộ sản phẩm (kèm tên nhóm) |
| `GET` | `/api/products/barcode/{barcode}` | Token | Tra cứu theo mã vạch (POS) |
| `GET` | `/api/products/search?keyword=&categoryId=` | Token | Tìm theo tên/mã vạch + lọc nhóm |
| `POST` | `/api/products` | Admin, Warehouse | Thêm mới (trùng barcode → 409) |
| `PUT` | `/api/products/{id}` | Admin, Warehouse | Cập nhật |
| `DELETE` | `/api/products/{id}` | Admin, Warehouse | Xóa (đã bán → 400) |

### 7.3. Orders — `/api/orders` **(MỚI Buổi 4)**

| Phương thức | Đường dẫn | Quyền | Chức năng |
|---|---|---|---|
| `POST` | `/api/orders/checkout` | Admin, Cashier | Thanh toán giỏ hàng, trừ kho, tích điểm |
| `GET` | `/api/orders?date=yyyy-MM-dd` | Admin | Lịch sử hóa đơn (lọc theo ngày) |
| `GET` | `/api/orders/{id}` | Admin | Chi tiết hóa đơn (`Include` Items + Product) |

### 7.4. Reports — `/api/reports` **(MỚI Buổi 4)**

| Phương thức | Đường dẫn | Quyền | Chức năng |
|---|---|---|---|
| `GET` | `/api/reports/quick?date=` | Admin | Số hóa đơn, doanh thu, sản phẩm bán chạy |
| `GET` | `/api/reports/revenue?from=&to=` | Admin | Doanh thu theo từng ngày |

### 7.5. Users — `/api/users` **(MỚI Buổi 4)**

| Phương thức | Đường dẫn | Quyền | Chức năng |
|---|---|---|---|
| `GET` | `/api/users`, `/api/users/{id}` | Admin | Danh sách / chi tiết (không trả mật khẩu) |
| `POST` | `/api/users` | Admin | Tạo tài khoản |
| `PUT` | `/api/users/{id}` | Admin | Sửa thông tin / đổi vai trò |
| `PUT` | `/api/users/{id}/reset-password` | Admin | Đặt lại mật khẩu |
| `PUT` | `/api/users/{id}/toggle-lock` | Admin | Khóa / mở khóa |
| `DELETE` | `/api/users/{id}` | Admin | Xóa tài khoản |

### 7.6. Categories — `/api/categories`

| Phương thức | Đường dẫn | Quyền | Chức năng |
|---|---|---|---|
| `GET` | `/api/categories`, `/{id}`, `/search?keyword=` | Token | Đọc dữ liệu |
| `GET` | `/api/categories/admin-dashboard` | Admin | Demo phân quyền |
| `GET` | `/api/categories/staff-pos` | Admin, Cashier | Demo phân quyền |
| `POST` / `PUT` / `DELETE` | `/api/categories` | Admin | Ghi / xóa |

### 7.7. Customers — `/api/customers`

| Phương thức | Đường dẫn | Quyền | Chức năng |
|---|---|---|---|
| `GET` | `/api/customers`, `/{id}`, `/search?keyword=` | Token | Đọc, tìm theo tên hoặc SĐT |
| `POST` / `PUT` / `DELETE` | `/api/customers` | Admin | Ghi / xóa |

### 7.8. Roles — `/api/roles` (In-Memory)

Toàn bộ 5 endpoint (`GET`, `GET {id}`, `POST`, `PUT {id}`, `DELETE {id}`) đều yêu cầu **Admin**.

### 7.9. Swagger UI

Truy cập `https://localhost:7065/swagger` → bấm **Authorize** → dán `Bearer <token>`.

**Kịch bản kiểm chứng:**

1. Chưa đăng nhập, gọi `GET /api/products` → **401 Unauthorized**.
2. `POST /api/auth/login` với `cashier01/123456` → copy token.
3. Dán token → `GET /api/products` → **200**; `GET /api/users` → **403 Forbidden** (thu ngân không xem được tài khoản).
4. Đăng nhập `admin01/123456` → `GET /api/users` trả **15 tài khoản**; `POST /api/orders/checkout` với giỏ hàng mẫu → `GET /api/orders` thấy hóa đơn vừa tạo.

---

## 8. Frontend (WinForms)

### 8.1. Kiến trúc Single-Form (thay đổi lớn nhất Buổi 4)

Trước Buổi 4, mỗi chức năng mở một `Form` riêng bằng `ShowDialog()`. Buổi 4 chuyển sang **một khung chính duy nhất** `FormMainShell` với 3 vùng:

```
┌─────────────┬──────────────────────────────────────┐
│ panelSidebar│ panelTopHeader: tiêu đề + user info  │
│  logo       ├──────────────────────────────────────┤
│  btnPOS     │                                      │
│  btnCategory│      panelMainContent                │
│  btnProduct │   (nhúng động Form con, TopLevel=false│
│  btnCustomer│    Dock=Fill, đóng form cũ trước)    │
│  btnReports │                                      │
│  btnUser    │                                      │
│  btnLogout  │                                      │
└─────────────┴──────────────────────────────────────┘
```

Cơ chế nhúng (`OpenChildForm`):

```csharp
if (_activeForm != null) { _activeForm.Close(); _activeForm = null; }
childForm.TopLevel = false;        // Bỏ tư cách cửa sổ độc lập
childForm.FormBorderStyle = FormBorderStyle.None;
childForm.Dock = DockStyle.Fill;   // Tràn vùng chứa
panelMainContent.Controls.Clear();
panelMainContent.Controls.Add(childForm);
```

Đăng nhập xong, `FormMainShell` tự **mở màn hình mặc định theo vai trò**:

| Vai trò | Màn hình mặc định |
|---|---|
| Admin | Quản lý danh mục nhóm hàng |
| Warehouse | Quản lý sản phẩm & kho |
| Cashier | Quầy bán hàng POS |

Đăng xuất: `btnLogout` → xác nhận → `ApiClientService.ClearSession()` → đóng shell → quay lại `FormLogin`.

### 8.2. `FormLogin`

- Gọi `ApiClientService.LoginAsync()` → lưu `token`, `role`, `username`, `fullName` → mở `FormMainShell` bằng `ShowDialog()`.
- Khi shell đóng (đăng xuất) → `ClearSession()` → hiện lại `FormLogin` cho phiên kế tiếp.

### 8.3. `SessionManager` & `ApiClientService`

```csharp
public static class SessionManager
{
    public static string JwtToken { get; set; }
    public static string CurrentRole { get; set; }
    public static string CurrentUsername { get; set; }   // ghi lên hóa đơn POS
    public static string CurrentFullName { get; set; }   // hiển thị trên header
    public static bool IsAuthenticated => !string.IsNullOrEmpty(JwtToken);
    public static void Clear() { ... }
}
```

`ApiClientService.Client` là **`HttpClient` dùng chung**, gắn sẵn `Authorization: Bearer` sau đăng nhập; có sẵn hàm dịch lỗi: `GetErrorMessage()` (401/403 → thông báo tiếng Việt) và `GetResponseMessage()`.

### 8.4. `FormPOS` — Quầy bán hàng (MỚI)

| Thành phần | Chi tiết |
|---|---|
| `txtBarcode` | Quét mã (máy quét tự bấm **Enter**) → `GET products/barcode/{code}` |
| `dgvCart` | Bảng giỏ hàng, nguồn dữ liệu `BindingList<CartItemDto>` |
| `txtCustomerPhone` | **Enter** để tra khách thành viên qua `customers/search` |
| `txtCashReceived` | Tự tính tiền thừa (`Change`) realtime |
| `btnCheckout` | **F9** = thanh toán → `POST orders/checkout` |
| `btnClearCart` | Hủy giỏ hàng (có xác nhận) |

Điểm kỹ thuật:

- `CartItemDto` implements **`INotifyPropertyChanged`** → khi sửa `Quantity`, DataGridView tự cập nhật `TotalPrice` mà không cần gán lại `DataSource`.
- `AutoGenerateColumns = false` + `DataPropertyName` để khai báo cột thủ công (không phụ thuộc thứ tự property của DTO).
- Kiểm tra tồn kho **cả phía Client** (chặn khi quét mặt hàng hết hàng) *và* phía Server (nguồn sự thật).
- Phím tắt: **F9** = thanh toán, **F2** = đưa con trỏ về ô quét mã (dùng `ProcessCmdKey` vì form nhúng `TopLevel=false` không nhận được `KeyPreview` bình thường).
- Lỗi `404` khi quét mã không khớp được bắt riêng bằng `catch (HttpRequestException ex) when (ex.StatusCode == NotFound)`.

### 8.5. `FormProductManagement` — Quản lý sản phẩm (MỚI)

- Bảng 6 cột: `Mã`, `Mã vạch`, `Tên sản phẩm`, `Đơn giá`, `Tồn kho`, `Nhóm hàng` (kèm `lblCount` hiển thị tổng).
- 2 ComboBox nhóm hàng: `cboFilterCategory` (lọc, có mục "Tất cả nhóm") và `cboCategory` (chọn ở ô chi tiết).
- Nút `btnLoad`, `btnSearch` (Enter trong ô tìm cũng chạy), `btnAdd`, `btnUpdate`, `btnDelete`.
- Đọc thông báo lỗi chi tiết từ Server qua `ReadErrorMessageAsync()` (hiển thị đúng msg `409` trùng barcode, `400` sản phẩm đã bán...).

### 8.6. `FormUserManagement` — Quản trị tài khoản (MỚI)

- Bảng: `Mã`, `Tên đăng nhập`, `Họ và tên`, `Email`, `Vai trò`, `Hoạt động`.
- Nút: `btnAddUser`, `btnResetPassword`, `btnToggleLock`, `btnDeleteUser`, `btnLoad`.
- ComboBox `cboRole` cố định 3 giá trị: Admin / Cashier / Warehouse.
- Bắt buộc chọn dòng trước khi thao tác (`GetSelectedUserId()` trả `0` nếu chưa chọn).

### 8.7. `FormQuickReport` — Báo cáo doanh thu (MỚI)

- Chọn ngày trên `dtpReportDate` (hoặc bấm `btnRunReport`) → `GET reports/quick?date=...`.
- Hiển thị 3 thẻ: **Tổng hóa đơn**, **Tổng doanh thu**, **Sản phẩm bán chạy**.

### 8.8. Các form còn lại

- **`FormCategoryManagement`**: CRUD danh mục; Buổi 4 bỏ 2 nút mở form con (đã có sidebar), thêm `lblCount` đếm tổng và tìm kiếm bằng **Enter**.
- **`FormCustomerManagement`**: giữ nguyên — CRUD khách hàng, validate phía Client, phân biệt 401/403 với "không có kết quả".
- **`FormRoleManagement`**: bài tập mở rộng, gọi `/api/roles` (In-Memory).

---

## 9. Hướng dẫn chạy

> **Yêu cầu:** .NET 8 SDK, SQL Server (Local/Express), Visual Studio 2022 hoặc `dotnet` CLI.
> Chứng chỉ HTTPS phát triển: `dotnet dev-certs https --trust`.

### Bước 0 — Chuẩn bị cơ sở dữ liệu

Tạo database rồi áp dụng migration:

```sql
CREATE DATABASE NgocLauDb;
```

```bash
dotnet ef database update --project API
```

> 6 bảng (`Categories`, `Products`, `Customers`, `Users`, `Orders`, `OrderItems`) cùng dữ liệu seed sẽ được tạo tự động.

### Cách 1: Visual Studio (khuyến nghị)

1. Mở `Lau_Market.sln`.
2. Đặt 2 project cùng khởi chạy: `API` + `FE`.
3. Nhấn **F5** → API mở Swagger, WinForms mở **FormLogin**.

### Cách 2: dòng lệnh

```bash
# Terminal 1 - Backend
dotnet run --project API --launch-profile https

# Terminal 2 - Frontend
dotnet run --project FE
```

### Trình tự kiểm thử

1. **DB**: `SELECT COUNT(*) FROM Users;` → **15** (tương tự Categories/Products/Customers).
2. **Đăng nhập**: `admin01 / 123456` → vào shell với sidebar đầy đủ 6 nút.
3. **POS**: đăng nhập `cashier01 / 123456` → màn POS → quét/nhập mã vạch `8936011110001` → nhập số tiền → **F9** → thành công; kiểm tra tồn kho sản phẩm đã giảm.
4. **Phân quyền**: với `cashier01`, sidebar **không hiện** "Quản lý Sản phẩm"; nếu ép gọi `GET /api/users` trên Swagger → **403**.
5. **Quản trị tài khoản**: `admin01` → "Quản trị Tài khoản" → tạo tài khoản mới, thử **Khóa** rồi đăng nhập lại → báo "Tài khoản đã bị khóa!".
6. **Báo cáo**: `admin01` → "Báo cáo Doanh thu" → chọn ngày vừa bán → tổng hóa đơn/doanh thu khớp với `GET /api/orders?date=...`.

---

## 10. Ghi chú

- **Cổng mặc định:** Backend HTTPS `7065`, HTTP `5207`. Nếu đổi port, cập nhật `BaseAddress` trong `ApiClientService`.
- **Khóa bí mật JWT** tại `appsettings.json` → `JwtSettings:Secret`; token hạn **2 giờ**.
- **Mật khẩu SQL Server** nằm trong `appsettings.json` — hợp lý cho môi trường học tập; triển khai thật phải dùng Secret Manager / biến môi trường.
- **`RolesController` vẫn In-Memory** — vai trò thật đã nằm trong cột `Users.Role`; bảng `Roles` chỉ còn phục vụ demo.
- **`CashierUsername` là chuỗi, không phải FK** — chủ đích để hóa đơn không bị xóa theo khi xóa tài khoản thu ngân.
- Khi thêm/xóa endpoint, cần **Restart** (không dùng Hot Reload) để Swagger cập nhật route.
- `FormRoleManagement` không còn nút mở từ giao diện (sidebar chưa có mục vai trò) — vẫn mở được qua code nếu cần.

---

## 11. Tổng kết kiến thức Buổi 4

- **Bảo mật mật khẩu**: băm **SHA-256** (`PasswordHasher`), so sánh bằng chuỗi hash, tuyệt đối không trả `PasswordHash` ra API (dùng DTO).
- **Đăng nhập từ CSDL**: truy vấn `Users` theo username → verify hash → kiểm tra `IsActive` → cấp JWT; thay thế hoàn toàn dữ liệu hardcode.
- **Quy tắc thiết kế API**: *không tin dữ liệu phía Client* (giá bán do Server quyết định), trả lỗi **400/401/403/404/409** kèm `message` thân thiện thay vì lỗi 500.
- **Nghiệp vụ POS trong 1 lần `SaveChanges`**: kiểm tra tồn → trừ kho → ghi hóa đơn + chi tiết → tích điểm khách hàng; EF Core tự gói thành transaction.
- **Quan hệ & DeleteBehavior**: `Cascade` (hóa đơn → chi tiết), `Restrict` (chặn xóa sản phẩm đã bán), `SetNull` (giữ hóa đơn khi xóa khách).
- **Projection & DTO**: `Select()` sang DTO giúp giảm dung lượng JSON và loại bỏ thuộc tính nhạy cảm; `AsNoTracking()` cho mọi thao tác đọc.
- **Phân quyền nhiều lớp**: `[Authorize(Roles)]` ở API (bảo vệ thật) + `ApplyRolePermissions()` ở WinForms (trải nghiệm người dùng).
- **Single-Form Architecture**: nhúng Form con với `TopLevel=false` + `Dock=Fill`, quản lý `_activeForm` để đóng/mở đúng lúc — chuẩn cho WinForms ứng dụng nghiệp vụ.
- **BindingList + INotifyPropertyChanged**: DataGridView tự đồng bộ khi dữ liệu giỏ hàng thay đổi.
- **Task/async toàn diện**: mọi call API đều `async/await` để giao diện không bị đơ khi chờ Server.
