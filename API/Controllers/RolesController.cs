using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")] // Định tuyến: /api/roles
    [ApiController]
    [Authorize] // Bắt buộc phải có Token mới gọi được các API trong Controller này
    public class RolesController : ControllerBase
    {
        // Dữ liệu mẫu lưu tạm trên RAM phục vụ kiểm thử
        private static readonly List<Role> _roles = new() {
            new Role { Id = 1, RoleName = "Admin", Description = "Quản trị viên toàn hệ thống, toàn quyền thao tác" },
            new Role { Id = 2, RoleName = "Cashier", Description = "Nhân viên thu ngân, chuyên trách bán hàng tại quầy POS" },
            new Role { Id = 3, RoleName = "Warehouse", Description = "Nhân viên quản lý kho, nhập hàng và kiểm kê" }
        };

        // 1. READ: Lấy toàn bộ danh sách vai trò (GET /api/roles)
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_roles);
        }

        // 2. READ: Lấy chi tiết một vai trò theo ID (GET /api/roles/{id})
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            var role = _roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy vai trò!" });
            }
            return Ok(role);
        }

        // 3. CREATE: Thêm mới vai trò (POST /api/roles)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] Role newRole)
        {
            if (string.IsNullOrWhiteSpace(newRole.RoleName))
            {
                return BadRequest(new { message = "Tên vai trò không được để trống!" });
            }
            // Tự động tăng ID
            newRole.Id = _roles.Count > 0 ? _roles.Max(r => r.Id) + 1 : 1;
            _roles.Add(newRole);

            return CreatedAtAction(nameof(GetById), new { id = newRole.Id }, newRole);
        }

        // 4. UPDATE: Cập nhật thông tin vai trò (PUT /api/roles/{id})
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] Role updateRole)
        {
            var role = _roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy vai trò cần sửa!" });
            }

            role.RoleName = updateRole.RoleName;
            role.Description = updateRole.Description;

            return NoContent();
        }

        // 5. DELETE: Xóa vai trò theo ID (DELETE /api/roles/{id})
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var role = _roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy vai trò cần xóa!" });
            }

            _roles.Remove(role);
            return NoContent();
        }
    }
}