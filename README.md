# Hệ Thống Quản Lý Tiệm Trà Sữa & Ăn Vặt (Tea Shop & Snack Bar Management System)

**Sinh viên:** Nguyễn Ngọc Lầu — **MSSV:** 2124110129
**Lớp:** CCQ2411D

**Đồ án môn:** Lập trình Ứng dụng .NET Core

**Branch:** `buoi_3` — Tích hợp **SQL Server + Entity Framework Core**

---

## 1. Giới thiệu

Xây dựng hệ thống **Quản lý Bán lẻ & Tồn kho** cho tiệm trà sữa & ăn vặt theo mô hình phân tầng **Client - Server**:

- **Backend (Web API):** xử lý nghiệp vụ, quản lý dữ liệu, xác thực JWT.
- **Frontend (WinForms):** giao diện người dùng, giao tiếp với Backend qua `HttpClient`.

### Tóm tắt tiến độ 3 buổi

| Buổi | Nội dung chính |
|---|---|
| Buổi 2 | Bảo mật **JWT (Stateless Authentication)** & **Phân quyền** theo Role (Admin, Cashier). Dữ liệu lưu **In-Memory**. |
| **Buổi 3** | Chuyển dữ liệu từ In-Memory sang **SQL Server thật** qua **Entity Framework Core**, thêm bảng **Products** & **Customers**, **Migration + Data Seeding**, và màn hình **Quản lý khách hàng** trên WinForms. |

Ở Buổi 3, toàn bộ dữ liệu đã được đưa vào SQL Server thông qua EF Core. Cơ chế **JWT & phân quyền** của Buổi 2 được giữ nguyên và áp dụng cho các endpoint mới.

---

## 2. Kiến trúc Solution

```
Lau_Market
├── API/                     # Backend: ASP.NET Core Web API (.NET 8)
│   ├── Controllers/
│   │   ├── AuthController.cs           # Đăng nhập & cấp phát JWT Token
│   │   ├── CategoriesController.cs     # CRUD nhóm hàng (SQL Server) + Endpoint phân quyền
│   │   ├── CustomersController.cs      # CRUD khách hàng (SQL Server) + Tìm kiếm
│   │   └── RolesController.cs          # CRUD vai trò (bài tập mở rộng, In-Memory)
│   ├── Data/
│   │   └── SupermarketDbContext.cs     # DbContext + Data Seeding
│   ├── Migrations/                      # 5 migration do EF Core sinh ra
│   │   ├── ..._InitialCreateDatabase.cs
│   │   ├── ..._AddCustomersTable.cs
│   │   ├── ..._UpdateCategoriesForTeaShop.cs
│   │   ├── ..._Seed15CategoriesAndCustomers.cs
│   │   ├── ..._Seed15Products.cs
│   │   └── SupermarketDbContextModelSnapshot.cs
│   ├── Models/
│   │   ├── Category.cs                 # Nhóm món (quan hệ 1-N với Product)
│   │   ├── Product.cs                  # Sản phẩm (khóa ngoại CategoryId)
│   │   ├── Customer.cs                 # Khách hàng thành viên
│   │   └── Role.cs                     # Vai trò nhân viên
│   ├── appsettings.json                # ConnectionStrings + JwtSettings:Secret
│   ├── Program.cs                      # Đăng ký DbContext, JwtBearer, Swagger
│   └── Properties/launchSettings.json
└── FE/                      # Frontend: Windows Forms (.NET 8)
    ├── FormLogin.*                     # Màn hình đăng nhập (khởi chạy đầu tiên)
    ├── FormCategoryManagement.*        # Quản lý nhóm món + nút mở màn Khách hàng
    ├── FormCustomerManagement.*        # Quản lý khách hàng (MỚI ở Buổi 3)
    ├── FormRoleManagement.*            # Quản lý vai trò (bài tập mở rộng)
    ├── SessionManager.cs               # Lưu JWT Token & Role dùng chung
    ├── ApiClientService.cs             # Login + gọi API đính kèm Bearer Token
    └── Program.cs                      # Điểm khởi chạy (mở FormLogin trước)
```

