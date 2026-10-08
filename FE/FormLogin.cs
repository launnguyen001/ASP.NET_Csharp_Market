namespace FE
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        // Sự kiện khi người dùng bấm nút Đăng nhập
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // Kiểm tra ràng buộc cơ bản phía Client
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gọi API POST /api/auth/login để lấy Token và lưu vào SessionManager
                LoginResult result = await ApiClientService.LoginAsync(username, password);

                if (result.Success)
                {
                    MessageBox.Show($"Đăng nhập thành công với quyền: {SessionManager.CurrentRole}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở màn hình điều khiển trung tâm FormMainShell (khung đơn Single-Form)
                    // Khi người dùng đăng xuất, ShowDialog trả về và hiện lại form đăng nhập
                    using (FormMainShell shell = new FormMainShell())
                    {
                        this.Hide();
                        shell.ShowDialog();
                    }

                    // Quay lại đây nghĩa là phiên làm việc đã kết thúc (đăng xuất)
                    // → Dọn dẹp và sẵn sàng cho lần đăng nhập tiếp theo
                    ApiClientService.ClearSession();
                    txtPass.Clear();
                    txtUser.Focus();
                    this.Show();
                }
                else
                {
                    // Hiển thị đúng lý do do Server trả về (sai mật khẩu, tài khoản bị khóa...)
                    MessageBox.Show(result.ErrorMessage, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến Server: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}