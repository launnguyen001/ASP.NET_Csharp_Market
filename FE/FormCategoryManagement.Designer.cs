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
            dgvCategories = new DataGridView();
            lblId = new Label();
            txtId = new TextBox();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnOpenRoles = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Location = new Point(20, 194);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(760, 229);
            dgvCategories.TabIndex = 8;
            dgvCategories.CellClick += dgvCategories_CellClick;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 22);
            lblId.Name = "lblId";
            lblId.Size = new Size(41, 15);
            lblId.TabIndex = 1;
            lblId.Text = "Mã ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 18);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(20, 53);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(109, 15);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Tên nhóm hàng (*):";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(140, 49);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(400, 23);
            txtCategoryName.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 84);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(41, 15);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(140, 80);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(400, 23);
            txtDescription.TabIndex = 6;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(20, 115);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(90, 28);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(120, 115);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 28);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(230, 115);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 28);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(340, 115);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 28);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(20, 161);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(102, 15);
            lblKeyword.TabIndex = 10;
            lblKeyword.Text = "Từ khóa tìm kiếm:";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(140, 157);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(400, 23);
            txtKeyword.TabIndex = 11;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(560, 154);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 28);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnOpenRoles
            // 
            btnOpenRoles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenRoles.Location = new Point(630, 13);
            btnOpenRoles.Name = "btnOpenRoles";
            btnOpenRoles.Size = new Size(150, 28);
            btnOpenRoles.TabIndex = 13;
            btnOpenRoles.Text = "Quản lý vai trò";
            btnOpenRoles.UseVisualStyleBackColor = true;
            btnOpenRoles.Click += btnOpenRoles_Click;
            // 
            // FormCategoryManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 441);
            Controls.Add(btnOpenRoles);
            Controls.Add(btnSearch);
            Controls.Add(txtKeyword);
            Controls.Add(lblKeyword);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(dgvCategories);
            Name = "FormCategoryManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhóm hàng - Mini Supermarket";
            Load += FormCategoryManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOpenRoles;
    }
}