---

## 3. Backend — SQL Server + Entity Framework Core (Thay đổi Buổi 3)

### 3.1. Cài đặt & đăng ký DbContext

Ba package được thêm vào `API/API.csproj`:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.31" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.31" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.31" />
```

Đăng ký `DbContext` trong `Program.cs` thông qua **Dependency Injection**:

```csharp
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(connectionString));
```

### 3.2. Chuỗi kết nối

Đặt trong `API/appsettings.json` → `ConnectionStrings:DefaultConnection`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=NgocLauDb;User Id=sa;Password=***;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

> `TrustServerCertificate=True` giúp kết nối được với SQL Server Local mà không cần cài chứng thư.

### 3.3. `SupermarketDbContext` — ánh xạ Model ↔ Bảng

`API/Data/SupermarketDbContext.cs` khai báo 3 bảng:

```csharp
public DbSet<Category>  Categories { get; set; } = default!;
public DbSet<Product>   Products   { get; set; } = default!;
public DbSet<Customer>  Customers  { get; set; } = default!;
```

`OnModelCreating()` thực hiện **Data Seeding** — nạp sẵn dữ liệu mẫu ngay khi tạo bảng:

| Bảng | Số bản ghi mẫu | Nội dung |
|---|---|---|
| `Categories` | **15** | 15 nhóm món tiệm trà sữa & ăn vặt, từ Trà Sữa Truyền Thống, Trà Sữa Phô Mai, Trà Sữa Trân Châu... đến Cà Phê, Nước Ép, Bánh Ngọt, Đồ Ăn Vặt |
| `Customers` | **15** | 15 thành viên mẫu, phân bậc Chuẩn / Bạc / Vàng / Kim Cương, điểm tích luỹ từ 15đ đến 4100đ |
| `Products` | **15** | 15 sản phẩm mẫu có barcode `89360111100xx`, giá 25.000đ – 125.000đ, tồn kho 40 – 200 |

Mỗi nhóm món đều có ít nhất một sản phẩm tương ứng qua khoá ngoại `Product.CategoryId`.

### 3.4. Migration

Đã tạo 5 migration theo từng giai đoạn phát triển:

| Migration | Nội dung |
|---|---|
| `InitialCreateDatabase` | Tạo bảng `Categories` + `Products`, có khoá ngoại `Products.CategoryId → Categories.CategoryId` |
| `AddCustomersTable` | Tạo bảng `Customers` + nạp 3 khách hàng mẫu |
| `UpdateCategoriesForTeaShop` | Đổi nội dung 5 nhóm món từ "siêu thị mini" sang tiệm trà sữa |
| `Seed15CategoriesAndCustomers` | Mở rộng lên **15 nhóm món** và **15 khách hàng** (`UpdateData` cho id cũ + `InsertData` cho id mới) |
| `Seed15Products` | Nạp **15 sản phẩm** mẫu liên kết với 15 nhóm món |

Lệnh thường dùng:

```bash
dotnet ef migrations add <TenMigration> --project API
dotnet ef database update --project API
```

### 3.5. Quan hệ 1 - N giữa `Category` và `Product`

```csharp
// Category.cs — 1 danh mục có nhiều sản phẩm
[JsonIgnore] // Tránh lỗi lặp vòng vô tận khi serialize JSON
public virtual ICollection<Product>? Products { get; set; }

