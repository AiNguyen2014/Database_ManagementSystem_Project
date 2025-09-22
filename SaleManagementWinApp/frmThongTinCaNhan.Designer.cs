namespace SaleManagementWinApp
{
    partial class frmThongTinCaNhan
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
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtSoDienThoai = new TextBox();
            lblSoDienThoai = new Label();
            btnLuu = new Button();
            btnThoat = new Button();
            lblMatKhauMoi = new Label();
            txtMatKhauMoi = new TextBox();
            lblXacNhanMK = new Label();
            txtXacNhanMK = new TextBox();
            lblMatKhauCu = new Label();
            txtMatKhauCu = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(88, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(299, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblHoTen.ForeColor = Color.White;
            lblHoTen.Location = new Point(40, 100);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(84, 23);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ và tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtHoTen.Location = new Point(190, 97);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(260, 30);
            txtHoTen.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDiaChi.Location = new Point(190, 157);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(260, 30);
            txtDiaChi.TabIndex = 4;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDiaChi.ForeColor = Color.White;
            lblDiaChi.Location = new Point(40, 160);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(62, 23);
            lblDiaChi.TabIndex = 3;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSoDienThoai.Location = new Point(190, 217);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(260, 30);
            txtSoDienThoai.TabIndex = 6;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSoDienThoai.ForeColor = Color.White;
            lblSoDienThoai.Location = new Point(40, 220);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(111, 23);
            lblSoDienThoai.TabIndex = 5;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLuu.Location = new Point(95, 440);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 40);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu thay đổi";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnThoat.Location = new Point(273, 440);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 40);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMatKhauMoi.ForeColor = Color.White;
            lblMatKhauMoi.Location = new Point(40, 330);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(116, 23);
            lblMatKhauMoi.TabIndex = 5;
            lblMatKhauMoi.Text = "Mật khẩu mới";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhauMoi.Location = new Point(190, 327);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(260, 30);
            txtMatKhauMoi.TabIndex = 4;
            // 
            // lblXacNhanMK
            // 
            lblXacNhanMK.AutoSize = true;
            lblXacNhanMK.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblXacNhanMK.ForeColor = Color.White;
            lblXacNhanMK.Location = new Point(40, 380);
            lblXacNhanMK.Name = "lblXacNhanMK";
            lblXacNhanMK.Size = new Size(111, 23);
            lblXacNhanMK.TabIndex = 3;
            lblXacNhanMK.Text = "Xác nhận MK";
            // 
            // txtXacNhanMK
            // 
            txtXacNhanMK.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtXacNhanMK.Location = new Point(190, 377);
            txtXacNhanMK.Name = "txtXacNhanMK";
            txtXacNhanMK.PasswordChar = '*';
            txtXacNhanMK.Size = new Size(260, 30);
            txtXacNhanMK.TabIndex = 2;
            // 
            // lblMatKhauCu
            // 
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMatKhauCu.ForeColor = Color.White;
            lblMatKhauCu.Location = new Point(40, 280);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new Size(105, 23);
            lblMatKhauCu.TabIndex = 1;
            lblMatKhauCu.Text = "Mật khẩu cũ";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhauCu.Location = new Point(190, 277);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauCu.Size = new Size(260, 30);
            txtMatKhauCu.TabIndex = 0;
            // 
            // frmThongTinCaNhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(501, 520);
            Controls.Add(txtMatKhauCu);
            Controls.Add(lblMatKhauCu);
            Controls.Add(txtXacNhanMK);
            Controls.Add(lblXacNhanMK);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblSoDienThoai);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiaChi);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmThongTinCaNhan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cá nhân";
            Load += frmThongTinCaNhan_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblXacNhanMK;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauCu;
    }
}