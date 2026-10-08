using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace FE
{
    public static class ApiClientService
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7065/api/") // nhớ chỉnh port phù hợp
        };

        // HttpClient dùng chung cho các Form con (FormPOS, FormProductManagement, ...)
        // Tự động mang Bearer Token sau khi đăng nhập thành công
        public static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7065/api/")
        };

        // Hàm gọi API đăng nhập lấy Token
        public static async Task<bool> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await _client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);
                SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                SessionManager.CurrentUsername = doc.RootElement.TryGetProperty("username", out var u) ? u.GetString() ?? username : username;
                SessionManager.CurrentFullName = doc.RootElement.TryGetProperty("fullName", out var f) ? f.GetString() ?? username : username;

                // Gắn Bearer Token vào HttpClient dùng chung cho toàn bộ Form con
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
                return true;
            }
            return false;
        }

        // Hàm xóa phiên đăng xuất trên HttpClient dùng chung
        public static void ClearSession()
        {
            SessionManager.Clear();
            Client.DefaultRequestHeaders.Authorization = null;
            _client.DefaultRequestHeaders.Authorization = null;
        }

        // Hàm gọi API lấy dữ liệu có gắn kèm Bearer Token bảo mật
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            var response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Phiên làm việc hết hạn hoặc chưa đăng nhập!");
            }
            throw new Exception("Lỗi khi gọi dữ liệu từ Server.");
        }

        // Hàm dịch lỗi ngoại lệ (từ GetFromJsonAsync...) thành thông báo thân thiện
        public static string GetErrorMessage(Exception ex)
        {
            if (ex is HttpRequestException httpEx)
            {
                if (httpEx.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    return $"Không đủ quyền truy cập! Vai trò hiện tại: {SessionManager.CurrentRole}. Chức năng này chỉ dành cho Admin.";
                }
                if (httpEx.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return "Phiên làm việc hết hạn hoặc chưa đăng nhập!";
                }
            }
            return "Lỗi kết nối Server: " + ex.Message;
        }

        // Hàm dịch mã trạng thái phản hồi (dùng cho POST/PUT/DELETE trả về thất bại)
        public static string GetResponseMessage(HttpResponseMessage response, string fallback)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                return $"Không đủ quyền truy cập! Vai trò hiện tại: {SessionManager.CurrentRole}. Chức năng này chỉ dành cho Admin.";
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return "Phiên làm việc hết hạn hoặc chưa đăng nhập!";
            }
            return fallback;
        }
    }
}