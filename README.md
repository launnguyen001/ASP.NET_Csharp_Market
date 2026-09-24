# Hệ Thống Quản Lý Siêu Thị Mini (Mini Supermarket System)

**Sinh viên:** Nguyễn Ngọc Lầu — **MSSV:** 2124110129
**Lớp:** CCQ2411D

**Đồ án môn:** Lập trình Ứng dụng .NET Core

**Branch:** `buoi_2` — Bảo mật & Phân quyền JWT cho Web API

---

## 1. Giới thiệu

Xây dựng hệ thống **Quản lý Bán lẻ & Tồn kho Siêu thị Mini** theo mô hình phân tầng **Client - Server**:

- **Backend (Web API):** xử lý nghiệp vụ, quản lý dữ liệu, xác thực JWT.
- **Frontend (WinForms):** giao diện người dùng, giao tiếp với Backend qua `HttpClient`.

Ở buổi 2, hệ thống được nâng cấp với cơ chế **Bảo mật JWT (Stateless Authentication)** và **Phân quyền** giữa các nhóm người dùng (Admin, Cashier). Dữ liệu vẫn lưu **In-Memory (RAM)** phục vụ học tập, sẵn sàng chuyển sang SQL Server + EF Core ở buổi 3.

---

## 2. Kiến trúc Solution

```
Lau_Market
├── API/                     # Backend: ASP.NET Core Web API (.NET 8)
│   ├── Controllers/
│   │   ├── AuthController.cs           # Đăng nhập & cấp phát JWT Token
│   │   ├── CategoriesController.cs     # CRUD + Tìm kiếm + Endpoint phân quyền
│   │   └── RolesController.cs          # CRUD vai trò (bài tập mở rộng)
│   ├── Models/
│   │   ├── Category.cs                 # Nhóm hàng hóa
│   │   └── Role.cs                     # Vai trò nhân viên
│   ├── appsettings.json                # Chứa JwtSettings:Secret
│   ├── Program.cs                      # Cấu hình JwtBearer, Swagger + nút Authorize
│   └── Properties/launchSettings.json
└── FE/                      # Frontend: Windows Forms (.NET 8)
    ├── FormLogin.*                     # Màn hình đăng nhập (khởi chạy đầu tiên)
    ├── FormCategoryManagement.*        # Quản lý nhóm hàng (CRUD + Tìm kiếm)
    ├── FormRoleManagement.*            # Quản lý vai trò (bài tập mở rộng)
    ├── SessionManager.cs               # Lưu JWT Token & Role dùng chung
    ├── ApiClientService.cs             # Login + gọi API đính kèm Bearer Token
    └── Program.cs                      # Điểm khởi chạy (mở FormLogin trước)
```

---

## 3. Bảo mật JWT & Phân quyền (Thay đổi Buổi 2)

### 3.1. Xác thực không trạng thái (Stateless Authentication)

- Server **không lưu Session** trên RAM; toàn bộ định danh (Username, Role) được mã hóa thành **JWT Token** và giao cho Client lưu trữ.
- JWT gồm 3 phần: **Header** (thuật toán HS256), **Payload** (Claims), **Signature** (chữ ký bằng `SymmetricSecurityKey`).

Tài khoản mẫu để đăng nhập:

| Tài khoản | Mật khẩu | Vai trò (Role) | Quyền hạn |
|---|---|---|---|
| `admin` | `123456` | Admin | Toàn quyền thao tác |
| `cashier` | `123456` | Cashier | Bán hàng / truy cập dữ liệu |

### 3.2. Luồng hoạt động

1. WinForms mở **FormLogin** → gọi `POST /api/auth/login` lấy JWT.
2. Token & Role được lưu vào lớp tĩnh **SessionManager**.
3. Mọi request sau đó (GET/POST/PUT/DELETE) đều đính kèm header `Authorization: Bearer <token>` qua `GetAuthenticatedClient()` / `ApiClientService`.
4. Server kiểm tra chữ ký JWT; nếu hợp lệ mới cho truy cập, sau đó kiểm tra Role theo `[Authorize(Roles = ...)]`.

### 3.3. Bảo vệ API

- `AuthController` — không cần token (endpoint công khai).
- `CategoriesController`, `RolesController` — gắn `[Authorize]` (phải có token hợp lệ).
- `GET /api/categories/admin-dashboard` — `[Authorize(Roles = "Admin")]` (chỉ Admin).
- `GET /api/categories/staff-pos` — `[Authorize(Roles = "Admin,Cashier")]` (nhân viên).
- Khóa bí mật JWT lấy từ `appsettings.json` → `JwtSettings:Secret`, token sống **2 giờ**.

---

## 4. Backend (Web API)

### 4.1. Model `Category` — Nhóm hàng hóa

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `CategoryId` | `int` | Mã định danh (Khóa chính) |
| `CategoryName` | `string` | Tên nhóm hàng (bắt buộc) |
| `Description` | `string?` | Mô tả chi tiết (có thể trống) |

### 4.2. Model `Role` — Vai trò nhân viên

| Thuộc tính | Kiểu | Mô tả |
|---|---|---|
| `Id` | `int` | Mã định danh vai trò (Khóa chính) |
| `RoleName` | `string` | Tên vai trò (Ví dụ: Admin, Cashier, Warehouse) |
| `Description` | `string?` | Mô tả chức năng của vai trò |

### 4.3. Các Endpoint (đều yêu cầu Bearer Token, trừ Auth)

**Auth — `/api/auth`**

| Phương thức | Đường dẫn | Chức năng |
|---|---|---|
| `POST` | `/api/auth/login` | Đăng nhập, trả về JWT + Role |

**Categories — `/api/categories`**

