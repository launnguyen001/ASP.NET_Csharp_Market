namespace FE
{
    public static class SessionManager
    {
        // Lưu trữ JWT Token nhận từ Server
        public static string JwtToken { get; set; } = string.Empty;

        // Lưu trữ vai trò người dùng (Admin / Cashier / Warehouse) để phân quyền giao diện
        public static string CurrentRole { get; set; } = string.Empty;

        // Lưu trữ tên đăng nhập của phiên làm việc hiện tại (dùng cho hóa đơn POS)
        public static string CurrentUsername { get; set; } = string.Empty;

        // Lưu trữ họ và tên nhân viên (hiển thị trên header / sidebar)
        public static string CurrentFullName { get; set; } = string.Empty;

        // Kiểm tra xem phiên làm việc đã đăng nhập hay chưa
        public static bool IsAuthenticated => !string.IsNullOrEmpty(JwtToken);

        // Xóa toàn bộ dữ liệu phiên khi đăng xuất
        public static void Clear()
        {
            JwtToken = string.Empty;
            CurrentRole = string.Empty;
            CurrentUsername = string.Empty;
            CurrentFullName = string.Empty;
        }
    }
}
