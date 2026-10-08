using System.Net.Http.Json;

namespace FE
{
    // Màn hình Báo cáo Doanh thu Nhanh (Bài tập mở rộng Buổi 4)
    // Chỉ tài khoản vai trò Admin mới mở được (chặ ngay tại FormMainShell)
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();
        }

        // Mở form: tự động chạy báo cáo của ngày đang chọn
        private async void FormQuickReport_Load(object sender, EventArgs e)
        {
            await RunReportAsync();
        }

        // Nút XEM BÁO CÁO
        private async void btnRunReport_Click(object sender, EventArgs e)
        {
            await RunReportAsync();
        }

        // Đổi ngày trên DateTimePicker → chạy lại báo cáo
        private async void dtpReportDate_ValueChanged(object sender, EventArgs e)
        {
            await RunReportAsync();
        }

        // Gọi API GET /api/reports/quick?date=yyyy-MM-dd và đổ lên 3 thẻ tóm tắt
        private async Task RunReportAsync()
        {
            try
            {
                string date = dtpReportDate.Value.ToString("yyyy-MM-dd");
                var report = await ApiClientService.Client.GetFromJsonAsync<QuickReportDto>($"reports/quick?date={date}");

                if (report == null)
                {
                    MessageBox.Show("Không nhận được dữ liệu báo cáo từ máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblTotalOrders.Text = report.TotalOrders.ToString("N0");
                lblTotalRevenue.Text = $"{report.TotalRevenue:N0} đ";
                lblBestSeller.Text = report.BestSeller;
                lblReportNote.Text = $"Dữ liệu ngày {report.ReportDate:dd/MM/yyyy} - nguồn API /api/reports/quick";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ApiClientService.GetErrorMessage(ex), "Lỗi tải báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // DTO báo cáo nhanh trả về từ API
    public class QuickReportDto
    {
        public DateTime ReportDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public string BestSeller { get; set; } = string.Empty;
    }
}
