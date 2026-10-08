namespace FE
{
    partial class FormProductManagement
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
            this.lblSearchCaption = new System.Windows.Forms.Label();
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.lblFilterCaption = new System.Windows.Forms.Label();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblIdCaption = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBarcodeCaption = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblPriceCaption = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStockCaption = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.lblCatCaption = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();
            //
            // lblSearchCaption
            //
            this.lblSearchCaption.AutoSize = true;
            this.lblSearchCaption.Location = new System.Drawing.Point(12, 16);
            this.lblSearchCaption.Name = "lblSearchCaption";
            this.lblSearchCaption.Size = new System.Drawing.Size(117, 15);
            this.lblSearchCaption.TabIndex = 0;
            this.lblSearchCaption.Text = "Tìm mã vạch / tên SP:";
            //
            // txtSearchBarcode
            //
            this.txtSearchBarcode.Location = new System.Drawing.Point(135, 13);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.Size = new System.Drawing.Size(240, 23);
            this.txtSearchBarcode.TabIndex = 1;
            this.txtSearchBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBarcode_KeyDown);
            //
            // lblFilterCaption
            //
            this.lblFilterCaption.AutoSize = true;
            this.lblFilterCaption.Location = new System.Drawing.Point(387, 16);
            this.lblFilterCaption.Name = "lblFilterCaption";
            this.lblFilterCaption.Size = new System.Drawing.Size(52, 15);
            this.lblFilterCaption.TabIndex = 2;
            this.lblFilterCaption.Text = "Nhóm:";
            //
            // cboFilterCategory
            //
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Location = new System.Drawing.Point(445, 13);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(190, 23);
            this.cboFilterCategory.TabIndex = 3;
            //
            // btnSearch
            //
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(645, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnLoad
            //
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(90, 100, 120);
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(743, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 26);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Tải lại";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            //
            // lblCount
            //
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(845, 16);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(145, 18);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Tổng: 0 sản phẩm";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 48);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(660, 540);
            this.dgvProducts.TabIndex = 7;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            //
            // lblDetailTitle
            //
            this.lblDetailTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(33, 43, 64);
            this.lblDetailTitle.Location = new System.Drawing.Point(690, 50);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(184, 19);
            this.lblDetailTitle.TabIndex = 8;
            this.lblDetailTitle.Text = "CHI TIẾT SẢN PHẨM";
            //
            // lblIdCaption
            //
            this.lblIdCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdCaption.AutoSize = true;
            this.lblIdCaption.Location = new System.Drawing.Point(690, 82);
            this.lblIdCaption.Name = "lblIdCaption";
            this.lblIdCaption.Size = new System.Drawing.Size(46, 15);
            this.lblIdCaption.TabIndex = 9;
            this.lblIdCaption.Text = "Mã ID:";
            //
            // txtId
            //
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.txtId.Location = new System.Drawing.Point(760, 79);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(230, 23);
            this.txtId.TabIndex = 10;
            //
            // lblBarcodeCaption
            //
            this.lblBarcodeCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBarcodeCaption.AutoSize = true;
            this.lblBarcodeCaption.Location = new System.Drawing.Point(690, 112);
            this.lblBarcodeCaption.Name = "lblBarcodeCaption";
            this.lblBarcodeCaption.Size = new System.Drawing.Size(56, 15);
            this.lblBarcodeCaption.TabIndex = 11;
            this.lblBarcodeCaption.Text = "Mã vạch:";
            //
            // txtBarcode
            //
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.Location = new System.Drawing.Point(760, 109);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(230, 23);
            this.txtBarcode.TabIndex = 12;
            //
            // lblNameCaption
            //
            this.lblNameCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Location = new System.Drawing.Point(690, 142);
            this.lblNameCaption.Name = "lblNameCaption";
            this.lblNameCaption.Size = new System.Drawing.Size(61, 15);
            this.lblNameCaption.TabIndex = 13;
            this.lblNameCaption.Text = "Tên SP:";
            //
            // txtProductName
            //
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.Location = new System.Drawing.Point(760, 139);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(230, 23);
            this.txtProductName.TabIndex = 14;
            //
            // lblPriceCaption
            //
            this.lblPriceCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriceCaption.AutoSize = true;
            this.lblPriceCaption.Location = new System.Drawing.Point(690, 172);
            this.lblPriceCaption.Name = "lblPriceCaption";
            this.lblPriceCaption.Size = new System.Drawing.Size(55, 15);
            this.lblPriceCaption.TabIndex = 15;
            this.lblPriceCaption.Text = "Đơn giá:";
            //
            // nudPrice
            //
            this.nudPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPrice.DecimalPlaces = 0;
            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nudPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudPrice.Location = new System.Drawing.Point(760, 169);
            this.nudPrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(230, 25);
            this.nudPrice.TabIndex = 16;
            //
            // lblStockCaption
            //
            this.lblStockCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStockCaption.AutoSize = true;
            this.lblStockCaption.Location = new System.Drawing.Point(690, 203);
            this.lblStockCaption.Name = "lblStockCaption";
            this.lblStockCaption.Size = new System.Drawing.Size(62, 15);
            this.lblStockCaption.TabIndex = 17;
            this.lblStockCaption.Text = "Tồn kho:";
            //
            // nudStock
            //
            this.nudStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudStock.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nudStock.Location = new System.Drawing.Point(760, 200);
            this.nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(230, 25);
            this.nudStock.TabIndex = 18;
            //
            // lblCatCaption
            //
            this.lblCatCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCatCaption.AutoSize = true;
            this.lblCatCaption.Location = new System.Drawing.Point(690, 234);
            this.lblCatCaption.Name = "lblCatCaption";
            this.lblCatCaption.Size = new System.Drawing.Size(58, 15);
            this.lblCatCaption.TabIndex = 19;
            this.lblCatCaption.Text = "Nhóm:";
            //
            // cboCategory
            //
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new System.Drawing.Point(760, 231);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(230, 23);
            this.cboCategory.TabIndex = 20;
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(34, 139, 60);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(690, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 40);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "THÊM MỚI";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(842, 268);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(148, 40);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "CẬP NHẬT";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 48, 48);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(690, 314);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 40);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "XÓA";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // FormProductManagement
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblCatCaption);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.lblStockCaption);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblPriceCaption);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblNameCaption);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblBarcodeCaption);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblIdCaption);
            this.Controls.Add(this.lblDetailTitle);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboFilterCategory);
            this.Controls.Add(this.lblFilterCaption);
            this.Controls.Add(this.txtSearchBarcode);
            this.Controls.Add(this.lblSearchCaption);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormProductManagement";
            this.Text = "Quản lý Sản phẩm & Kho hàng";
            this.Load += new System.EventHandler(this.FormProductManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSearchCaption;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.Label lblFilterCaption;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblIdCaption;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBarcodeCaption;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblPriceCaption;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblStockCaption;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label lblCatCaption;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}
