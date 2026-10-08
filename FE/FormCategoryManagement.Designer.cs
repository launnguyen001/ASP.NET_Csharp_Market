namespace FE
{
    partial class FormCategoryManagement
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
            lblSearchCaption = new Label();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();
            lblCount = new Label();
            dgvCategories = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            lblDetailTitle = new Label();
            lblIdCaption = new Label();
            txtId = new TextBox();
            lblNameCaption = new Label();
            txtCategoryName = new TextBox();
            lblDescCaption = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // lblSearchCaption
            // 
            lblSearchCaption.AutoSize = true;
            lblSearchCaption.Location = new Point(12, 16);
            lblSearchCaption.Name = "lblSearchCaption";
            lblSearchCaption.Size = new Size(97, 15);
            lblSearchCaption.TabIndex = 0;
            lblSearchCaption.Text = "Tìm tên / mô tả:";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(115, 13);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(260, 23);
            txtKeyword.TabIndex = 1;
            txtKeyword.KeyDown += txtKeyword_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(41, 100, 180);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(385, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 26);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(90, 100, 120);
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(483, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(90, 26);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCount.ForeColor = Color.Gray;
            lblCount.Location = new Point(845, 16);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(145, 18);
            lblCount.TabIndex = 4;
            lblCount.Text = "Tổng: 0 danh mục";
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.BackgroundColor = Color.White;
            dgvCategories.BorderStyle = BorderStyle.Fixed3D;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colDesc });
            dgvCategories.Location = new Point(12, 48);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(660, 540);
            dgvCategories.TabIndex = 5;
            dgvCategories.CellClick += dgvCategories_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "CategoryId";
            colId.HeaderText = "Mã ID";
            colId.MinimumWidth = 6;
            colId.Name = "CategoryId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "CategoryName";
            colName.HeaderText = "Tên nhóm hàng";
            colName.MinimumWidth = 6;
            colName.Name = "CategoryName";
            colName.ReadOnly = true;
            // 
            // colDesc
            // 
            colDesc.DataPropertyName = "Description";
            colDesc.HeaderText = "Mô tả";
            colDesc.MinimumWidth = 6;
            colDesc.Name = "Description";
            colDesc.ReadOnly = true;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(33, 43, 64);
            lblDetailTitle.Location = new Point(690, 50);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(193, 19);
            lblDetailTitle.TabIndex = 6;
            lblDetailTitle.Text = "CHI TIẾT NHÓM HÀNG";
            // 
            // lblIdCaption
            // 
            lblIdCaption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIdCaption.AutoSize = true;
            lblIdCaption.Location = new Point(690, 84);
            lblIdCaption.Name = "lblIdCaption";
            lblIdCaption.Size = new Size(46, 15);
            lblIdCaption.TabIndex = 7;
            lblIdCaption.Text = "Mã ID:";
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtId.BackColor = Color.FromArgb(235, 235, 235);
            txtId.Location = new Point(760, 81);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(230, 23);
            txtId.TabIndex = 8;
            // 
            // lblNameCaption
            // 
            lblNameCaption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNameCaption.AutoSize = true;
            lblNameCaption.Location = new Point(690, 115);
            lblNameCaption.Name = "lblNameCaption";
            lblNameCaption.Size = new Size(61, 15);
            lblNameCaption.TabIndex = 9;
            lblNameCaption.Text = "Tên (*):";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCategoryName.Location = new Point(760, 112);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(230, 23);
            txtCategoryName.TabIndex = 10;
            // 
            // lblDescCaption
            // 
            lblDescCaption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDescCaption.AutoSize = true;
            lblDescCaption.Location = new Point(690, 146);
            lblDescCaption.Name = "lblDescCaption";
            lblDescCaption.Size = new Size(47, 15);
            lblDescCaption.TabIndex = 11;
            lblDescCaption.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(760, 143);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(230, 70);
            txtDescription.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(34, 139, 60);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(690, 231);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(148, 40);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "THÊM MỚI";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.BackColor = Color.FromArgb(41, 100, 180);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(842, 231);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(148, 40);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "CẬP NHẬT";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(192, 48, 48);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(690, 277);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 40);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "XÓA";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // FormCategoryManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtDescription);
            Controls.Add(lblDescCaption);
            Controls.Add(txtCategoryName);
            Controls.Add(lblNameCaption);
            Controls.Add(txtId);
            Controls.Add(lblIdCaption);
            Controls.Add(lblDetailTitle);
            Controls.Add(dgvCategories);
            Controls.Add(lblCount);
            Controls.Add(btnLoad);
            Controls.Add(btnSearch);
            Controls.Add(txtKeyword);
            Controls.Add(lblSearchCaption);
            Font = new Font("Segoe UI", 9F);
            Name = "FormCategoryManagement";
            Text = "Quản lý danh mục nhóm hàng";
            Load += FormCategoryManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSearchCaption;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblIdCaption;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblDescCaption;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}
