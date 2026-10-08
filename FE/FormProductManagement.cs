using System.Net.Http.Json;

namespace FE
{
    public partial class FormProductManagement : Form
    {
        public FormProductManagement()
        {
            InitializeComponent();
            SetupProductGrid();
        }

        // Cấu hình các cột của bảng sản phẩm
        private void SetupProductGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();
            // Name = DataPropertyName để row.Cells["ProductId"] tra cứu được (Name mới là khóa tra cứu)
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductId", DataPropertyName = "ProductId", HeaderText = "Mã", Width = 50 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Barcode", DataPropertyName = "Barcode", HeaderText = "Mã vạch", Width = 120 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", DataPropertyName = "ProductName", HeaderText = "Tên sản phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", DataPropertyName = "Price", HeaderText = "Đơn giá", Width = 95 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "StockQuantity", DataPropertyName = "StockQuantity", HeaderText = "Tồn kho", Width = 75 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "CategoryName", DataPropertyName = "CategoryName", HeaderText = "Nhóm hàng", Width = 150 });
        }

        // Form vừa nhúng vào shell: nạp danh mục + sản phẩm
        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadProductsAsync();
        }

        // Nạp 2 combo nhóm hàng: lọc (trên) và chọn ở ô chi tiết (phải)
        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await ApiClientService.Client.GetFromJsonAsync<List<CategoryDto>>("categories") ?? new List<CategoryDto>();

                cboCategory.DataSource = categories.ToList();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";

                // Combo lọc thêm mục "Tất cả nhóm" ở đầu danh sách
                var filterList = new List<CategoryDto>
                {
                    new CategoryDto { CategoryId = 0, CategoryName = "Tất cả nhóm" }
                };
                filterList.AddRange(categories);
                cboFilterCategory.DataSource = filterList;
                cboFilterCategory.DisplayMember = "CategoryName";
                cboFilterCategory.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi nạp danh mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nạp toàn bộ sản phẩm lên bảng
        private async Task LoadProductsAsync(string? keyword = null, int categoryId = 0)
        {
            try
            {
                string url = "products";
                if (!string.IsNullOrWhiteSpace(keyword) || categoryId > 0)
                {
                    url = $"products/search?keyword={Uri.EscapeDataString(keyword ?? string.Empty)}&categoryId={categoryId}";
                }

                var products = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>(url) ?? new List<ProductDto>();
                dgvProducts.DataSource = products;
                lblCount.Text = $"Tổng: {products.Count} sản phẩm";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi nạp sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Click một dòng trên bảng → đưa dữ liệu lên ô nhập để Sửa / Xóa
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
            txtId.Text = row.Cells["ProductId"].Value?.ToString() ?? string.Empty;
            txtBarcode.Text = row.Cells["Barcode"].Value?.ToString() ?? string.Empty;
            txtProductName.Text = row.Cells["ProductName"].Value?.ToString() ?? string.Empty;
            nudPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value ?? 0m);
            nudStock.Value = Convert.ToInt32(row.Cells["StockQuantity"].Value ?? 0);

            // Chọn nhóm hàng tương ứng trong combo chi tiết
            if (row.DataBoundItem is ProductDto prod && prod.CategoryId > 0)
            {
                cboCategory.SelectedValue = prod.CategoryId;
            }
        }

        // Nút TẢI LẠI
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Clear();
            cboFilterCategory.SelectedIndex = 0;
            await LoadProductsAsync();
        }

        // Nút TÌM KIẾM theo mã vạch/tên + lọc nhóm
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchBarcode.Text.Trim();
            int categoryId = cboFilterCategory.SelectedValue is int id ? id : 0;
            await LoadProductsAsync(keyword, categoryId);
        }

        // Enter trong ô tìm kiếm = bấm nút Tìm
        private void txtSearchBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, EventArgs.Empty);
            }
        }

        // Nút THÊM MỚI
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var newProd = new
            {
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = Convert.ToInt32(cboCategory.SelectedValue)
            };

            try
            {
                var res = await ApiClientService.Client.PostAsJsonAsync("products", newProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(await ReadErrorMessageAsync(res, "Thêm mới sản phẩm thất bại!"), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút CẬP NHẬT
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            int id = int.Parse(txtId.Text);
            var updateProd = new
            {
                ProductId = id,
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = Convert.ToInt32(cboCategory.SelectedValue)
            };

            try
            {
                var res = await ApiClientService.Client.PutAsJsonAsync($"products/{id}", updateProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(await ReadErrorMessageAsync(res, "Cập nhật sản phẩm thất bại!"), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút XÓA
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var res = await ApiClientService.Client.DeleteAsync($"products/{id}");
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(await ReadErrorMessageAsync(res, "Xóa sản phẩm thất bại!"), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra dữ liệu nhập trước khi gửi lên Server
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Mã vạch và tên sản phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Đọc thông báo lỗi chi tiết trả về từ Server
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

        // Dọn ô nhập
        private void ClearInputs()
        {
            txtId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            nudPrice.Value = 0;
            nudStock.Value = 0;
        }
    }
}
