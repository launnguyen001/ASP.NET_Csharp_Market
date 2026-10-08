namespace FE
{
    partial class FormPOS
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
            this.lblBarcodeCaption = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblPhoneCaption = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCashCaption = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.lblChangeCaption = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            //
            // lblBarcodeCaption
            //
            this.lblBarcodeCaption.AutoSize = true;
            this.lblBarcodeCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBarcodeCaption.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.lblBarcodeCaption.Location = new System.Drawing.Point(12, 15);
            this.lblBarcodeCaption.Name = "lblBarcodeCaption";
            this.lblBarcodeCaption.Size = new System.Drawing.Size(146, 19);
            this.lblBarcodeCaption.TabIndex = 0;
            this.lblBarcodeCaption.Text = "Quét mã vạch (Enter):";
            //
            // txtBarcode
            //
            this.txtBarcode.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtBarcode.Location = new System.Drawing.Point(164, 13);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(300, 25);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            //
            // dgvCart
            //
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(12, 47);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(620, 541);
            this.dgvCart.TabIndex = 2;
            this.dgvCart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCart_KeyDown);
            //
            // lblPhoneCaption
            //
            this.lblPhoneCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoneCaption.AutoSize = true;
            this.lblPhoneCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhoneCaption.Location = new System.Drawing.Point(650, 16);
            this.lblPhoneCaption.Name = "lblPhoneCaption";
            this.lblPhoneCaption.Size = new System.Drawing.Size(112, 19);
            this.lblPhoneCaption.TabIndex = 3;
            this.lblPhoneCaption.Text = "SĐT thành viên:";
            //
            // txtCustomerPhone
            //
            this.txtCustomerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(765, 13);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(225, 25);
            this.txtCustomerPhone.TabIndex = 4;
            this.txtCustomerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerPhone_KeyDown);
            //
            // lblCustomerName
            //
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblCustomerName.ForeColor = System.Drawing.Color.DimGray;
            this.lblCustomerName.Location = new System.Drawing.Point(650, 44);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(340, 22);
            this.lblCustomerName.TabIndex = 5;
            this.lblCustomerName.Text = "Khách vãng lai";
            //
            // lblTotalCaption
            //
            this.lblTotalCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalCaption.Location = new System.Drawing.Point(650, 80);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(173, 17);
            this.lblTotalCaption.TabIndex = 6;
            this.lblTotalCaption.Text = "TỔNG CẦN THANH TOÁN:";
            //
            // lblTotalAmount
            //
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(0, 140, 70);
            this.lblTotalAmount.Location = new System.Drawing.Point(647, 99);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(343, 52);
            this.lblTotalAmount.TabIndex = 7;
            this.lblTotalAmount.Text = "0 đ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblCashCaption
            //
            this.lblCashCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashCaption.AutoSize = true;
            this.lblCashCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCashCaption.Location = new System.Drawing.Point(650, 160);
            this.lblCashCaption.Name = "lblCashCaption";
            this.lblCashCaption.Size = new System.Drawing.Size(133, 19);
            this.lblCashCaption.TabIndex = 8;
            this.lblCashCaption.Text = "Tiền khách đưa:";
            //
            // txtCashReceived
            //
            this.txtCashReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCashReceived.Location = new System.Drawing.Point(650, 182);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(340, 29);
            this.txtCashReceived.TabIndex = 9;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);
            //
            // lblChangeCaption
            //
            this.lblChangeCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChangeCaption.AutoSize = true;
            this.lblChangeCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChangeCaption.Location = new System.Drawing.Point(650, 220);
            this.lblChangeCaption.Name = "lblChangeCaption";
            this.lblChangeCaption.Size = new System.Drawing.Size(104, 19);
            this.lblChangeCaption.TabIndex = 10;
            this.lblChangeCaption.Text = "Tiền thừa trả:";
            //
            // lblChange
            //
            this.lblChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(760, 217);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(230, 24);
            this.lblChange.TabIndex = 11;
            this.lblChange.Text = "0 đ";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnCheckout
            //
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(34, 139, 60);
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(650, 255);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(340, 52);
            this.btnCheckout.TabIndex = 12;
            this.btnCheckout.Text = "THANH TOÁN  (F9)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            //
            // btnClearCart
            //
            this.btnClearCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(192, 48, 48);
            this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCart.FlatAppearance.BorderSize = 0;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(650, 315);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(340, 42);
            this.btnClearCart.TabIndex = 13;
            this.btnClearCart.Text = "HỦY GIỎ HÀNG";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            //
            // FormPOS
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblChangeCaption);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.lblCashCaption);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalCaption);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtCustomerPhone);
            this.Controls.Add(this.lblPhoneCaption);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblBarcodeCaption);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormPOS";
            this.Text = "Quầy Bán Hàng POS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBarcodeCaption;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblPhoneCaption;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCashCaption;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label lblChangeCaption;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
    }
}
