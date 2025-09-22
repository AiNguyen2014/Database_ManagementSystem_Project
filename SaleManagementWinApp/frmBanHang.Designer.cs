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
            label4 = new Label();
            label3 = new Label();
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
            cboPhuongThuc = new ComboBox();
            lbPhuongThuc = new Label();
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
            pnlTop.Controls.Add(label4);
            pnlTop.Controls.Add(label3);
            pnlTop.Controls.Add(lblTenKH);
            pnlTop.Controls.Add(btnTimKH);
            pnlTop.Controls.Add(txtTimKiemKH);
            pnlTop.Controls.Add(lblKhachHang);
            pnlTop.Controls.Add(lblNhanVien);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1228, 95);
            pnlTop.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(680, 58);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 6;
            label4.Text = "Thời gian ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(20, 55);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 5;
            label3.Text = "Tên khách hàng: ";
            // 
            // lblTenKH
            // 
            lblTenKH.AutoSize = true;
            lblTenKH.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenKH.ForeColor = Color.White;
            lblTenKH.Location = new Point(230, 55);
            lblTenKH.Name = "lblTenKH";
            lblTenKH.Size = new Size(126, 23);
            lblTenKH.TabIndex = 4;
            lblTenKH.Text = "Khách vãng lai";
            // 
            // btnTimKH
            // 
            btnTimKH.Location = new Point(470, 16);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(94, 29);
            btnTimKH.TabIndex = 3;
            btnTimKH.Text = "Tìm";
            btnTimKH.UseVisualStyleBackColor = true;
            btnTimKH.Click += btnTimKH_Click;
            // 
            // txtTimKiemKH
            // 
            txtTimKiemKH.Location = new Point(230, 17);
            txtTimKiemKH.Name = "txtTimKiemKH";
            txtTimKiemKH.Size = new Size(234, 27);
            txtTimKiemKH.TabIndex = 2;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.ForeColor = Color.White;
            lblKhachHang.Location = new Point(20, 20);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(157, 20);
            lblKhachHang.TabIndex = 1;
            lblKhachHang.Text = "Tìm khách hàng (SĐT):";
            // 
            // lblNhanVien
            // 
            lblNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNhanVien.AutoSize = true;
            lblNhanVien.ForeColor = Color.White;
            lblNhanVien.Location = new Point(680, 16);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(139, 20);
            lblNhanVien.TabIndex = 0;
            lblNhanVien.Text = "Nhân viên: [Tên NV]";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(dgvSanPham);
            pnlLeft.Controls.Add(panel1);
            pnlLeft.Controls.Add(lblDanhSachSP);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 95);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(10);
            pnlLeft.Size = new Size(619, 577);
            pnlLeft.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.Location = new Point(10, 114);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.RowTemplate.Height = 29;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(599, 453);
            dgvSanPham.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtTimKiemSP);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cboLoaiSP);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(599, 70);
            panel1.TabIndex = 1;
            // 
            // txtTimKiemSP
            // 
            txtTimKiemSP.Location = new Point(288, 24);
            txtTimKiemSP.Name = "txtTimKiemSP";
            txtTimKiemSP.Size = new Size(196, 27);
            txtTimKiemSP.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(306, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 2;
            label2.Text = "Tìm theo tên SP";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(10, 23);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(185, 28);
            cboLoaiSP.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 0;
            label1.Text = "Lọc theo loại SP";
            // 
            // lblDanhSachSP
            // 
            lblDanhSachSP.AutoSize = true;
            lblDanhSachSP.Dock = DockStyle.Top;
            lblDanhSachSP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDanhSachSP.ForeColor = Color.White;
            lblDanhSachSP.Location = new Point(10, 10);
            lblDanhSachSP.Name = "lblDanhSachSP";
            lblDanhSachSP.Padding = new Padding(0, 0, 0, 6);
            lblDanhSachSP.Size = new Size(243, 34);
            lblDanhSachSP.TabIndex = 0;
            lblDanhSachSP.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(cboPhuongThuc);
            pnlRight.Controls.Add(lbPhuongThuc);
            pnlRight.Controls.Add(btnHuy);
            pnlRight.Controls.Add(btnThanhToan);
            pnlRight.Controls.Add(lblTongTienValue);
            pnlRight.Controls.Add(lblTongTien);
            pnlRight.Controls.Add(dgvChiTietHoaDon);
            pnlRight.Controls.Add(lblChiTietHD);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(619, 95);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(10);
            pnlRight.Size = new Size(609, 577);
            pnlRight.TabIndex = 2;
            // 
            // cboPhuongThuc
            // 
            cboPhuongThuc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cboPhuongThuc.FormattingEnabled = true;
            cboPhuongThuc.Location = new Point(393, 418);
            cboPhuongThuc.Name = "cboPhuongThuc";
            cboPhuongThuc.Size = new Size(206, 28);
            cboPhuongThuc.TabIndex = 7;
            // 
            // lbPhuongThuc
            // 
            lbPhuongThuc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbPhuongThuc.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbPhuongThuc.ForeColor = SystemColors.ControlLightLight;
            lbPhuongThuc.Location = new Point(20, 418);
            lbPhuongThuc.Name = "lbPhuongThuc";
            lbPhuongThuc.Size = new Size(206, 23);
            lbPhuongThuc.TabIndex = 6;
            lbPhuongThuc.Text = "Phương thức thanh toán";
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHuy.BackColor = Color.IndianRed;
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(267, 514);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(150, 50);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy Hóa Đơn";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThanhToan.BackColor = Color.SeaGreen;
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(437, 514);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(160, 50);
            btnThanhToan.TabIndex = 4;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // lblTongTienValue
            // 
            lblTongTienValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongTienValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongTienValue.ForeColor = Color.Yellow;
            lblTongTienValue.Location = new Point(349, 460);
            lblTongTienValue.Name = "lblTongTienValue";
            lblTongTienValue.Size = new Size(250, 32);
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
            lblTongTien.Location = new Point(13, 464);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(108, 28);
            lblTongTien.TabIndex = 2;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // dgvChiTietHoaDon
            // 
            dgvChiTietHoaDon.AllowUserToAddRows = false;
            dgvChiTietHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHoaDon.Location = new Point(10, 44);
            dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            dgvChiTietHoaDon.RowHeadersWidth = 51;
            dgvChiTietHoaDon.RowTemplate.Height = 29;
            dgvChiTietHoaDon.Size = new Size(589, 362);
            dgvChiTietHoaDon.TabIndex = 1;
            // 
            // lblChiTietHD
            // 
            lblChiTietHD.AutoSize = true;
            lblChiTietHD.Dock = DockStyle.Top;
            lblChiTietHD.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblChiTietHD.ForeColor = Color.White;
            lblChiTietHD.Location = new Point(10, 10);
            lblChiTietHD.Name = "lblChiTietHD";
            lblChiTietHD.Padding = new Padding(0, 0, 0, 6);
            lblChiTietHD.Size = new Size(195, 34);
            lblChiTietHD.TabIndex = 0;
            lblChiTietHD.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // frmBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(1228, 672);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Name = "frmBanHang";
            Text = "Tạo Hóa Đơn Bán Hàng";
            WindowState = FormWindowState.Maximized;
            Load += frmBanHang_Load;
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
        private Label label3;
        private Label lbPhuongThuc;
        private ComboBox cboPhuongThuc;
        private Label label4;
    }
}