// Product.cs — nhiều sản phẩm thuộc 1 danh mục
public int CategoryId { get; set; }
[ForeignKey("CategoryId")]
public virtual Category? Category { get; set; }
```

> `[JsonIgnore]` là bắt buộc: nếu giữ quan hệ hai chiều, `System.Text.Json` sẽ serialize lặp đệ quy và trả về `Self referencing loop detected`.

---

## 4. Model (Entity)

### 4.1. `Category` — Nhóm món

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `CategoryId` | `int` | Mã định danh (Identity 1,1) |
| `CategoryName` | `string` | Tên nhóm món — `[Required]`, `[StringLength(100)]` |
| `Description` | `string?` | Mô tả chi tiết — `[StringLength(255)]` |
| `Products` | `ICollection<Product>?` | Danh sách sản phẩm thuộc nhóm — `[JsonIgnore]` |

### 4.2. `Product` — Sản phẩm (MỚI ở Buổi 3)

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `ProductId` | `int` | Mã định danh (Identity 1,1) |
| `Barcode` | `string` | Mã vạch — `[Required]`, `[StringLength(50)]` |
| `ProductName` | `string` | Tên sản phẩm — `[Required]`, `[StringLength(150)]` |
| `Price` | `decimal(18,2)` | Giá bán |
| `StockQuantity` | `int` | Số lượng tồn kho |
| `CategoryId` | `int` | **Khoá ngoại** trỏ tới `Categories` |
| `Category` | `Category?` | Navigation property (quan hệ 1-N) |

> `Product` đã có Model + **15 bản ghi seed** nhưng **chưa có Controller** — sẽ làm CRUD ở Buổi 4.

**Bảng seed 15 sản phẩm** (rút gọn — xem đầy đủ trong `SupermarketDbContext.OnModelCreating`):

| ID | Mã vạch | Tên sản phẩm | Giá | Tồn kho | Nhóm món |
|---|---|---|---|---|---|
| 1 | 8936011110001 | Trà Sữa Truyền Thống (Size L) | 35.000 | 120 | Trà Sữa Truyền Thống |
| 2 | 8936011110002 | Trà Sữa Truyền Thống Ít Đường | 35.000 | 95 | Trà Sữa Truyền Thống |
| 3 | 8936011110003 | Trà Đào Cam Sả (Size M) | 42.000 | 80 | Trà Trái Cây & Thơm |
| 4 | 8936011110004 | Trà Sữa Đá Xay Dưa Hấu | 45.000 | 75 | Trà Sữa Đá Xay |
| 5 | 8936011110005 | Trà Sữa Phô Mai Matcha | 52.000 | 60 | Trà Sữa Phô Mai |
| 6 | 8936011110006 | Trà Sữa Trân Châu Đường | 39.000 | 140 | Trà Sữa Trân Châu |
| 7 | 8936011110007 | Trà Ô Long Nhật (Size L) | 38.000 | 110 | Trà Ô Long |
| 8 | 8936011110008 | Trà Sen Nóng | 30.000 | 65 | Trà Lài & Trà Sen |
| 9 | 8936011110009 | Cà Phê Đen Đá | 25.000 | 200 | Cà Phê |
| 10 | 8936011110010 | Bạc Xỉu | 30.000 | 175 | Cà Phê |
| 11 | 8936011110011 | Cà Phê Arabica Đắk Lắk 100g | 125.000 | 40 | Cà Phê Đặc Sản |
| 12 | 8936011110012 | Nước Cam Ép Tươi 500ml | 28.000 | 90 | Nước Ép Trái Cây |
| 13 | 8936011110013 | Sữa Tươi UHT 1L | 32.000 | 130 | Sữa Tươi & Sữa Chua |
| 14 | 8936011110014 | Bánh Mì Chà Nướng | 22.000 | 70 | Bánh Ngọt |
| 15 | 8936011110015 | Bánh Mì Trứng Ống Laflin | 30.000 | 85 | Bánh Mì & Bánh Tráng Miệng |

### 4.3. `Customer` — Khách hàng thành viên (MỚI ở Buổi 3)

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `CustomerId` | `int` | Mã định danh (Identity 1,1) |
| `CustomerName` | `string` | Tên khách — `[Required]`, `[StringLength(100)]` |
| `PhoneNumber` | `string` | Số điện thoại — `[Required]`, `[StringLength(15)]`, kiểu `varchar(15)` |
| `Address` | `string?` | Địa chỉ — `[StringLength(200)]` |
| `RewardPoints` | `int` | Điểm tích luỹ (mặc định `0`) |
| `MembershipRank` | `string` | Hạng thẻ — `[StringLength(50)]`, mặc định `"Chuẩn"` |

> Dùng `varchar` cho `PhoneNumber` vì số điện thoại chỉ gồm chữ số, giúp tiết kiệm dung lượng so với `nvarchar`.

### 4.4. `Role` — Vai trò nhân viên

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `Id` | `int` | Mã định danh vai trò |
| `RoleName` | `string` | Tên vai trò (Admin, Cashier, Warehouse) |
| `Description` | `string?` | Mô tả chức năng của vai trò |

---

## 5. Bảo mật JWT & Phân quyền (Giữ nguyên từ Buổi 2)

### 5.1. Xác thực không trạng thái (Stateless Authentication)

- Server **không lưu Session** trên RAM; toàn bộ định danh (Username, Role) được mã hóa thành **JWT Token** và giao cho Client lưu trữ.
- JWT gồm 3 phần: **Header** (thuật toán HS256), **Payload** (Claims), **Signature** (chữ ký bằng `SymmetricSecurityKey`).

Tài khoản mẫu để đăng nhập:

| Tài khoản | Mật khẩu | Vai trò (Role) | Quyền hạn |
|---|---|---|---|
| `admin` | `123456` | Admin | Toàn quyền thao tác |
| `cashier` | `123456` | Cashier | Bán hàng / truy cập dữ liệu |

### 5.2. Luồng hoạt động

1. WinForms mở **FormLogin** → gọi `POST /api/auth/login` lấy JWT.
2. Token & Role được lưu vào lớp tĩnh **SessionManager**.
3. Mọi request sau đó (GET/POST/PUT/DELETE) đều đính kèm header `Authorization: Bearer <token>` qua `GetAuthenticatedClient()` / `ApiClientService`.
4. Server kiểm tra chữ ký JWT; nếu hợp lệ mới cho truy cập, sau đó kiểm tra Role theo `[Authorize(Roles = ...)]`.

### 5.3. Bảo vệ API

| Controller | Cách bảo vệ |
|---|---|
| `AuthController` | Không cần token (endpoint công khai) |
| `CategoriesController`, `CustomersController`, `RolesController` | `[Authorize]` — phải có token hợp lệ |
| `GET /api/categories/admin-dashboard` | `[Authorize(Roles = "Admin")]` — chỉ Admin |
| `GET /api/categories/staff-pos` | `[Authorize(Roles = "Admin,Cashier")]` — nhân viên |
| `POST`, `PUT`, `DELETE` | `[Authorize(Roles = "Admin")]` — chỉ Admin được ghi/xoá |

> Endpoint demo `admin-dashboard` và `staff-pos` chỉ còn ở `CategoriesController`. Bản sao ở `CustomersController` đã bị xoá vì URL `/api/customers/staff-pos` gây hiểu nhầm là màn hình POS của khách hàng.

> Khóa bí mật JWT lấy từ `appsettings.json` → `JwtSettings:Secret`, token sống **2 giờ**.

> **Lưu ý:** `AuthController` hiện đang kiểm tra tài khoản **hardcode** trong code. Buổi sau sẽ chuyển sang truy vấn bảng `Users` trong SQL Server.

---

## 6. Danh sách Endpoint

> Tất cả endpoint (trừ `Auth`) đều yêu cầu `Bearer Token`.

### 6.1. Auth — `/api/auth`

| Phương thức | Đường dẫn | Chức năng |
|---|---|---|
| `POST` | `/api/auth/login` | Đăng nhập, trả về JWT + Role |

### 6.2. Categories — `/api/categories`

| Phương thức | Đường dẫn | Chức năng |
|---|---|---|
| `GET` | `/api/categories` | Lấy toàn bộ danh sách |
| `GET` | `/api/categories/{id}` | Lấy chi tiết theo ID |
| `GET` | `/api/categories/search?keyword=...` | Tìm kiếm theo từ khoá |
| `GET` | `/api/categories/admin-dashboard` | Chỉ Admin |
| `GET` | `/api/categories/staff-pos` | Nhân viên (Admin, Cashier) |
| `POST` | `/api/categories` | Thêm mới *(Admin)* |
| `PUT` | `/api/categories/{id}` | Cập nhật *(Admin)* |
| `DELETE` | `/api/categories/{id}` | Xóa *(Admin)* |

> Khi xoá nhóm món đang có sản phẩm liên kết, SQL Server chặn xoá do ràng buộc khoá ngoại → API trả **400 Bad Request** kèm thông báo thân thiện.

### 6.3. Customers — `/api/customers` (MỚI Ở Buổi 3)

| Phương thức | Đường dẫn | Chức năng |
|---|---|---|
| `GET` | `/api/customers` | Lấy toàn bộ danh sách |
| `GET` | `/api/customers/{id}` | Lấy chi tiết theo ID |
| `GET` | `/api/customers/search?keyword=...` | Tìm theo **tên** hoặc **số điện thoại** |
| `POST` | `/api/customers` | Thêm khách hàng *(Admin)* |
| `PUT` | `/api/customers/{id}` | Cập nhật *(Admin)* |
| `DELETE` | `/api/customers/{id}` | Xóa *(Admin)* |

**Điểm nhấn kỹ thuật:** `Search` dùng `Contains`, EF Core tự dịch thành câu `SQL LIKE` — không cần viết SQL thủ công:

```csharp
var result = await _context.Customers
    .Where(c => c.CustomerName.Contains(keyword) || c.PhoneNumber.Contains(keyword))
    .ToListAsync();
