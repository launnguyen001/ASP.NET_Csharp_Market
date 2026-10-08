using System.Net.Http.Json;

namespace FE
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
            SetupUserGrid();
            cboRole.Items.AddRange(new string[] { "Admin", "Cashier", "Warehouse" });
            cboRole.SelectedIndex = 1; // Mặc định = Cashier
        }

        // Cấu hình các cột của bảng tài khoản
        private void SetupUserGrid()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();
            // Name = DataPropertyName để row.Cells["Id"] tra cứu được (Name mới là khóa tra cứu)
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "Mã", Width = 45 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", DataPropertyName = "Username", HeaderText = "Tên đăng nhập", Width = 115 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", DataPropertyName = "FullName", HeaderText = "Họ và tên", Width = 150 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", DataPropertyName = "Email", HeaderText = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role", DataPropertyName = "Role", HeaderText = "Vai trò", Width = 90 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "IsActive", DataPropertyName = "IsActive", HeaderText = "Hoạt động", Width = 85 });
        }

        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        // Nạp danh sách tài khoản lên bảng
        private async Task LoadUsersAsync()
        {
            try
            {
                var users = await ApiClientService.Client.GetFromJsonAsync<List<UserDto>>("users") ?? new List<UserDto>();
                dgvUsers.DataSource = users;
                lblUserCount.Text = $"Tổng: {users.Count} tài khoản";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi lấy danh sách tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Click dòng trên bảng → hiển thị trạng thái ở khu vực thao tác
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            lblSelectedUser.Text = $"Đang chọn: {row.Cells["Username"].Value} - {row.Cells["FullName"].Value}";
            cboRole.Text = row.Cells["Role"].Value?.ToString() ?? "Cashier";
        }

        // Nút TẠO TÀI KHOẢN MỚI (POST /api/users)
        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier"
            };

            try
            {
                var res = await ApiClientService.Client.PostAsJsonAsync("users", newUser);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(await ReadErrorMessageAsync(res, "Tạo tài khoản thất bại!"), "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút ĐẶT LẠI MẬT KHẨU (PUT /api/users/{id}/reset-password)
        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            int id = GetSelectedUserId();
            if (id <= 0) return;

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Hãy nhập mật khẩu mới vào ô Mật khẩu trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            var confirm = MessageBox.Show($"Đặt lại mật khẩu cho tài khoản ID = {id}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var res = await ApiClientService.Client.PutAsJsonAsync($"users/{id}/reset-password",
                    new { NewPassword = txtPassword.Text.Trim() });
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(await ReadErrorMessageAsync(res, "Đặt lại mật khẩu thất bại!"), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút KHÓA / MỞ KHÓA (PUT /api/users/{id}/toggle-lock)
        private async void btnToggleLock_Click(object sender, EventArgs e)
        {
            int id = GetSelectedUserId();
            if (id <= 0) return;

            try
            {
                var res = await ApiClientService.Client.PutAsJsonAsync($"users/{id}/toggle-lock", new { });
                var body = res.IsSuccessStatusCode
                    ? await res.Content.ReadFromJsonAsync<ToggleLockResponse>()
                    : null;

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show(body?.Message ?? "Đã cập nhật trạng thái tài khoản!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show(await ReadErrorMessageAsync(res, "Cập nhật trạng thái thất bại!"), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút XÓA TÀI KHOẢN (DELETE /api/users/{id})
        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int id = GetSelectedUserId();
            if (id <= 0) return;

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa vĩnh viễn tài khoản ID = {id}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var res = await ApiClientService.Client.DeleteAsync($"users/{id}");
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show(await ReadErrorMessageAsync(res, "Xóa tài khoản thất bại!"), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút TẢI LẠI
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        // Lấy ID tài khoản đang chọn trên bảng (0 nếu chưa chọn)
        private int GetSelectedUserId()
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản trong bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            object? value = dgvUsers.CurrentRow.Cells["Id"].Value;
            if (value == null || !int.TryParse(value.ToString(), out int id))
            {
                MessageBox.Show("Không đọc được tài khoản đang chọn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            return id;
        }

        // Đọc thông báo lỗi chi tiết từ Server
        private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage res, string fallback)
        {
            try
            {
                var error = await res.Content.ReadFromJsonAsync<ApiError>();
                if (!string.IsNullOrWhiteSpace(error?.Message)) return error.Message;
            }
            catch { /* Giữ thông báo mặc định */ }
            return ApiClientService.GetResponseMessage(res, fallback);
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            cboRole.SelectedIndex = 1;
        }
    }

    // DTO tài khoản nhận từ API (không chứa mật khẩu)
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class ToggleLockResponse
    {
        public bool IsActive { get; set; }
        public string? Message { get; set; }
    }
}
