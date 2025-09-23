namespace SaleManagementWinApp
{
    partial class frmChiTietPhieuNhap
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
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblGiaNhap = new Label();
            txtGiaNhap = new TextBox();
            btnLuu = new Button();
            btnThoat = new Button();
            dgvChiTiet = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.ForeColor = Color.White;
            lblMaSP.Location = new Point(38, 52);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(37, 15);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "MaSP";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(176, 52);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(108, 23);
            txtMaSP.TabIndex = 1;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.ForeColor = Color.White;
            lblSoLuong.Location = new Point(38, 90);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(54, 15);
            lblSoLuong.TabIndex = 2;
            lblSoLuong.Text = "SoLuong";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(176, 90);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(108, 23);
            txtSoLuong.TabIndex = 3;
            // 
            // lblGiaNhap
            // 
            lblGiaNhap.AutoSize = true;
            lblGiaNhap.ForeColor = Color.White;
            lblGiaNhap.Location = new Point(38, 128);
            lblGiaNhap.Name = "lblGiaNhap";
            lblGiaNhap.Size = new Size(53, 15);
            lblGiaNhap.TabIndex = 4;
            lblGiaNhap.Text = "GiaNhap";
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Location = new Point(176, 128);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(108, 23);
            txtGiaNhap.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(157, 221);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(104, 55);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(351, 221);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 55);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(391, 40);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowTemplate.Height = 25;
            dgvChiTiet.Size = new Size(374, 172);
            dgvChiTiet.TabIndex = 8;
            // 
            // frmChiTietPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvChiTiet);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(txtGiaNhap);
            Controls.Add(lblGiaNhap);
            Controls.Add(txtSoLuong);
            Controls.Add(lblSoLuong);
            Controls.Add(txtMaSP);
            Controls.Add(lblMaSP);
            Name = "frmChiTietPhieuNhap";
            Text = "ChiTietPhieuNhap";
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaSP;
        private TextBox txtMaSP;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblGiaNhap;
        private TextBox txtGiaNhap;
        private Button btnLuu;
        private Button btnThoat;
        private DataGridView dgvChiTiet;
    }
}