```

Các action đọc dữ liệu dùng `AsNoTracking()` vì chỉ đọc, không cần EF Core theo dõi thay đổi → tiết kiệm bộ nhớ.

### 6.4. Roles — `/api/roles`

| Phương thức | Đường dẫn | Chức năng |
|---|---|---|
| `GET` | `/api/roles` | Lấy toàn bộ danh sách |
| `GET` | `/api/roles/{id}` | Lấy chi tiết theo ID |
| `POST` | `/api/roles` | Thêm mới |
| `PUT` | `/api/roles/{id}` | Cập nhật |
| `DELETE` | `/api/roles/{id}` | Xóa |

### 6.5. Swagger UI (có nút Authorize)

Trong `Program.cs`, gói `Swashbuckle.AspNetCore` đã được cấu hình **Security Definition Bearer**, nên Swagger hiển thị nút **Authorize** (ổ khóa) để dán token:

```
Authorization
Bearer eyJhbGciOi...
```

Truy cập: `https://localhost:7065/swagger`

**Kịch bản kiểm chứng trên Swagger:**

1. Gọi `GET /api/customers` khi chưa đăng nhập → **401 Unauthorized**.
2. `POST /api/auth/login` với `cashier/123456` → copy token.
3. Bấm **Authorize**, dán `Bearer <token>` → `GET /api/categories/staff-pos` → **200 OK**; `GET /api/categories/admin-dashboard` → **403 Forbidden**.
4. `GET /api/customers` trả về đúng **15 bản ghi**, `GET /api/categories` trả về **15 nhóm món** — chứng minh dữ liệu đã nằm trong SQL Server, không còn là `static List`.

