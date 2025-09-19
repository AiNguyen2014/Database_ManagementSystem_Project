namespace SaleManagementWinApp
{
    partial class frmNguoiDungUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNguoiDungUpdate));
            btnClose = new Button();
            btnUpdate = new Button();
            txtMaNguoiDung = new TextBox();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            lblDienThoai = new Label();
            lblDiaChi = new Label();
            lblTenNV = new Label();
            lblMaNV = new Label();
            lblCNKH = new Label();
            cboLoaiNguoiDung = new ComboBox();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.Purple;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(332, 261);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 41);
            btnClose.TabIndex = 107;
            btnClose.Text = "Thoát";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.Purple;
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.Location = new Point(159, 261);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 41);
            btnUpdate.TabIndex = 106;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtMaNguoiDung
            // 
            txtMaNguoiDung.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMaNguoiDung.Location = new Point(159, 161);
            txtMaNguoiDung.Name = "txtMaNguoiDung";
            txtMaNguoiDung.Size = new Size(290, 30);
            txtMaNguoiDung.TabIndex = 102;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhau.Location = new Point(159, 120);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(290, 30);
            txtMatKhau.TabIndex = 101;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenDangNhap.Location = new Point(159, 79);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(290, 30);
            txtTenDangNhap.TabIndex = 115;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDienThoai.ForeColor = Color.GhostWhite;
            lblDienThoai.Location = new Point(25, 206);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(135, 23);
            lblDienThoai.TabIndex = 112;
            lblDienThoai.Text = "Loại người dùng";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDiaChi.ForeColor = Color.GhostWhite;
            lblDiaChi.Location = new Point(25, 161);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(128, 23);
            lblDiaChi.TabIndex = 111;
            lblDiaChi.Text = "Mã người dùng";
            // 
            // lblTenNV
            // 
            lblTenNV.AutoSize = true;
            lblTenNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTenNV.ForeColor = Color.GhostWhite;
            lblTenNV.Location = new Point(25, 120);
            lblTenNV.Name = "lblTenNV";
            lblTenNV.Size = new Size(82, 23);
            lblTenNV.TabIndex = 110;
            lblTenNV.Text = "Mật khẩu";
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaNV.ForeColor = Color.GhostWhite;
            lblMaNV.Location = new Point(25, 82);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(124, 23);
            lblMaNV.TabIndex = 109;
            lblMaNV.Text = "Tên đăng nhập";
            // 
            // lblCNKH
            // 
            lblCNKH.AutoSize = true;
            lblCNKH.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblCNKH.ForeColor = Color.GhostWhite;
            lblCNKH.Location = new Point(79, 20);
            lblCNKH.Name = "lblCNKH";
            lblCNKH.Size = new Size(339, 37);
            lblCNKH.TabIndex = 108;
            lblCNKH.Text = "CẬP NHẬT NGƯỜI DÙNG";
            // 
            // cboLoaiNguoiDung
            // 
            cboLoaiNguoiDung.FormattingEnabled = true;
            cboLoaiNguoiDung.Items.AddRange(new object[] { "Quản trị", "Khách hàng", "Nhân Viên" });
            cboLoaiNguoiDung.Location = new Point(159, 205);
            cboLoaiNguoiDung.Name = "cboLoaiNguoiDung";
            cboLoaiNguoiDung.Size = new Size(290, 28);
            cboLoaiNguoiDung.TabIndex = 116;
            // 
            // frmNguoiDungUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(484, 343);
            Controls.Add(cboLoaiNguoiDung);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(txtMaNguoiDung);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblDienThoai);
            Controls.Add(lblDiaChi);
            Controls.Add(lblTenNV);
            Controls.Add(lblMaNV);
            Controls.Add(lblCNKH);
            Name = "frmNguoiDungUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNguoiDungUpdate";
            Load += frmNguoiDungUpdate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private Button btnUpdate;
        private TextBox txtMaNguoiDung;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblDienThoai;
        private Label lblDiaChi;
        private Label lblTenNV;
        private Label lblMaNV;
        private Label lblCNKH;
        private ComboBox cboLoaiNguoiDung;
    }
}