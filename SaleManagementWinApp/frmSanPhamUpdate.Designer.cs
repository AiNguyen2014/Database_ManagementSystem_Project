namespace SaleManagementWinApp
{
    partial class frmSanPhamUpdate
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
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.lblHanSuDung = new System.Windows.Forms.Label();
            this.dtpHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(130, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẬP NHẬT SẢN PHẨM";
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.ForeColor = System.Drawing.Color.White;
            this.lblMaSP.Location = new System.Drawing.Point(40, 90);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(98, 20);
            this.lblMaSP.Text = "Mã sản phẩm";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(170, 87);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(280, 27);
            this.txtMaSP.TabIndex = 0;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(170, 127);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(280, 27);
            this.txtTenSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.ForeColor = System.Drawing.Color.White;
            this.lblTenSP.Location = new System.Drawing.Point(40, 130);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(100, 20);
            this.lblTenSP.Text = "Tên sản phẩm";
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.ForeColor = System.Drawing.Color.White;
            this.lblSoLuongTon.Location = new System.Drawing.Point(40, 250);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(95, 20);
            this.lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // numSoLuongTon
            // 
            this.numSoLuongTon.Location = new System.Drawing.Point(170, 248);
            this.numSoLuongTon.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numSoLuongTon.Name = "numSoLuongTon";
            this.numSoLuongTon.Size = new System.Drawing.Size(150, 27);
            this.numSoLuongTon.TabIndex = 4;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(170, 167);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(280, 27);
            this.txtGiaNhap.TabIndex = 2;
            // 
            // lblGiaNhap
            // 
            this.lblGiaNhap.AutoSize = true;
            this.lblGiaNhap.ForeColor = System.Drawing.Color.White;
            this.lblGiaNhap.Location = new System.Drawing.Point(40, 170);
            this.lblGiaNhap.Name = "lblGiaNhap";
            this.lblGiaNhap.Size = new System.Drawing.Size(69, 20);
            this.lblGiaNhap.Text = "Giá nhập";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(170, 207);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(280, 27);
            this.txtGiaBan.TabIndex = 3;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.ForeColor = System.Drawing.Color.White;
            this.lblGiaBan.Location = new System.Drawing.Point(40, 210);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(62, 20);
            this.lblGiaBan.Text = "Giá bán";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.ForeColor = System.Drawing.Color.White;
            this.lblDonViTinh.Location = new System.Drawing.Point(40, 290);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(78, 20);
            this.lblDonViTinh.Text = "Đơn vị tính";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(170, 287);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(280, 27);
            this.txtDonViTinh.TabIndex = 5;
            // 
            // lblHanSuDung
            // 
            this.lblHanSuDung.AutoSize = true;
            this.lblHanSuDung.ForeColor = System.Drawing.Color.White;
            this.lblHanSuDung.Location = new System.Drawing.Point(40, 333);
            this.lblHanSuDung.Name = "lblHanSuDung";
            this.lblHanSuDung.Size = new System.Drawing.Size(93, 20);
            this.lblHanSuDung.Text = "Hạn sử dụng";
            // 
            // dtpHanSuDung
            // 
            this.dtpHanSuDung.CustomFormat = "dd/MM/yyyy";
            this.dtpHanSuDung.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanSuDung.Location = new System.Drawing.Point(170, 328);
            this.dtpHanSuDung.Name = "dtpHanSuDung";
            this.dtpHanSuDung.Size = new System.Drawing.Size(280, 27);
            this.dtpHanSuDung.TabIndex = 6;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai.Location = new System.Drawing.Point(40, 370);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(75, 20);
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] { "Còn hàng", "Hết hàng", "Ngừng kinh doanh" });
            this.cboTrangThai.Location = new System.Drawing.Point(170, 367);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(280, 28);
            this.cboTrangThai.TabIndex = 7;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(130, 420);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(308, 420);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 40);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmSanPhamUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(557, 489);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.dtpHanSuDung);
            this.Controls.Add(this.lblHanSuDung);
            this.Controls.Add(this.txtDonViTinh);
            this.Controls.Add(this.lblDonViTinh);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.lblGiaNhap);
            this.Controls.Add(this.numSoLuongTon);
            this.Controls.Add(this.lblSoLuongTon);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lblMaSP);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSanPhamUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật sản phẩm";
            this.Load += new System.EventHandler(this.frmSanPhamUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblMaSP;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private Label lblTenSP;
        private Label lblSoLuongTon;
        private NumericUpDown numSoLuongTon;
        private TextBox txtGiaNhap;
        private Label lblGiaNhap;
        private TextBox txtGiaBan;
        private Label lblGiaBan;
        private Label lblDonViTinh;
        private TextBox txtDonViTinh;
        private Label lblHanSuDung;
        private DateTimePicker dtpHanSuDung;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnLuu;
        private Button btnThoat;
    }
}