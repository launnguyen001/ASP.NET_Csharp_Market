using System.ComponentModel;
using System.Net.Http.Json;

namespace FE
{
    public partial class FormPOS : Form
    {
        // Giỏ hàng hiện tại của phiên bán hàng (BindingList tự thông báo thêm/xóa/sửa cho DataGridView)
        private readonly BindingList<CartItemDto> _cart = new();

        public FormPOS()
        {
            InitializeComponent();
            SetupCartGrid();
            // Gán nguồn dữ liệu MỘT LẦN khi form được hiển thị (tránh NullReferenceException khi rebind)
            Load += (s, e) => dgvCart.DataSource = _cart;
        }

        // Cấu hình các cột của bảng giỏ hàng (không tự sinh cột theo DTO)
        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            // Name = DataPropertyName để tra cột theo tên khi cần
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductId", DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 70 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitPrice", DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá", Width = 100 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", DataPropertyName = "Quantity", HeaderText = "SL", Width = 55 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalPrice", DataPropertyName = "TotalPrice", HeaderText = "Thành Tiền", Width = 110 });
        }

        // Bắt sự kiện quét mã Barcode (máy quét gõ xong tự nhấn Enter)
        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                Log($"KEYDOWN tid={System.Threading.Thread.CurrentThread.ManagedThreadId} ctx={System.Threading.SynchronizationContext.Current?.GetType().Name ?? "null"}");
                e.SuppressKeyPress = true; // Không cho tiếng "bíp" của Enter
                string barcode = txtBarcode.Text.Trim();
                txtBarcode.Clear();
                await AddProductToCartByBarcodeAsync(barcode);
                Log($"HANDLER DONE count={_cart.Count} lbl={lblTotalAmount.Text} rows={dgvCart.Rows.Count}");
            }
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode)
        {
            try
            {
                // Gọi API tra cứu sản phẩm theo Barcode
                var product = await ApiClientService.Client.GetFromJsonAsync<ProductDto>($"products/barcode/{barcode}");
                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existingItem != null)
                {
                    if (existingItem.Quantity + 1 > product.StockQuantity)
                    {
                        MessageBox.Show($"Sản phẩm \"{product.ProductName}\" chỉ còn {product.StockQuantity} trong kho!",
                            "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    existingItem.Quantity++;
                }
                else
                {
                    if (product.StockQuantity <= 0)
                    {
                        MessageBox.Show($"Sản phẩm \"{product.ProductName}\" đã hết hàng!",
                            "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _cart.Add(new CartItemDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Log($"ADD EXCEPTION: {ex.Message} | {ex.StackTrace}");
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Log(string m) { try { System.IO.File.AppendAllText(@"C:\Users\Admin\AppData\Local\Temp\opencode\pos_debug.log", $"{DateTime.Now:HH:mm:ss.fff} {m}{Environment.NewLine}"); } catch { } }

        // Cập nhật tổng tiền + tiền thừa (bảng giỏ tự đồng bộ qua BindingList)
        private void UpdateCartDisplay()
        {
            Log($"UPD ENTER tid={System.Threading.Thread.CurrentThread.ManagedThreadId} ctx={System.Threading.SynchronizationContext.Current?.GetType().Name ?? "null"} count={_cart.Count} rows={dgvCart.Rows.Count}");
            decimal total = _cart.Sum(x => x.TotalPrice);
            lblTotalAmount.Text = $"{total:N0} đ";
            CalculateChange();
            Log($"UPD EXIT total={total} lbl={lblTotalAmount.Text} rows={dgvCart.Rows.Count}");
        }

        // Nhấn Delete trên dòng đang chọn để xóa khỏi giỏ
        private void dgvCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index < _cart.Count)
            {
                _cart.RemoveAt(dgvCart.CurrentRow.Index);
                UpdateCartDisplay();
            }
        }

        // Tra cứu khách hàng thành viên theo SĐT (nhấn Enter)
        private async void txtCustomerPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;

            string phone = txtCustomerPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                lblCustomerName.Text = "Khách vãng lai";
                lblCustomerName.ForeColor = Color.DimGray;
                return;
            }

            try
            {
                var customers = await ApiClientService.Client
                    .GetFromJsonAsync<List<CustomerDto>>($"customers/search?keyword={Uri.EscapeDataString(phone)}");
                var match = customers?.FirstOrDefault(c => c.PhoneNumber == phone);

                if (match == null)
                {
                    lblCustomerName.Text = "Không tìm thấy khách hàng này!";
                    lblCustomerName.ForeColor = Color.Red;
                }
                else
                {
                    lblCustomerName.Text = $"{match.CustomerName} - Hạng {match.MembershipRank} ({match.RewardPoints:N0} điểm)";
                    lblCustomerName.ForeColor = Color.FromArgb(0, 120, 60);
                }
            }
            catch (Exception ex)
            {
                lblCustomerName.Text = "Lỗi tra cứu khách hàng!";
                lblCustomerName.ForeColor = Color.Red;
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        // Tính tiền thừa trả lại khách
        private void CalculateChange()
        {
            decimal total = _cart.Sum(x => x.TotalPrice);
            if (decimal.TryParse(txtCashReceived.Text, out decimal cashReceived))
            {
                decimal change = cashReceived - total;
                lblChange.Text = change >= 0 ? $"{change:N0} đ" : "Chưa đủ tiền!";
                lblChange.ForeColor = change >= 0 ? Color.Black : Color.Red;
            }
            else
            {
                lblChange.Text = "0 đ";
                lblChange.ForeColor = Color.Black;
            }
        }

        // Nút THANH TOÁN (phím tắt F9)
        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = _cart.Sum(x => x.TotalPrice);
            if (!decimal.TryParse(txtCashReceived.Text, out decimal cashReceived) || cashReceived < total)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ so với tổng cần thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                return;
            }

            var orderRequest = new
            {
                CashierUsername = SessionManager.CurrentUsername,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                CashReceived = cashReceived,
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            try
            {
                var response = await ApiClientService.Client.PostAsJsonAsync("orders/checkout", orderRequest);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thanh toán thành công và đã in hóa đơn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cart.Clear();
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách vãng lai";
                    lblCustomerName.ForeColor = Color.DimGray;
                    txtBarcode.Focus();
                }
                else
                {
                    // Đọc thông báo lỗi chi tiết trả về từ Server (hết kho, sai SĐT...)
                    string message = "Thanh toán thất bại từ máy chủ!";
                    try
                    {
                        var error = await response.Content.ReadFromJsonAsync<ApiError>();
                        if (!string.IsNullOrWhiteSpace(error?.Message)) message = error.Message;
                    }
                    catch { /* Giữ thông báo mặc định */ }

                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút HỦY GIỎ HÀNG
        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) return;

            var confirm = MessageBox.Show("Bạn chắc chắn muốn hủy toàn bộ giỏ hàng?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _cart.Clear();
                UpdateCartDisplay();
                txtCustomerPhone.Clear();
                lblCustomerName.Text = "Khách vãng lai";
                lblCustomerName.ForeColor = Color.DimGray;
            }
        }

        // Phím tắt F9 = Thanh toán (ProcessCmdKey chạy được cả khi Form nhúng TopLevel=false)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F9)
            {
                btnCheckout_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == Keys.F2)
            {
                txtBarcode.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    // Dòng sản phẩm trong giỏ hàng (thông báo thay đổi để DataGridView tự cập nhật)
    public class CartItemDto : INotifyPropertyChanged
    {
        private int _quantity;

        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal TotalPrice => UnitPrice * Quantity;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    // Thông tin sản phẩm nhận từ API (dùng chung cho POS và Quản lý sản phẩm)
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    // Thông báo lỗi chuẩn trả về từ Web API
    public class ApiError
    {
        public string? Message { get; set; }
    }
}


