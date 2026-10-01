using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key] // Khóa chính, tự tăng IDENTITY(1,1)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Tên khách hàng không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên khách hàng không vượt quá 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [StringLength(15, ErrorMessage = "Số điện thoại không vượt quá 15 ký tự")]
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Địa chỉ không vượt quá 200 ký tự")]
        [Column(TypeName = "nvarchar(200)")]
        public string? Address { get; set; }

        // Điểm tích lũy mặc định là 0
        public int RewardPoints { get; set; }

        // Hạng thẻ mặc định là 'Chuẩn'
        [StringLength(50, ErrorMessage = "Hạng thẻ không vượt quá 50 ký tự")]
        [Column(TypeName = "nvarchar(50)")]
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}