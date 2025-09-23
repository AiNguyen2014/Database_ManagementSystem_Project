namespace SaleManagementWinApp
{
    partial class frmBanHang
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
            pnlTop = new Panel();
            lblTenKH = new Label();
            btnTimKH = new Button();
            txtTimKiemKH = new TextBox();
            lblKhachHang = new Label();
            lblNhanVien = new Label();
            pnlLeft = new Panel();
            dgvSanPham = new DataGridView();
            panel1 = new Panel();
            txtTimKiemSP = new TextBox();
            label2 = new Label();
            cboLoaiSP = new ComboBox();
            label1 = new Label();
            lblDanhSachSP = new Label();
            pnlRight = new Panel();
            btnHuy = new Button();
            btnThanhToan = new Button();
            lblTongTienValue = new Label();
            lblTongTien = new Label();
            dgvChiTietHoaDon = new DataGridView();
            lblChiTietHD = new Label();
            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            panel1.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblTenKH);
            pnlTop.Controls.Add(btnTimKH);
            pnlTop.Controls.Add(txtTimKiemKH);
            pnlTop.Controls.Add(lblKhachHang);
            pnlTop.Controls.Add(lblNhanVien);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 2, 3, 2);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1104, 45);
            pnlTop.TabIndex = 0;
            // 
            // lblTenKH
            // 
            lblTenKH.AutoSize = true;
            lblTenKH.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenKH.ForeColor = Color.White;
            lblTenKH.Location = new Point(508, 14);
            lblTenKH.Name = "lblTenKH";
            lblTenKH.Size = new Size(106, 19);
            lblTenKH.TabIndex = 4;
            lblTenKH.Text = "Khách vãng lai";
            // 
            // btnTimKH
            // 
            btnTimKH.Location = new Point(411, 12);
            btnTimKH.Margin = new Padding(3, 2, 3, 2);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(82, 22);
            btnTimKH.TabIndex = 3;
            btnTimKH.Text = "Tìm";
            btnTimKH.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemKH
            // 
            txtTimKiemKH.Location = new Point(201, 13);
            txtTimKiemKH.Margin = new Padding(3, 2, 3, 2);
            txtTimKiemKH.Name = "txtTimKiemKH";
            txtTimKiemKH.Size = new Size(205, 23);
            txtTimKiemKH.TabIndex = 2;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.ForeColor = Color.White;
            lblKhachHang.Location = new Point(18, 15);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(128, 15);
            lblKhachHang.TabIndex = 1;
            lblKhachHang.Text = "Tìm khách hàng (SĐT):";
            // 
            // lblNhanVien
            // 
            lblNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNhanVien.AutoSize = true;
            lblNhanVien.ForeColor = Color.White;
            lblNhanVien.Location = new Point(875, 15);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(113, 15);
            lblNhanVien.TabIndex = 0;
            lblNhanVien.Text = "Nhân viên: [Tên NV]";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(dgvSanPham);
            pnlLeft.Controls.Add(panel1);
            pnlLeft.Controls.Add(lblDanhSachSP);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 45);
            pnlLeft.Margin = new Padding(3, 2, 3, 2);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(9, 8, 9, 8);
            pnlLeft.Size = new Size(525, 460);
            pnlLeft.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.Location = new Point(9, 85);
            dgvSanPham.Margin = new Padding(3, 2, 3, 2);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.RowTemplate.Height = 29;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(507, 367);
            dgvSanPham.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtTimKiemSP);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cboLoaiSP);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(9, 33);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 52);
            panel1.TabIndex = 1;
            // 
            // txtTimKiemSP
            // 
            txtTimKiemSP.Location = new Point(271, 18);
            txtTimKiemSP.Margin = new Padding(3, 2, 3, 2);
            txtTimKiemSP.Name = "txtTimKiemSP";
            txtTimKiemSP.Size = new Size(228, 23);
            txtTimKiemSP.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(271, 1);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Tìm theo tên SP";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(9, 17);
            cboLoaiSP.Margin = new Padding(3, 2, 3, 2);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(219, 23);
            cboLoaiSP.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(9, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Lọc theo loại SP";
            // 
            // lblDanhSachSP
            // 
            lblDanhSachSP.AutoSize = true;
            lblDanhSachSP.Dock = DockStyle.Top;
            lblDanhSachSP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDanhSachSP.ForeColor = Color.White;
            lblDanhSachSP.Location = new Point(9, 8);
            lblDanhSachSP.Name = "lblDanhSachSP";
            lblDanhSachSP.Padding = new Padding(0, 0, 0, 4);
            lblDanhSachSP.Size = new Size(193, 25);
            lblDanhSachSP.TabIndex = 0;
            lblDanhSachSP.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(btnHuy);
            pnlRight.Controls.Add(btnThanhToan);
            pnlRight.Controls.Add(lblTongTienValue);
            pnlRight.Controls.Add(lblTongTien);
            pnlRight.Controls.Add(dgvChiTietHoaDon);
            pnlRight.Controls.Add(lblChiTietHD);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(525, 45);
            pnlRight.Margin = new Padding(3, 2, 3, 2);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(9, 8, 9, 8);
            pnlRight.Size = new Size(579, 460);
            pnlRight.TabIndex = 2;
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHuy.BackColor = Color.IndianRed;
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(280, 412);
            btnHuy.Margin = new Padding(3, 2, 3, 2);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(131, 38);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy Hóa Đơn";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThanhToan.BackColor = Color.SeaGreen;
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(429, 412);
            btnThanhToan.Margin = new Padding(3, 2, 3, 2);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(140, 38);
            btnThanhToan.TabIndex = 4;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // lblTongTienValue
            // 
            lblTongTienValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongTienValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongTienValue.ForeColor = Color.Yellow;
            lblTongTienValue.Location = new Point(350, 375);
            lblTongTienValue.Name = "lblTongTienValue";
            lblTongTienValue.Size = new Size(219, 24);
            lblTongTienValue.TabIndex = 3;
            lblTongTienValue.Text = "0 VNĐ";
            lblTongTienValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongTien.ForeColor = Color.White;
            lblTongTien.Location = new Point(18, 376);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(87, 21);
            lblTongTien.TabIndex = 2;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // dgvChiTietHoaDon
            // 
            dgvChiTietHoaDon.AllowUserToAddRows = false;
            dgvChiTietHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHoaDon.Location = new Point(9, 33);
            dgvChiTietHoaDon.Margin = new Padding(3, 2, 3, 2);
            dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            dgvChiTietHoaDon.RowHeadersWidth = 51;
            dgvChiTietHoaDon.RowTemplate.Height = 29;
            dgvChiTietHoaDon.Size = new Size(562, 330);
            dgvChiTietHoaDon.TabIndex = 1;
            // 
            // lblChiTietHD
            // 
            lblChiTietHD.AutoSize = true;
            lblChiTietHD.Dock = DockStyle.Top;
            lblChiTietHD.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblChiTietHD.ForeColor = Color.White;
            lblChiTietHD.Location = new Point(9, 8);
            lblChiTietHD.Name = "lblChiTietHD";
            lblChiTietHD.Padding = new Padding(0, 0, 0, 4);
            lblChiTietHD.Size = new Size(153, 25);
            lblChiTietHD.TabIndex = 0;
            lblChiTietHD.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // frmBanHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(1104, 505);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmBanHang";
            Text = "Tạo Hóa Đơn Bán Hàng";
            WindowState = FormWindowState.Maximized;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblNhanVien;
        private Panel pnlLeft;
        private Panel pnlRight;
        private TextBox txtTimKiemKH;
        private Label lblKhachHang;
        private Label lblTenKH;
        private Button btnTimKH;
        private Label lblDanhSachSP;
        private Panel panel1;
        private Label label1;
        private ComboBox cboLoaiSP;
        private TextBox txtTimKiemSP;
        private Label label2;
        private DataGridView dgvSanPham;
        private Label lblChiTietHD;
        private DataGridView dgvChiTietHoaDon;
        private Label lblTongTien;
        private Label lblTongTienValue;
        private Button btnThanhToan;
        private Button btnHuy;
    }
}