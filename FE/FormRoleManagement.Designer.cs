namespace FE
{
    partial class FormRoleManagement
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
            dgvRoles = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colRoleName = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            lblId = new Label();
            txtId = new TextBox();
            lblRoleName = new Label();
            txtRoleName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            SuspendLayout();
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Columns.AddRange(new DataGridViewColumn[] { colId, colRoleName, colDesc });
            dgvRoles.Location = new Point(20, 172);
            dgvRoles.MultiSelect = false;
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.Size = new Size(760, 251);
            dgvRoles.TabIndex = 8;
            dgvRoles.CellClick += dgvRoles_CellClick;
            dgvRoles.CellContentClick += dgvRoles_CellContentClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Mã ID";
            colId.MinimumWidth = 6;
            colId.Name = "Id";
            colId.ReadOnly = true;
            // 
            // colRoleName
            // 
            colRoleName.DataPropertyName = "RoleName";
            colRoleName.HeaderText = "Tên vai trò";
            colRoleName.MinimumWidth = 6;
            colRoleName.Name = "RoleName";
            colRoleName.ReadOnly = true;
            // 
            // colDesc
            // 
            colDesc.DataPropertyName = "Description";
            colDesc.HeaderText = "Mô tả";
            colDesc.MinimumWidth = 6;
            colDesc.Name = "Description";
            colDesc.ReadOnly = true;
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
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Location = new Point(20, 53);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(80, 15);
            lblRoleName.TabIndex = 3;
            lblRoleName.Text = "Tên vai trò (*):";
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(140, 49);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(400, 23);
            txtRoleName.TabIndex = 4;
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
            // FormRoleManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 441);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtRoleName);
            Controls.Add(lblRoleName);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(dgvRoles);
            Name = "FormRoleManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý vai trò - Mini Supermarket";
            Load += FormRoleManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}