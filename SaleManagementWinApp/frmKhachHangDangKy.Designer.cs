namespace SaleManagementWinApp
{
    partial class frmKhachHangDangKy
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(298, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "Họ và tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(190, 87);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(280, 27);
            this.txtHoTen.TabIndex = 0;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(190, 137);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(280, 27);
            this.txtSoDienThoai.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.Text = "Số điện thoại";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(190, 187);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(280, 27);
            this.txtDiaChi.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(40, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.Text = "Giới tính";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(190, 237);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(150, 28);
            this.cboGioiTinh.TabIndex = 3;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(190, 287);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(280, 27);
            this.txtTenDangNhap.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(40, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.Text = "Tên đăng nhập";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(190, 337);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(280, 27);
            this.txtMatKhau.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(40, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.Text = "Mật khẩu";
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Location = new System.Drawing.Point(190, 387);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.PasswordChar = '*';
            this.txtXacNhanMK.Size = new System.Drawing.Size(280, 27);
            this.txtXacNhanMK.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(40, 390);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 20);
            this.label8.Text = "Xác nhận mật khẩu";
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(120, 450);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(120, 40);
            this.btnDangKy.TabIndex = 7;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(298, 450);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 40);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // frmKhachHangDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(534, 521);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.txtXacNhanMK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmKhachHangDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản khách hàng";
            this.Load += new System.EventHandler(this.frmKhachHangDangKy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label2;
        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private Label label3;
        private TextBox txtDiaChi;
        private Label label4;
        private Label label5;
        private ComboBox cboGioiTinh;
        private TextBox txtTenDangNhap;
        private Label label6;
        private TextBox txtMatKhau;
        private Label label7;
        private TextBox txtXacNhanMK;
        private Label label8;
        private Button btnDangKy;
        private Button btnThoat;
    }
}