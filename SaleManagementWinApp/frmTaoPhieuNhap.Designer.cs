namespace SaleManagementWinApp
{
    partial class frmTaoPhieuNhap
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
            label1 = new Label();
            label2 = new Label();
            txtMaNV = new TextBox();
            label4 = new Label();
            dtpNgayNhap = new DateTimePicker();
            label5 = new Label();
            comboBox2 = new ComboBox();
            dgvPhieuNhap = new DataGridView();
            btnTaophieu = new Button();
            btnThoat = new Button();
            txtMaNCC = new TextBox();
            label3 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtMaPN = new TextBox();
            btnThemChiTiet = new Button();
            btnKiemTra = new Button();
            btnXemKhoHang = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(404, 20);
            label1.Name = "label1";
            label1.Size = new Size(248, 30);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ PHIẾU NHẬP";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 91);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 1;
            label2.Text = "MaNCC";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(117, 138);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(114, 23);
            txtMaNV.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(35, 184);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 5;
            label4.Text = "Ngày nhập";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(117, 184);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(172, 23);
            dtpNgayNhap.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(35, 227);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 7;
            label5.Text = "Trạng thái";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Đang xử lý", "Đã nhập", "Đã hủy" });
            comboBox2.Location = new Point(117, 227);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(114, 23);
            comboBox2.TabIndex = 8;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // dgvPhieuNhap
            // 
            dgvPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuNhap.Location = new Point(380, 91);
            dgvPhieuNhap.Name = "dgvPhieuNhap";
            dgvPhieuNhap.RowTemplate.Height = 25;
            dgvPhieuNhap.Size = new Size(627, 214);
            dgvPhieuNhap.TabIndex = 9;
            // 
            // btnTaophieu
            // 
            btnTaophieu.Location = new Point(143, 362);
            btnTaophieu.Name = "btnTaophieu";
            btnTaophieu.Size = new Size(99, 51);
            btnTaophieu.TabIndex = 11;
            btnTaophieu.Text = "Tạo phiếu ";
            btnTaophieu.UseVisualStyleBackColor = true;
            btnTaophieu.Click += btnTaophieu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(898, 362);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(109, 51);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtMaNCC
            // 
            txtMaNCC.Location = new Point(117, 91);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(114, 23);
            txtMaNCC.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(35, 138);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 3;
            label3.Text = "MaNV";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(380, 67);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 18;
            label7.Text = "Phiếu nhập";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(35, 263);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 19;
            label6.Text = "MaPN";
            // 
            // txtMaPN
            // 
            txtMaPN.Location = new Point(116, 260);
            txtMaPN.Name = "txtMaPN";
            txtMaPN.Size = new Size(113, 23);
            txtMaPN.TabIndex = 20;
            // 
            // btnThemChiTiet
            // 
            btnThemChiTiet.Location = new Point(299, 362);
            btnThemChiTiet.Name = "btnThemChiTiet";
            btnThemChiTiet.Size = new Size(94, 51);
            btnThemChiTiet.TabIndex = 21;
            btnThemChiTiet.Text = "Thêm chi tiết";
            btnThemChiTiet.UseVisualStyleBackColor = true;
            btnThemChiTiet.Click += btnThemChiTiet_Click;
            // 
            // btnKiemTra
            // 
            btnKiemTra.Location = new Point(447, 362);
            btnKiemTra.Name = "btnKiemTra";
            btnKiemTra.Size = new Size(100, 51);
            btnKiemTra.TabIndex = 22;
            btnKiemTra.Text = "Kiểm tra";
            btnKiemTra.UseVisualStyleBackColor = true;
            btnKiemTra.Click += btnKiemTra_Click;
            // 
            // btnXemKhoHang
            // 
            btnXemKhoHang.Location = new Point(609, 362);
            btnXemKhoHang.Name = "btnXemKhoHang";
            btnXemKhoHang.Size = new Size(108, 51);
            btnXemKhoHang.TabIndex = 23;
            btnXemKhoHang.Text = "Xem kho hàng";
            btnXemKhoHang.UseVisualStyleBackColor = true;
            btnXemKhoHang.Click += btnXemKhoHang_Click;
            // 
            // button1
            // 
            button1.Location = new Point(756, 376);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 24;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmTaoPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(1075, 450);
            Controls.Add(button1);
            Controls.Add(btnXemKhoHang);
            Controls.Add(btnKiemTra);
            Controls.Add(btnThemChiTiet);
            Controls.Add(txtMaPN);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtMaNCC);
            Controls.Add(btnThoat);
            Controls.Add(btnTaophieu);
            Controls.Add(dgvPhieuNhap);
            Controls.Add(comboBox2);
            Controls.Add(label5);
            Controls.Add(dtpNgayNhap);
            Controls.Add(label4);
            Controls.Add(txtMaNV);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmTaoPhieuNhap";
            Text = "frmTaoPhieuNhap";
            Load += frmTaoPhieuNhap_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtMaNV;
        private Label label4;
        private DateTimePicker dtpNgayNhap;
        private Label label5;
        private ComboBox comboBox2;
        private DataGridView dgvPhieuNhap;
        private Button btnTaophieu;
        private Button btnThoat;
        private TextBox txtMaNCC;
        private Label label3;
        private Label label7;
        private Label label6;
        private TextBox txtMaPN;
        private Button btnThemChiTiet;
        private Button btnKiemTra;
        private Button btnXemKhoHang;
        private Button button1;
    }
}