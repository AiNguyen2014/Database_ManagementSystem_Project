namespace SaleManagementWinApp
{
    partial class frmNhanVienUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVienUpdate));
            btnClose = new Button();
            btnUpdate = new Button();
            txtDienThoaiNV = new MaskedTextBox();
            txtDiaChiNV = new TextBox();
            txtTenNV = new TextBox();
            txtMaNV = new TextBox();
            lblDienThoai = new Label();
            lblDiaChi = new Label();
            lblTenNV = new Label();
            lblMaNV = new Label();
            lblCNKH = new Label();
            txtNgaySinhNV = new MaskedTextBox();
            label1 = new Label();
            lblGioiTinh = new Label();
            chkGioiTinh = new CheckBox();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.Purple;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(321, 350);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 41);
            btnClose.TabIndex = 7;
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
            btnUpdate.Location = new Point(148, 350);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 41);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtDienThoaiNV
            // 
            txtDienThoaiNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDienThoaiNV.Location = new Point(148, 208);
            txtDienThoaiNV.Mask = "(84)00.000.0000";
            txtDienThoaiNV.Name = "txtDienThoaiNV";
            txtDienThoaiNV.Size = new Size(290, 30);
            txtDienThoaiNV.TabIndex = 3;
            // 
            // txtDiaChiNV
            // 
            txtDiaChiNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDiaChiNV.Location = new Point(148, 164);
            txtDiaChiNV.Name = "txtDiaChiNV";
            txtDiaChiNV.Size = new Size(290, 30);
            txtDiaChiNV.TabIndex = 2;
            // 
            // txtTenNV
            // 
            txtTenNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenNV.Location = new Point(148, 123);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(290, 30);
            txtTenNV.TabIndex = 1;
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMaNV.Location = new Point(148, 82);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(290, 30);
            txtMaNV.TabIndex = 100;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDienThoai.ForeColor = Color.GhostWhite;
            lblDienThoai.Location = new Point(14, 209);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(111, 23);
            lblDienThoai.TabIndex = 16;
            lblDienThoai.Text = "Số điện thoại";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDiaChi.ForeColor = Color.GhostWhite;
            lblDiaChi.Location = new Point(14, 164);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(65, 23);
            lblDiaChi.TabIndex = 15;
            lblDiaChi.Text = "Địa Chỉ";
            // 
            // lblTenNV
            // 
            lblTenNV.AutoSize = true;
            lblTenNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTenNV.ForeColor = Color.GhostWhite;
            lblTenNV.Location = new Point(14, 123);
            lblTenNV.Name = "lblTenNV";
            lblTenNV.Size = new Size(116, 23);
            lblTenNV.TabIndex = 14;
            lblTenNV.Text = "Tên nhân viên";
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaNV.ForeColor = Color.GhostWhite;
            lblMaNV.Location = new Point(14, 85);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(114, 23);
            lblMaNV.TabIndex = 13;
            lblMaNV.Text = "Mã nhân viên";
            // 
            // lblCNKH
            // 
            lblCNKH.AutoSize = true;
            lblCNKH.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblCNKH.ForeColor = Color.GhostWhite;
            lblCNKH.Location = new Point(68, 23);
            lblCNKH.Name = "lblCNKH";
            lblCNKH.Size = new Size(312, 37);
            lblCNKH.TabIndex = 12;
            lblCNKH.Text = "CẬP NHẬT NHÂN VIÊN";
            // 
            // txtNgaySinhNV
            // 
            txtNgaySinhNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNgaySinhNV.Location = new Point(148, 253);
            txtNgaySinhNV.Mask = "00/00/0000";
            txtNgaySinhNV.Name = "txtNgaySinhNV";
            txtNgaySinhNV.Size = new Size(290, 30);
            txtNgaySinhNV.TabIndex = 4;
            txtNgaySinhNV.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.GhostWhite;
            label1.Location = new Point(14, 254);
            label1.Name = "label1";
            label1.Size = new Size(86, 23);
            label1.TabIndex = 23;
            label1.Text = "Ngày sinh";
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblGioiTinh.ForeColor = Color.GhostWhite;
            lblGioiTinh.Location = new Point(14, 299);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(78, 23);
            lblGioiTinh.TabIndex = 24;
            lblGioiTinh.Text = "Giới Tính";
            // 
            // chkGioiTinh
            // 
            chkGioiTinh.AutoSize = true;
            chkGioiTinh.Location = new Point(149, 300);
            chkGioiTinh.Name = "chkGioiTinh";
            chkGioiTinh.Size = new Size(63, 24);
            chkGioiTinh.TabIndex = 5;
            chkGioiTinh.Text = "Nam";
            chkGioiTinh.UseVisualStyleBackColor = true;
            // 
            // frmNhanVienUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(472, 413);
            Controls.Add(chkGioiTinh);
            Controls.Add(lblGioiTinh);
            Controls.Add(txtNgaySinhNV);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(txtDienThoaiNV);
            Controls.Add(txtDiaChiNV);
            Controls.Add(txtTenNV);
            Controls.Add(txtMaNV);
            Controls.Add(lblDienThoai);
            Controls.Add(lblDiaChi);
            Controls.Add(lblTenNV);
            Controls.Add(lblMaNV);
            Controls.Add(lblCNKH);
            Name = "frmNhanVienUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân Viên Update";
            Load += frmNhanVienUpdate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnUpdate;
        private MaskedTextBox txtDienThoaiNV;
        private TextBox txtDiaChiNV;
        private TextBox txtTenNV;
        private TextBox txtMaNV;
        private Label lblDienThoai;
        private Label lblDiaChi;
        private Label lblTenNV;
        private Label lblMaNV;
        private Label lblCNKH;
        private MaskedTextBox txtNgaySinhNV;
        private Label label1;
        private Label lblGioiTinh;
        private CheckBox chkGioiTinh;
    }
}