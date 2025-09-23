namespace SaleManagementWinApp
{
    partial class frmQuanLyNCC
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
            lable2 = new Label();
            txtMaNCC = new TextBox();
            label1 = new Label();
            txtTenNCC = new TextBox();
            lblDiachi = new Label();
            txtDiaChi = new TextBox();
            lblSoDienThoai = new Label();
            lblEmail = new Label();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            dgvNhacungcap = new DataGridView();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhacungcap).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.DarkBlue;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(222, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lable2
            // 
            lable2.AutoSize = true;
            lable2.ForeColor = Color.White;
            lable2.Location = new Point(46, 88);
            lable2.Name = "lable2";
            lable2.Size = new Size(49, 15);
            lable2.TabIndex = 1;
            lable2.Text = "MaNCC";
            // 
            // txtMaNCC
            // 
            txtMaNCC.Location = new Point(144, 80);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(165, 23);
            txtMaNCC.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(46, 130);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "TenNCC";
            // 
            // txtTenNCC
            // 
            txtTenNCC.Location = new Point(144, 122);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(165, 23);
            txtTenNCC.TabIndex = 4;
            // 
            // lblDiachi
            // 
            lblDiachi.AutoSize = true;
            lblDiachi.ForeColor = Color.White;
            lblDiachi.Location = new Point(46, 172);
            lblDiachi.Name = "lblDiachi";
            lblDiachi.Size = new Size(42, 15);
            lblDiachi.TabIndex = 5;
            lblDiachi.Text = "DiaChi";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(144, 164);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(165, 23);
            txtDiaChi.TabIndex = 6;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.ForeColor = Color.White;
            lblSoDienThoai.Location = new Point(46, 211);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(74, 15);
            lblSoDienThoai.TabIndex = 7;
            lblSoDienThoai.Text = "SoDienThoai";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(46, 249);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(144, 203);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(165, 23);
            txtSoDienThoai.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(144, 241);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(165, 23);
            txtEmail.TabIndex = 10;
            // 
            // dgvNhacungcap
            // 
            dgvNhacungcap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhacungcap.Location = new Point(372, 91);
            dgvNhacungcap.Name = "dgvNhacungcap";
            dgvNhacungcap.RowTemplate.Height = 25;
            dgvNhacungcap.Size = new Size(389, 181);
            dgvNhacungcap.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(83, 327);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(106, 41);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Location = new Point(242, 327);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(120, 41);
            btnCapNhat.TabIndex = 13;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(412, 327);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(103, 41);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(569, 327);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(93, 41);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmQuanLyNCC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnCapNhat);
            Controls.Add(btnThem);
            Controls.Add(dgvNhacungcap);
            Controls.Add(txtEmail);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblEmail);
            Controls.Add(lblSoDienThoai);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiachi);
            Controls.Add(txtTenNCC);
            Controls.Add(label1);
            Controls.Add(txtMaNCC);
            Controls.Add(lable2);
            Controls.Add(lblTitle);
            Name = "frmQuanLyNCC";
            Text = "frmQuanLyNCC";
            ((System.ComponentModel.ISupportInitialize)dgvNhacungcap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lable2;
        private TextBox txtMaNCC;
        private Label label1;
        private TextBox txtTenNCC;
        private Label lblDiachi;
        private TextBox txtDiaChi;
        private Label lblSoDienThoai;
        private Label lblEmail;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private DataGridView dgvNhacungcap;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnThoat;
    }
}