---

## 7. Frontend (WinForms)

### 7.1. `FormLogin` — Đăng nhập & quản lý phiên

- TextBox `txtUser` (tài khoản), `txtPass` (`UseSystemPasswordChar = true` để ẩn mật khẩu), Button `btnLogin`.
- Gọi `ApiClientService.LoginAsync()` → lưu token vào **SessionManager** → mở `FormCategoryManagement`.
- `Program.cs` khởi chạy `FormLogin` đầu tiên.

### 7.2. `SessionManager` — Phiên làm việc

```csharp
public static string JwtToken { get; set; }     // Token nhận từ Server
public static string CurrentRole { get; set; }  // Vai trò người dùng (Admin/Cashier)
```

### 7.3. Gọi API đính kèm Bearer Token

`ApiClientService` (Login, GET có token) và phương thức `GetAuthenticatedClient()` trong các form quản lý:

```csharp
private HttpClient GetAuthenticatedClient()
{
    var client = new HttpClient { BaseAddress = new Uri("https://localhost:7065/api/") };
    if (!string.IsNullOrEmpty(SessionManager.JwtToken))
    {
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
    }
    return client;
}
```

### 7.4. `FormCategoryManagement` — Quản lý nhóm món

- `DataGridView dgvCategories`: hiển thị danh sách.
- Nút lệnh: `btnLoad`, `btnAdd`, `btnUpdate`, `btnDelete`, `btnSearch`.
- Nút **"Quản lý vai trò"** mở `FormRoleManagement`.
- Nút **"Quản lý khách hàng"** (mới) mở `FormCustomerManagement`:

