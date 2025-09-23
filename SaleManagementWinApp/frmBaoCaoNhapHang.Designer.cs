namespace SaleManagementWinApp
{
    partial class frmBaoCaoNhapHang
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            lblBaoCaoNhapHang = new Label();
            lblNgayBatDau = new Label();
            dtpNgayBatDau = new DateTimePicker();
            lblNgayKetThuc = new Label();
            dtpNgayKetThuc = new DateTimePicker();
            comboBox1 = new ComboBox();
            lblLoaiThoiGian = new Label();
            btnXemBaoCao = new Button();
            dgvSanPhamNhap = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dgvNhaCungCap = new DataGridView();
            lblTongChiPhi = new Label();
            dgvSoLuong = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamNhap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSoLuong).BeginInit();
            SuspendLayout();
            // 
            // lblBaoCaoNhapHang
            // 
            lblBaoCaoNhapHang.AutoSize = true;
            lblBaoCaoNhapHang.ForeColor = Color.White;
            lblBaoCaoNhapHang.ImageAlign = ContentAlignment.TopCenter;
            lblBaoCaoNhapHang.Location = new Point(474, 18);
            lblBaoCaoNhapHang.Name = "lblBaoCaoNhapHang";
            lblBaoCaoNhapHang.Size = new Size(251, 30);
            lblBaoCaoNhapHang.TabIndex = 0;
            lblBaoCaoNhapHang.Text = "BÁO CÁO NHẬP HÀNG";
            // 
            // lblNgayBatDau
            // 
            lblNgayBatDau.AutoSize = true;
            lblNgayBatDau.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNgayBatDau.ForeColor = Color.White;
            lblNgayBatDau.Location = new Point(48, 71);
            lblNgayBatDau.Name = "lblNgayBatDau";
            lblNgayBatDau.Size = new Size(78, 15);
            lblNgayBatDau.TabIndex = 1;
            lblNgayBatDau.Text = "Ngày bắt đầu";
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpNgayBatDau.Location = new Point(168, 63);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(200, 23);
            dtpNgayBatDau.TabIndex = 2;
            // 
            // lblNgayKetThuc
            // 
            lblNgayKetThuc.AutoSize = true;
            lblNgayKetThuc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNgayKetThuc.ForeColor = Color.White;
            lblNgayKetThuc.Location = new Point(48, 125);
            lblNgayKetThuc.Name = "lblNgayKetThuc";
            lblNgayKetThuc.RightToLeft = RightToLeft.No;
            lblNgayKetThuc.Size = new Size(81, 15);
            lblNgayKetThuc.TabIndex = 3;
            lblNgayKetThuc.Text = "Ngày kết thúc";
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpNgayKetThuc.Location = new Point(168, 117);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(200, 23);
            dtpNgayKetThuc.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Ngày", "Tuần", "Tháng", "Quý", "Năm" });
            comboBox1.Location = new Point(168, 172);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            // 
            // lblLoaiThoiGian
            // 
            lblLoaiThoiGian.AutoSize = true;
            lblLoaiThoiGian.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoaiThoiGian.ForeColor = Color.White;
            lblLoaiThoiGian.Location = new Point(48, 175);
            lblLoaiThoiGian.Name = "lblLoaiThoiGian";
            lblLoaiThoiGian.Size = new Size(79, 15);
            lblLoaiThoiGian.TabIndex = 6;
            lblLoaiThoiGian.Text = "Loại thời gian";
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnXemBaoCao.ForeColor = Color.Black;
            btnXemBaoCao.Location = new Point(100, 275);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(163, 43);
            btnXemBaoCao.TabIndex = 7;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // dgvSanPhamNhap
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSanPhamNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSanPhamNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPhamNhap.Location = new Point(422, 90);
            dgvSanPhamNhap.Name = "dgvSanPhamNhap";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSanPhamNhap.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPhamNhap.RowTemplate.Height = 25;
            dgvSanPhamNhap.Size = new Size(404, 151);
            dgvSanPhamNhap.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(422, 69);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 9;
            label1.Text = "Sản phẩm đã nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(422, 257);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 10;
            label2.Text = "Nhà cung cấp";
            // 
            // dgvNhaCungCap
            // 
            dgvNhaCungCap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNhaCungCap.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNhaCungCap.Location = new Point(422, 275);
            dgvNhaCungCap.Name = "dgvNhaCungCap";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvNhaCungCap.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvNhaCungCap.RowTemplate.Height = 25;
            dgvNhaCungCap.Size = new Size(404, 150);
            dgvNhaCungCap.TabIndex = 11;
            // 
            // lblTongChiPhi
            // 
            lblTongChiPhi.AutoSize = true;
            lblTongChiPhi.ForeColor = Color.White;
            lblTongChiPhi.Location = new Point(137, 385);
            lblTongChiPhi.Name = "lblTongChiPhi";
            lblTongChiPhi.Size = new Size(76, 30);
            lblTongChiPhi.TabIndex = 12;
            lblTongChiPhi.Text = "label3";
            // 
            // dgvSoLuong
            // 
            dgvSoLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvSoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            dgvSoLuong.Location = new Point(422, 461);
            dgvSoLuong.Name = "dgvSoLuong";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvSoLuong.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvSoLuong.RowTemplate.Height = 25;
            dgvSoLuong.Size = new Size(404, 181);
            dgvSoLuong.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(422, 443);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 14;
            label3.Text = "Số lượng đã nhập";
            // 
            // frmBaoCaoNhapHang
            // 
            AutoScaleDimensions = new SizeF(13F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(1370, 749);
            Controls.Add(label3);
            Controls.Add(dgvSoLuong);
            Controls.Add(lblTongChiPhi);
            Controls.Add(dgvNhaCungCap);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvSanPhamNhap);
            Controls.Add(btnXemBaoCao);
            Controls.Add(lblLoaiThoiGian);
            Controls.Add(comboBox1);
            Controls.Add(dtpNgayKetThuc);
            Controls.Add(lblNgayKetThuc);
            Controls.Add(dtpNgayBatDau);
            Controls.Add(lblNgayBatDau);
            Controls.Add(lblBaoCaoNhapHang);
            Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(6);
            Name = "frmBaoCaoNhapHang";
            Text = "BaoCaoNhapHang";
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamNhap).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBaoCaoNhapHang;
        private Label lblNgayBatDau;
        private DateTimePicker dtpNgayBatDau;
        private Label lblNgayKetThuc;
        private DateTimePicker dtpNgayKetThuc;
        private ComboBox comboBox1;
        private Label lblLoaiThoiGian;
        private Button btnXemBaoCao;
        private DataGridView dgvSanPhamNhap;
        private Label label1;
        private Label label2;
        private DataGridView dgvNhaCungCap;
        private Label lblTongChiPhi;
        private DataGridView dgvSoLuong;
        private Label label3;
    }
}