using System.Security.Cryptography;
using System.Text;

namespace API.Helpers
{
    // Băm mật khẩu bằng SHA-256 trước khi lưu/so sánh trong CSDL
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            using var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        public static bool Verify(string password, string passwordHash)
        {
            return string.Equals(Hash(password), passwordHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
