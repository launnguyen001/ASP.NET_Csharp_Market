namespace FE
{
    partial class FormLogin
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
            lblTitle = new Label();
            lblUser = new Label();
            txtUser = new TextBox();
            lblPass = new Label();
            txtPass = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(110, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(289, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG\n";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(50, 105);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(63, 15);
            lblUser.TabIndex = 1;
            lblUser.Text = "Tài khoản:";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(140, 102);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(220, 23);
            txtUser.TabIndex = 2;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(50, 145);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(62, 15);
            lblPass.TabIndex = 3;
            lblPass.Text = "Mật khẩu:";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(140, 142);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(220, 23);
            txtPass.TabIndex = 4;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(140, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 35);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập hệ thống";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 281);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(lblPass);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Controls.Add(lblTitle);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Mini Supermarket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
    }
}