```csharp
private void btnOpenCustomers_Click(object sender, EventArgs e)
{
    var formCustomer = new FormCustomerManagement();
    formCustomer.ShowDialog(this);
}
```

### 7.5. `FormCustomerManagement` — Quản lý khách hàng (MỚI Ở Buổi 3)

| Thành phần | Chi tiết |
|---|---|
| `DataGridView` | `dgvCustomers` — 6 cột: `CustomerId`, `CustomerName`, `PhoneNumber`, `Address`, `RewardPoints`, `MembershipRank` |
| TextBox | `txtCustomerId`, `txtCustomerName`, `txtPhoneNumber`, `txtAddress`, `txtRewardPoints`, `txtKeyword` |
| ComboBox | `cboMembershipRank` — chọn hạng thẻ (Chuẩn / Bạc / Vàng) |
| Nút lệnh | `btnLoad`, `btnAdd`, `btnUpdate`, `btnDelete`, `btnSearch` |

Đặc điểm xử lý:

- **Tự động tải dữ liệu** ngay khi Form mở (`FormCustomerManagement_Load` → `LoadCustomersAsync()`).
- **Click vào dòng** trên `DataGridView` sẽ đổ dữ liệu lên các ô nhập để chuẩn bị Sửa/Xóa (`dgvCustomers_CellClick`).
- **Validate phía Client**: kiểm tra rỗng tên/SĐT, và `TryGetRewardPoints()` bắt lỗi nếu điểm tích luỹ không phải số nguyên.
- **Xác nhận trước khi xoá**: `MessageBox` hỏi lại người dùng.
- **Tìm kiếm**: `Uri.EscapeDataString(keyword)` để mã hoá ký tự đặc biệt, tránh lỗi URL. Nếu `keyword` trống → tải lại toàn bộ danh sách.
- **Phân biệt lỗi 401/403** với "không tìm thấy kết quả" trong `btnSearch_Click`, tránh báo nhầm cho người dùng.

### 7.6. `FormRoleManagement` — Quản lý vai trò (Bài tập mở rộng)

- `DataGridView dgvRoles`; TextBox `txtId`, `txtRoleName`, `txtDescription`; nút `btnLoad`, `btnAdd`, `btnUpdate`, `btnDelete`.

---

## 8. Hướng dẫn chạy

> **Yêu cầu:** .NET 8 SDK, SQL Server (Local hoặc Express), Visual Studio 2022 hoặc `dotnet` CLI.
> Chứng chỉ HTTPS phát triển: `dotnet dev-certs https --trust`.

### Bước 0 — Chuẩn bị cơ sở dữ liệu

Mở **SQL Server Management Studio**, đăng nhập bằng tài khoản `sa` / `123456`, rồi chạy:

```sql
CREATE DATABASE NgocLauDb;
```

Sau đó áp dụng migration để EF Core tự tạo bảng & nạp dữ liệu mẫu:

```bash
dotnet ef database update --project API
```

> Bảng `Categories`, `Products`, `Customers` và dữ liệu mẫu sẽ được tạo tự động — không cần tạo tay.

### Cách 1: Visual Studio (khuyến nghị)

