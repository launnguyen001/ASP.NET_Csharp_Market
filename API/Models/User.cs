using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được trống")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        // Mật khẩu được lưu dưới dạng chuỗi băm SHA-256 (không lưu plain text)
        [Required]
        [StringLength(64)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ và tên không được trống")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        // Vai trò phân quyền: Admin / Cashier / Warehouse
        [Required]
        [StringLength(20)]
        public string Role { get; set; } = string.Empty;

        // Trạng thái tài khoản: true = đang hoạt động, false = bị khóa
        public bool IsActive { get; set; } = true;
    }
}
