namespace SaleManagementWinApp
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            btnDangNhap = new Button();
            lblDangNhap = new Label();
            lblLogin = new Label();
            txtDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // btnDangNhap
            // 
            btnDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.ForeColor = Color.Purple;
            btnDangNhap.Image = (Image)resources.GetObject("btnDangNhap.Image");
            btnDangNhap.Location = new Point(139, 243);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(140, 41);
            btnDangNhap.TabIndex = 3;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lblDangNhap
            // 
            lblDangNhap.AutoSize = true;
            lblDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDangNhap.ForeColor = Color.GhostWhite;
            lblDangNhap.Location = new Point(32, 128);
            lblDangNhap.Name = "lblDangNhap";
            lblDangNhap.Size = new Size(101, 23);
            lblDangNhap.TabIndex = 1;
            lblDangNhap.Text = "Đăng Nhập";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.DarkBlue;
            lblLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogin.ForeColor = Color.GhostWhite;
            lblLogin.Location = new Point(83, 41);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(327, 37);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // txtDangNhap
            // 
            txtDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDangNhap.Location = new Point(139, 125);
            txtDangNhap.Name = "txtDangNhap";
            txtDangNhap.Size = new Size(287, 30);
            txtDangNhap.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhau.Location = new Point(139, 180);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(287, 30);
            txtMatKhau.TabIndex = 2;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.BackColor = Color.FromArgb(0, 0, 192);
            lblMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMatKhau.ForeColor = Color.GhostWhite;
            lblMatKhau.Location = new Point(32, 183);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(86, 23);
            lblMatKhau.TabIndex = 4;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnThoat.ForeColor = Color.Purple;
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.Location = new Point(306, 243);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 41);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(482, 325);
            Controls.Add(btnThoat);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(txtDangNhap);
            Controls.Add(lblLogin);
            Controls.Add(lblDangNhap);
            Controls.Add(btnDangNhap);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDangNhap;
        private Label lblDangNhap;
        private Label lblLogin;
        private TextBox txtDangNhap;
        private TextBox txtMatKhau;
        private Label lblMatKhau;
        private Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}