1. Mở Solution `Lau_Market.sln`.
2. Đặt 2 project cùng khởi chạy: `API` + `FE` (Startup Project).
3. Nhấn **F5**.
4. API mở Swagger (có nút Authorize); WinForms mở **FormLogin**.

### Cách 2: dòng lệnh

```bash
# Terminal 1 - chạy Backend (HTTPS)
dotnet run --project API --launch-profile https

# Terminal 2 - chạy Frontend
dotnet run --project FE
```

### Trình tự kiểm thử

1. **Kiểm tra DB**: mở SSMS, truy vấn `SELECT COUNT(*) FROM Customers;`, `FROM Categories;`, `FROM Products;` → mỗi bảng phải trả về **15**.
2. **Kiểm tra Swagger**: gọi `/api/customers` không token → 401; login `admin/123456` → lấy token; bấm Authorize dán `Bearer <token>`; thử `/api/categories/staff-pos` (200) và `/api/categories/admin-dashboard`.
3. **Kiểm tra WinForms**: đăng nhập bằng `cashier/123456` → mở form quản lý nhóm món → bấm nút **"Quản lý khách hàng"** → thử Thêm / Sửa / Xóa / Tìm kiếm.
4. **Kiểm tra phân quyền**: đăng nhập bằng `cashier/123456` rồi thử Thêm khách hàng → API trả **403 Forbidden**; đổi sang `admin/123456` → thành công.

---

## 9. Ghi chú

- **Cổng mặc định:** Backend HTTPS `7065`, HTTP `5207`. Nếu đổi port, cập nhật `BaseAddress` tại `ApiClientService` và `GetAuthenticatedClient()` của các form.
- **Khóa bí mật JWT** đặt tại `appsettings.json` (`JwtSettings:Secret`); thời hạn token **2 giờ** trong `AuthController.GenerateJwtToken`.
- **Mật khẩu SQL Server** nằm trong `appsettings.json` — phù hợp với môi trường học tập; khi triển khai thật cần dùng biến môi trường hoặc Secret Manager.
- `RolesController` vẫn dùng `static List` (In-Memory) — sẽ chuyển sang SQL Server khi có bảng `Users`.
- Khi thêm/xoá endpoint, cần **Restart ứng dụng** (không dùng Hot Reload) để Swagger cập nhật lại danh sách route.

### Kế hoạch Buổi 4

- CRUD `Products` (Controller + Màn hình WinForms quản lý sản phẩm & tồn kho).
- Tích hợp `AuthController` với bảng `Users` trong SQL Server (thay hardcode).
- Bảng `Orders` + `OrderDetails` cho nghiệp vụ bán hàng tại quầy POS.

---

## 10. Tổng kết kiến thức Buổi 3

- **Entity Framework Core**: ánh xạ Model (C# class) ↔ Bảng (SQL Server) thông qua `DbContext`, `DbSet<T>`, `OnConfiguring`/`OnModelCreating`.
- **Code First & Migration**: `dotnet ef migrations add` sinh mã tạo/cập nhật bảng; `dotnet ef database update` áp dụng lên CSDL thật.
- **Data Seeding**: `modelBuilder.Entity<T>().HasData(...)` nạp sẵn dữ liệu mẫu, thuận tiện cho bài tập/demo.
- **Quan hệ 1-N**: `ICollection<T>` + `[ForeignKey]` + navigation property; cần `[JsonIgnore]` để tránh lỗi serialize lặp vòng vô tận.
- **LINQ → SQL**: biểu thức `Where/Select/Contains` được EF Core dịch tự động thành câu SQL tối ưu.
- **Ràng buộc khoá ngoại trong nghiệp vụ**: bắt lỗi từ SQL Server và trả về thông báo thân thiện cho Client thay vì lỗi 500.
- **DI cho DbContext**: đăng ký một lần bằng `AddDbContext` trong `Program.cs`, controller nhận qua Constructor Injection — dễ thay đổi nguồn dữ liệu về sau.