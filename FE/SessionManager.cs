namespace FE
{
    public static class SessionManager
    {
        // Lưu trữ JWT Token nhận từ Server
        public static string JwtToken { get; set; } = string.Empty;

        // Lưu trữ vai trò người dùng (Admin / Cashier) để phân quyền giao diện
        public static string CurrentRole { get; set; } = string.Empty;
    }
}