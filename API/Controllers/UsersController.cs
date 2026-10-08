using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Helpers;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bắt buộc phải có Token mới gọi được các API trong Controller này
    public class UsersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public UsersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // DTO trả về cho Client: tuyệt đối không lộ PasswordHash
        private static UserDto ToDto(User u) => new UserDto
        {
            Id = u.UserId,
            Username = u.Username,
            FullName = u.FullName,
            Email = u.Email,
            Role = u.Role,
            IsActive = u.IsActive
        };

        // 1. READ: Lấy toàn bộ tài khoản nhân viên (GET /api/users) - Chỉ Admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Users.AsNoTracking().OrderBy(u => u.UserId).ToListAsync();
            return Ok(list.Select(ToDto));
        }

        // 2. READ: Lấy chi tiết một tài khoản theo ID (GET /api/users/{id}) - Chỉ Admin
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản trong CSDL!" });
            }
            return Ok(ToDto(user));
        }

        // 3. CREATE: Tạo tài khoản nhân viên mới (POST /api/users) - Chỉ Admin
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Tên đăng nhập và mật khẩu không được để trống!" });
            }

            var validRoles = new[] { "Admin", "Cashier", "Warehouse" };
            var role = string.IsNullOrWhiteSpace(request.Role) ? "Cashier" : request.Role.Trim();
            if (!validRoles.Contains(role, StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest(new { message = "Vai trò không hợp lệ! Chỉ chấp nhận: Admin, Cashier, Warehouse." });
            }

            // Kiểm tra tên đăng nhập trùng lặp
            bool exists = await _context.Users.AnyAsync(u => u.Username == request.Username.Trim());
            if (exists)
            {
                return Conflict(new { message = "Tên đăng nhập đã tồn tại!" });
            }

            var user = new User
            {
                Username = request.Username.Trim(),
                PasswordHash = PasswordHasher.Hash(request.Password),
                FullName = string.IsNullOrWhiteSpace(request.FullName) ? request.Username.Trim() : request.FullName.Trim(),
                Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim(),
                Role = char.ToUpper(role[0]) + role[1..].ToLower(),
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, ToDto(user));
        }

        // 4. RESET: Đặt lại mật khẩu cho tài khoản (PUT /api/users/{id}/reset-password) - Chỉ Admin
        [HttpPut("{id}/reset-password")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ResetPassword(int id, [FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                return BadRequest(new { message = "Mật khẩu mới không được để trống!" });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản cần đặt lại mật khẩu!" });
            }

            user.PasswordHash = PasswordHasher.Hash(request.NewPassword);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 5. LOCK: Khóa / mở khóa tài khoản (PUT /api/users/{id}/toggle-lock) - Chỉ Admin
        [HttpPut("{id}/toggle-lock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleLock(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản!" });
            }

            // Không cho phép tự khóa chính mình đang đăng nhập
            var currentUsername = User.Identity?.Name;
            if (user.Username == currentUsername && user.IsActive)
            {
                return BadRequest(new { message = "Bạn không thể khóa chính tài khoản đang đăng nhập!" });
            }

            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();

            return Ok(new { isActive = user.IsActive, message = user.IsActive ? "Đã mở khóa tài khoản." : "Đã khóa tài khoản." });
        }

        // 6. UPDATE: Đổi vai trò / thông tin tài khoản (PUT /api/users/{id}) - Chỉ Admin
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản cần sửa!" });
            }

            var validRoles = new[] { "Admin", "Cashier", "Warehouse" };
            if (!string.IsNullOrWhiteSpace(request.Role) && !validRoles.Contains(request.Role.Trim(), StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest(new { message = "Vai trò không hợp lệ! Chỉ chấp nhận: Admin, Cashier, Warehouse." });
            }

            if (!string.IsNullOrWhiteSpace(request.FullName))
            {
                user.FullName = request.FullName.Trim();
            }
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                user.Email = request.Email.Trim();
            }
            if (!string.IsNullOrWhiteSpace(request.Role))
            {
                var role = request.Role.Trim();
                user.Role = char.ToUpper(role[0]) + role[1..].ToLower();
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 7. DELETE: Xóa vĩnh viễn tài khoản (DELETE /api/users/{id}) - Chỉ Admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản cần xóa!" });
            }

            if (user.Username == User.Identity?.Name)
            {
                return BadRequest(new { message = "Không thể xóa chính tài khoản đang đăng nhập!" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    // DTO đầu vào tạo tài khoản mới
    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }

    public class UpdateUserRequest
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string NewPassword { get; set; } = string.Empty;
    }

    // DTO trả về phía Client (không chứa PasswordHash)
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
