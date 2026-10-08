namespace FE
{
    partial class FormMainShell
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
            panelSidebar = new Panel();
            panelUserFooter = new Panel();
            btnLogout = new Button();
            lblSidebarName = new Label();
            btnUserManage = new Button();
            btnReports = new Button();
            btnCustomer = new Button();
            btnProduct = new Button();
            btnCategory = new Button();
            btnPOS = new Button();
            lblLogo = new Label();
            panelRightArea = new Panel();
            panelMainContent = new Panel();
            panelTopHeader = new Panel();
            lblUserInfo = new Label();
            lblTitle = new Label();
            panelSidebar.SuspendLayout();
            panelUserFooter.SuspendLayout();
            panelRightArea.SuspendLayout();
            panelTopHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(24, 30, 48);
            panelSidebar.Controls.Add(panelUserFooter);
            panelSidebar.Controls.Add(btnUserManage);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnCustomer);
            panelSidebar.Controls.Add(btnProduct);
            panelSidebar.Controls.Add(btnCategory);
            panelSidebar.Controls.Add(btnPOS);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(230, 681);
            panelSidebar.TabIndex = 0;
            // 
            // panelUserFooter
            // 
            panelUserFooter.BackColor = Color.FromArgb(17, 22, 36);
            panelUserFooter.Controls.Add(btnLogout);
            panelUserFooter.Controls.Add(lblSidebarName);
            panelUserFooter.Dock = DockStyle.Bottom;
            panelUserFooter.Location = new Point(0, 621);
            panelUserFooter.Name = "panelUserFooter";
            panelUserFooter.Size = new Size(230, 60);
            panelUserFooter.TabIndex = 7;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(17, 22, 36);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.FromArgb(255, 120, 120);
            btnLogout.Location = new Point(0, 24);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(230, 36);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "🚪  Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblSidebarName
            // 
            lblSidebarName.Dock = DockStyle.Top;
            lblSidebarName.ForeColor = Color.FromArgb(160, 170, 190);
            lblSidebarName.Location = new Point(0, 0);
            lblSidebarName.Name = "lblSidebarName";
            lblSidebarName.Size = new Size(230, 24);
            lblSidebarName.TabIndex = 0;
            lblSidebarName.Text = "Nhân viên";
            lblSidebarName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUserManage
            // 
            btnUserManage.BackColor = Color.FromArgb(24, 30, 48);
            btnUserManage.Cursor = Cursors.Hand;
            btnUserManage.FlatAppearance.BorderSize = 0;
            btnUserManage.FlatStyle = FlatStyle.Flat;
            btnUserManage.ForeColor = Color.White;
            btnUserManage.Location = new Point(0, 305);
            btnUserManage.Name = "btnUserManage";
            btnUserManage.Padding = new Padding(16, 0, 0, 0);
            btnUserManage.Size = new Size(230, 45);
            btnUserManage.TabIndex = 6;
            btnUserManage.TabStop = false;
            btnUserManage.Text = "🛡  Quản trị Tài khoản";
            btnUserManage.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManage.UseVisualStyleBackColor = false;
            btnUserManage.Click += btnUserManage_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(24, 30, 48);
            btnReports.Cursor = Cursors.Hand;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 256);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(16, 0, 0, 0);
            btnReports.Size = new Size(230, 45);
            btnReports.TabIndex = 5;
            btnReports.TabStop = false;
            btnReports.Text = "📊  Báo cáo Doanh thu";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.BackColor = Color.FromArgb(24, 30, 48);
            btnCustomer.Cursor = Cursors.Hand;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.ForeColor = Color.White;
            btnCustomer.Location = new Point(0, 207);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(16, 0, 0, 0);
            btnCustomer.Size = new Size(230, 45);
            btnCustomer.TabIndex = 4;
            btnCustomer.TabStop = false;
            btnCustomer.Text = "👥  Quản lý Khách hàng";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = false;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnProduct
            // 
            btnProduct.BackColor = Color.FromArgb(24, 30, 48);
            btnProduct.Cursor = Cursors.Hand;
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.ForeColor = Color.White;
            btnProduct.Location = new Point(0, 158);
            btnProduct.Name = "btnProduct";
            btnProduct.Padding = new Padding(16, 0, 0, 0);
            btnProduct.Size = new Size(230, 45);
            btnProduct.TabIndex = 3;
            btnProduct.TabStop = false;
            btnProduct.Text = "📦  Quản lý Sản phẩm";
            btnProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnProduct.UseVisualStyleBackColor = false;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.FromArgb(24, 30, 48);
            btnCategory.Cursor = Cursors.Hand;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.ForeColor = Color.White;
            btnCategory.Location = new Point(0, 109);
            btnCategory.Name = "btnCategory";
            btnCategory.Padding = new Padding(16, 0, 0, 0);
            btnCategory.Size = new Size(230, 45);
            btnCategory.TabIndex = 2;
            btnCategory.TabStop = false;
            btnCategory.Text = "📁  Quản lý Danh mục";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.FromArgb(24, 30, 48);
            btnPOS.Cursor = Cursors.Hand;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.ForeColor = Color.White;
            btnPOS.Location = new Point(0, 60);
            btnPOS.Name = "btnPOS";
            btnPOS.Padding = new Padding(16, 0, 0, 0);
            btnPOS.Size = new Size(230, 45);
            btnPOS.TabIndex = 1;
            btnPOS.TabStop = false;
            btnPOS.Text = "\U0001f6d2  Bán hàng (POS)";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.UseVisualStyleBackColor = false;
            btnPOS.Click += btnPOS_Click;
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.FromArgb(24, 30, 48);
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(230, 52);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "\U0001f6d2 TRA SUA LYLY";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.Click += lblLogo_Click;
            // 
            // panelRightArea
            // 
            panelRightArea.BackColor = Color.FromArgb(244, 245, 247);
            panelRightArea.Controls.Add(panelMainContent);
            panelRightArea.Controls.Add(panelTopHeader);
            panelRightArea.Dock = DockStyle.Fill;
            panelRightArea.Location = new Point(230, 0);
            panelRightArea.Name = "panelRightArea";
            panelRightArea.Size = new Size(1026, 681);
            panelRightArea.TabIndex = 1;
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.FromArgb(244, 245, 247);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 60);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1026, 621);
            panelMainContent.TabIndex = 1;
            panelMainContent.Paint += panelMainContent_Paint;
            // 
            // panelTopHeader
            // 
            panelTopHeader.BackColor = Color.White;
            panelTopHeader.Controls.Add(lblUserInfo);
            panelTopHeader.Controls.Add(lblTitle);
            panelTopHeader.Dock = DockStyle.Top;
            panelTopHeader.Location = new Point(0, 0);
            panelTopHeader.Name = "panelTopHeader";
            panelTopHeader.Size = new Size(1026, 60);
            panelTopHeader.TabIndex = 0;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Dock = DockStyle.Right;
            lblUserInfo.Font = new Font("Segoe UI", 10F);
            lblUserInfo.ForeColor = Color.FromArgb(110, 110, 110);
            lblUserInfo.Location = new Point(546, 0);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Padding = new Padding(0, 0, 20, 0);
            lblUserInfo.Size = new Size(480, 60);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Xin chào: ...";
            lblUserInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 43, 64);
            lblTitle.Location = new Point(24, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(248, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG";
            // 
            // FormMainShell
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1256, 681);
            Controls.Add(panelRightArea);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1100, 600);
            Name = "FormMainShell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini";
            Load += FormMainShell_Load;
            panelSidebar.ResumeLayout(false);
            panelUserFooter.ResumeLayout(false);
            panelRightArea.ResumeLayout(false);
            panelTopHeader.ResumeLayout(false);
            panelTopHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelRightArea;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Panel panelUserFooter;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblSidebarName;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Button btnLogout;
    }
}