| Phương thức | Đường dẫn | Chức năng |
|---|---|---|
| `GET` | `/api/categories` | Lấy toàn bộ danh sách |
| `GET` | `/api/categories/{id}` | Lấy chi tiết theo ID |
| `GET` | `/api/categories/search?keyword=...` | Tìm kiếm theo từ khóa |
| `GET` | `/api/categories/staff-pos` | Nhân viên (Admin, Cashier) |
| `GET` | `/api/categories/admin-dashboard` | Chỉ Admin |
| `POST` | `/api/categories` | Thêm mới |
| `PUT` | `/api/categories/{id}` | Cập nhật |
| `DELETE` | `/api/categories/{id}` | Xóa |

**Roles — `/api/roles`**

| Phương thức | Đường dẫn | Chức năng |
|---|---|---|
| `GET` | `/api/roles` | Lấy toàn bộ danh sách |
| `GET` | `/api/roles/{id}` | Lấy chi tiết theo ID |
| `POST` | `/api/roles` | Thêm mới |
| `PUT` | `/api/roles/{id}` | Cập nhật |
| `DELETE` | `/api/roles/{id}` | Xóa |

### 4.4. Swagger UI (có nút Authorize)

Trong `Program.cs` gói `Swashbuckle.AspNetCore` đã được cấu hình **Security Definition Bearer**, nên Swagger hiển thị nút **Authorize** (ổ khóa) để dán token:

```
Authorization
Bearer eyJhbGciOi...
```

Truy cập: `https://localhost:7065/swagger`

**Kịch bản kiểm chứng trên Swagger:**

1. Gọi `GET /api/categories` khi chưa đăng nhập → **401 Unauthorized**.
2. `POST /api/auth/login` với `cashier/123456` → copy token.
3. Bấm Authorize, dán `Bearer <token>` → gọi `GET /api/categories/staff-pos` → **200 OK**; gọi `GET /api/categories/admin-dashboard` → **403 Forbidden**.

---

## 5. Frontend (WinForms)

### 5.1. `FormLogin` — Đăng nhập & quản lý phiên

- TextBox `txtUser` (tài khoản), `txtPass` (`UseSystemPasswordChar = true` để ẩn mật khẩu), Button `btnLogin`.
- Gọi `ApiClientService.LoginAsync()` → lưu token vào **SessionManager** → mở `FormCategoryManagement`.
- `Program.cs` khởi chạy `FormLogin` đầu tiên.

### 5.2. `SessionManager` — Phiên làm việc

```csharp
public static string JwtToken { get; set; }   // Token nhận từ Server
public static string CurrentRole { get; set; } // Vai trò người dùng (Admin/Cashier)
```

### 5.3. Gọi API đính kèm Bearer Token

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

### 5.4. `FormCategoryManagement` — Quản lý nhóm hàng

- `DataGridView dgvCategories`: hiển thị danh sách (3 cột `CategoryId`, `CategoryName`, `Description`).
- TextBox: `txtId`, `txtCategoryName`, `txtDescription`, `txtKeyword`.
- Nút lệnh: `btnLoad`, `btnAdd`, `btnUpdate`, `btnDelete`, `btnSearch`.
- Mọi request dùng `GetAuthenticatedClient()` để gắn token.
- Nút "Quản lý vai trò" mở `FormRoleManagement`.

### 5.5. `FormRoleManagement` — Quản lý vai trò (Bài tập mở rộng)

- `DataGridView dgvRoles`: hiển thị (3 cột `Id`, `RoleName`, `Description`).
- TextBox: `txtId`, `txtRoleName`, `txtDescription`; nút `btnLoad`, `btnAdd`, `btnUpdate`, `btnDelete`.
- Tương tác qua `GetAuthenticatedClient()` tới `/api/roles`.

---

## 6. Hướng dẫn chạy

> Yêu cầu: **.NET 8 SDK**, Visual Studio 2022 (hoặc `dotnet` CLI). Chứng chỉ HTTPS phát triển đã tin cậy (`dotnet dev-certs https --trust`).

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

1. Trên Swagger: gọi `/api/categories` không token → 401; login `admin/123456` hoặc `cashier/123456` → lấy token; bấm Authorize dán `Bearer <token>`; thử `staff-pos` (200) và `admin-dashboard` (403 với cashier, 200 với admin).
2. Trên WinForms: đăng nhập bằng `cashier/123456` → mở form quản lý nhóm hàng, thực hiện Thêm/Sửa/Xóa/Tìm kiếm.

---

## 7. Ghi chú

- Dữ liệu hiện lưu **In-Memory** (`static List`), sẽ mất khi khởi động lại API.
- Port mặc định Backend: **HTTPS `7065`**, HTTP `5207`. Nếu đổi port, cập nhật `BaseAddress` tại `ApiClientService` và `GetAuthenticatedClient()` của các form.
- Khóa bí mật JWT đặt tại `appsettings.json` (`JwtSettings:Secret`); thời hạn token mặc định **2 giờ** trong `AuthController.GenerateJwtToken`.
- Buổi tiếp theo (Buổi 3): tích hợp **SQL Server + Entity Framework Core** (bảng Users, Categories, Products, Customers, Orders, OrderDetails) và Migrations.

---

## 8. Tổng kết kiến thức Buổi 2

- **Authentication vs Authorization**: xác định danh tính người dùng và kiểm tra quyền truy cập tài nguyên.
- **Stateless JWT**: Server ký token bằng khóa bí mật, không lưu Session; Client xuất trình `Authorization: Bearer <token>` ở mỗi request.
- **Data Annotations & ModelState**: `[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]`... với `[ApiController]` tự động trả 400 BadRequest.
- **Action Filters / [Authorize]**: bảo vệ endpoint; phân quyền theo Role (Admin, Cashier).