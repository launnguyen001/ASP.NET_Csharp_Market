namespace FE
{
    partial class FormCustomerManagement
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
            dgvCustomers = new DataGridView();
            colCustomerId = new DataGridViewTextBoxColumn();
            colCustomerName = new DataGridViewTextBoxColumn();
            colPhoneNumber = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colRewardPoints = new DataGridViewTextBoxColumn();
            colMembershipRank = new DataGridViewTextBoxColumn();
            lblCustomerId = new Label();
            txtCustomerId = new TextBox();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblRewardPoints = new Label();
            txtRewardPoints = new TextBox();
            lblMembershipRank = new Label();
            cboMembershipRank = new ComboBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            //
            // dgvCustomers
            //
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { colCustomerId, colCustomerName, colPhoneNumber, colAddress, colRewardPoints, colMembershipRank });
            dgvCustomers.Location = new Point(20, 265);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(900, 251);
            dgvCustomers.TabIndex = 15;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            //
            // colCustomerId
            //
            colCustomerId.DataPropertyName = "CustomerId";
            colCustomerId.HeaderText = "Mã KH";
            colCustomerId.MinimumWidth = 6;
            colCustomerId.Name = "CustomerId";
            colCustomerId.ReadOnly = true;
            //
            // colCustomerName
            //
            colCustomerName.DataPropertyName = "CustomerName";
            colCustomerName.HeaderText = "Tên khách hàng";
            colCustomerName.MinimumWidth = 6;
            colCustomerName.Name = "CustomerName";
            colCustomerName.ReadOnly = true;
            //
            // colPhoneNumber
            //
            colPhoneNumber.DataPropertyName = "PhoneNumber";
            colPhoneNumber.HeaderText = "Số điện thoại";
            colPhoneNumber.MinimumWidth = 6;
            colPhoneNumber.Name = "PhoneNumber";
            colPhoneNumber.ReadOnly = true;
            //
            // colAddress
            //
            colAddress.DataPropertyName = "Address";
            colAddress.HeaderText = "Địa chỉ";
            colAddress.MinimumWidth = 6;
            colAddress.Name = "Address";
            colAddress.ReadOnly = true;
            //
            // colRewardPoints
            //
            colRewardPoints.DataPropertyName = "RewardPoints";
            colRewardPoints.HeaderText = "Điểm tích lũy";
            colRewardPoints.MinimumWidth = 6;
            colRewardPoints.Name = "RewardPoints";
            colRewardPoints.ReadOnly = true;
            //
            // colMembershipRank
            //
            colMembershipRank.DataPropertyName = "MembershipRank";
            colMembershipRank.HeaderText = "Hạng thẻ";
            colMembershipRank.MinimumWidth = 6;
            colMembershipRank.Name = "MembershipRank";
            colMembershipRank.ReadOnly = true;
            //
            // lblCustomerId
            //
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(20, 22);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(48, 15);
            lblCustomerId.TabIndex = 1;
            lblCustomerId.Text = "Mã khách hàng:";
            //
            // txtCustomerId
            //
            txtCustomerId.Location = new Point(160, 18);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.ReadOnly = true;
            txtCustomerId.Size = new Size(120, 23);
            txtCustomerId.TabIndex = 2;
            //
            // lblCustomerName
            //
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(20, 53);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(92, 15);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Tên khách hàng (*):";
            //
            // txtCustomerName
            //
            txtCustomerName.Location = new Point(160, 49);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(420, 23);
            txtCustomerName.TabIndex = 4;
            //
            // lblPhoneNumber
            //
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(20, 84);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(96, 15);
            lblPhoneNumber.TabIndex = 5;
            lblPhoneNumber.Text = "Số điện thoại (*):";
            //
            // txtPhoneNumber
            //
            txtPhoneNumber.Location = new Point(160, 80);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(220, 23);
            txtPhoneNumber.TabIndex = 6;
            //
            // lblAddress
            //
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(20, 115);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(59, 15);
            lblAddress.TabIndex = 7;
            lblAddress.Text = "Địa chỉ:";
            //
            // txtAddress
            //
            txtAddress.Location = new Point(160, 111);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(420, 23);
            txtAddress.TabIndex = 8;
            //
            // lblRewardPoints
            //
            lblRewardPoints.AutoSize = true;
            lblRewardPoints.Location = new Point(20, 146);
            lblRewardPoints.Name = "lblRewardPoints";
            lblRewardPoints.Size = new Size(83, 15);
            lblRewardPoints.TabIndex = 9;
            lblRewardPoints.Text = "Điểm tích lũy:";
            //
            // txtRewardPoints
            //
            txtRewardPoints.Location = new Point(160, 142);
            txtRewardPoints.Name = "txtRewardPoints";
            txtRewardPoints.Size = new Size(120, 23);
            txtRewardPoints.TabIndex = 10;
            //
            // lblMembershipRank
            //
            lblMembershipRank.AutoSize = true;
            lblMembershipRank.Location = new Point(320, 146);
            lblMembershipRank.Name = "lblMembershipRank";
            lblMembershipRank.Size = new Size(67, 15);
            lblMembershipRank.TabIndex = 11;
            lblMembershipRank.Text = "Hạng thẻ:";
            //
            // cboMembershipRank
            //
            cboMembershipRank.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMembershipRank.Items.AddRange(new object[] { "Chuẩn", "Bạc", "Vàng", "Kim cương" });
            cboMembershipRank.Location = new Point(400, 142);
            cboMembershipRank.Name = "cboMembershipRank";
            cboMembershipRank.Size = new Size(180, 23);
            cboMembershipRank.TabIndex = 12;
            //
            // btnLoad
            //
            btnLoad.Location = new Point(20, 180);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(90, 28);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            //
            // btnAdd
            //
            btnAdd.Location = new Point(120, 180);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 28);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            //
            // btnUpdate
            //
            btnUpdate.Location = new Point(230, 180);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 28);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            //
            // btnDelete
            //
            btnDelete.Location = new Point(340, 180);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 28);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            //
            // lblKeyword
            //
            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(20, 226);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(127, 15);
            lblKeyword.TabIndex = 17;
            lblKeyword.Text = "Từ khóa (tên/SĐT):";
            //
            // txtKeyword
            //
            txtKeyword.Location = new Point(160, 222);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(420, 23);
            txtKeyword.TabIndex = 18;
            //
            // btnSearch
            //
            btnSearch.Location = new Point(600, 219);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 28);
            btnSearch.TabIndex = 19;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            //
            // FormCustomerManagement
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 534);
            Controls.Add(btnSearch);
            Controls.Add(txtKeyword);
            Controls.Add(lblKeyword);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(cboMembershipRank);
            Controls.Add(lblMembershipRank);
            Controls.Add(txtRewardPoints);
            Controls.Add(lblRewardPoints);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(txtCustomerId);
            Controls.Add(lblCustomerId);
            Controls.Add(dgvCustomers);
            Name = "FormCustomerManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khách hàng - Tiệm Trà Sữa & Ăn Vặt";
            Load += FormCustomerManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRewardPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMembershipRank;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.TextBox txtRewardPoints;
        private System.Windows.Forms.Label lblMembershipRank;
        private System.Windows.Forms.ComboBox cboMembershipRank;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
    }
}