namespace FE
{
    partial class FormQuickReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDateCaption = new System.Windows.Forms.Label();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.panelCardOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblOrdersCaption = new System.Windows.Forms.Label();
            this.panelCardRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblRevenueCaption = new System.Windows.Forms.Label();
            this.panelCardBest = new System.Windows.Forms.Panel();
            this.lblBestSeller = new System.Windows.Forms.Label();
            this.lblBestCaption = new System.Windows.Forms.Label();
            this.lblReportNote = new System.Windows.Forms.Label();
            this.panelCardOrders.SuspendLayout();
            this.panelCardRevenue.SuspendLayout();
            this.panelCardBest.SuspendLayout();
            this.SuspendLayout();
            //
            // lblDateCaption
            //
            this.lblDateCaption.AutoSize = true;
            this.lblDateCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateCaption.Location = new System.Drawing.Point(24, 20);
            this.lblDateCaption.Name = "lblDateCaption";
            this.lblDateCaption.Size = new System.Drawing.Size(133, 19);
            this.lblDateCaption.TabIndex = 0;
            this.lblDateCaption.Text = "Ngày xem báo cáo:";
            //
            // dtpReportDate
            //
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportDate.Location = new System.Drawing.Point(165, 18);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(200, 23);
            this.dtpReportDate.TabIndex = 1;
            this.dtpReportDate.ValueChanged += new System.EventHandler(this.dtpReportDate_ValueChanged);
            //
            // btnRunReport
            //
            this.btnRunReport.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnRunReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunReport.FlatAppearance.BorderSize = 0;
            this.btnRunReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReport.ForeColor = System.Drawing.Color.White;
            this.btnRunReport.Location = new System.Drawing.Point(380, 17);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(160, 26);
            this.btnRunReport.TabIndex = 2;
            this.btnRunReport.Text = "XEM BÁO CÁO";
            this.btnRunReport.UseVisualStyleBackColor = false;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            //
            // panelCardOrders
            //
            this.panelCardOrders.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.panelCardOrders.Controls.Add(this.lblTotalOrders);
            this.panelCardOrders.Controls.Add(this.lblOrdersCaption);
            this.panelCardOrders.Location = new System.Drawing.Point(24, 70);
            this.panelCardOrders.Name = "panelCardOrders";
            this.panelCardOrders.Size = new System.Drawing.Size(300, 160);
            this.panelCardOrders.TabIndex = 3;
            //
            // lblTotalOrders
            //
            this.lblTotalOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrders.Location = new System.Drawing.Point(0, 40);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(300, 120);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblOrdersCaption
            //
            this.lblOrdersCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOrdersCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrdersCaption.ForeColor = System.Drawing.Color.White;
            this.lblOrdersCaption.Location = new System.Drawing.Point(0, 0);
            this.lblOrdersCaption.Name = "lblOrdersCaption";
            this.lblOrdersCaption.Size = new System.Drawing.Size(300, 40);
            this.lblOrdersCaption.TabIndex = 0;
            this.lblOrdersCaption.Text = "TỔNG SỐ HÓA ĐƠN";
            this.lblOrdersCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelCardRevenue
            //
            this.panelCardRevenue.BackColor = System.Drawing.Color.FromArgb(34, 139, 60);
            this.panelCardRevenue.Controls.Add(this.lblTotalRevenue);
            this.panelCardRevenue.Controls.Add(this.lblRevenueCaption);
            this.panelCardRevenue.Location = new System.Drawing.Point(350, 70);
            this.panelCardRevenue.Name = "panelCardRevenue";
            this.panelCardRevenue.Size = new System.Drawing.Size(300, 160);
            this.panelCardRevenue.TabIndex = 4;
            //
            // lblTotalRevenue
            //
            this.lblTotalRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Location = new System.Drawing.Point(0, 40);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(300, 120);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0 đ";
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblRevenueCaption
            //
            this.lblRevenueCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRevenueCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRevenueCaption.ForeColor = System.Drawing.Color.White;
            this.lblRevenueCaption.Location = new System.Drawing.Point(0, 0);
            this.lblRevenueCaption.Name = "lblRevenueCaption";
            this.lblRevenueCaption.Size = new System.Drawing.Size(300, 40);
            this.lblRevenueCaption.TabIndex = 0;
            this.lblRevenueCaption.Text = "TỔNG DOANH THU";
            this.lblRevenueCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelCardBest
            //
            this.panelCardBest.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.panelCardBest.Controls.Add(this.lblBestSeller);
            this.panelCardBest.Controls.Add(this.lblBestCaption);
            this.panelCardBest.Location = new System.Drawing.Point(676, 70);
            this.panelCardBest.Name = "panelCardBest";
            this.panelCardBest.Size = new System.Drawing.Size(300, 160);
            this.panelCardBest.TabIndex = 5;
            //
            // lblBestSeller
            //
            this.lblBestSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBestSeller.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBestSeller.ForeColor = System.Drawing.Color.White;
            this.lblBestSeller.Location = new System.Drawing.Point(0, 40);
            this.lblBestSeller.Name = "lblBestSeller";
            this.lblBestSeller.Size = new System.Drawing.Size(300, 120);
            this.lblBestSeller.TabIndex = 1;
            this.lblBestSeller.Text = "Chưa có dữ liệu";
            this.lblBestSeller.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblBestCaption
            //
            this.lblBestCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBestCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBestCaption.ForeColor = System.Drawing.Color.White;
            this.lblBestCaption.Location = new System.Drawing.Point(0, 0);
            this.lblBestCaption.Name = "lblBestCaption";
            this.lblBestCaption.Size = new System.Drawing.Size(300, 40);
            this.lblBestCaption.TabIndex = 0;
            this.lblBestCaption.Text = "MẶT HÀNG BÁN CHẠY NHẤT";
            this.lblBestCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblReportNote
            //
            this.lblReportNote.ForeColor = System.Drawing.Color.Gray;
            this.lblReportNote.Location = new System.Drawing.Point(24, 245);
            this.lblReportNote.Name = "lblReportNote";
            this.lblReportNote.Size = new System.Drawing.Size(950, 20);
            this.lblReportNote.TabIndex = 6;
            this.lblReportNote.Text = "Dữ liệu tải từ API /api/reports/quick";
            //
            // FormQuickReport
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.lblReportNote);
            this.Controls.Add(this.panelCardBest);
            this.Controls.Add(this.panelCardRevenue);
            this.Controls.Add(this.panelCardOrders);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.dtpReportDate);
            this.Controls.Add(this.lblDateCaption);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormQuickReport";
            this.Text = "Báo cáo Doanh thu Nhanh";
            this.Load += new System.EventHandler(this.FormQuickReport_Load);
            this.panelCardOrders.ResumeLayout(false);
            this.panelCardRevenue.ResumeLayout(false);
            this.panelCardBest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDateCaption;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Panel panelCardOrders;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblOrdersCaption;
        private System.Windows.Forms.Panel panelCardRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblRevenueCaption;
        private System.Windows.Forms.Panel panelCardBest;
        private System.Windows.Forms.Label lblBestSeller;
        private System.Windows.Forms.Label lblBestCaption;
        private System.Windows.Forms.Label lblReportNote;
    }
}
