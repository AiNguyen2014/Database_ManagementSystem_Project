namespace SaleManagementWinApp
{
    partial class frmKiemTraPhieuNhap
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
            lblTrangThai = new Label();
            comboBox1 = new ComboBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            dgvChiTiet = new DataGridView();
            btnXacNhan = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.ForeColor = Color.White;
            lblTrangThai.Location = new Point(41, 63);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(60, 15);
            lblTrangThai.TabIndex = 0;
            lblTrangThai.Text = "Trạng thái";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(162, 55);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.ForeColor = Color.White;
            lblGhiChu.Location = new Point(41, 113);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(48, 15);
            lblGhiChu.TabIndex = 2;
            lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(162, 105);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(121, 23);
            txtGhiChu.TabIndex = 3;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(348, 55);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowTemplate.Height = 25;
            dgvChiTiet.Size = new Size(440, 150);
            dgvChiTiet.TabIndex = 4;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(188, 283);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(112, 48);
            btnXacNhan.TabIndex = 5;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(385, 283);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(117, 48);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // frmKiemTraPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(dgvChiTiet);
            Controls.Add(txtGhiChu);
            Controls.Add(lblGhiChu);
            Controls.Add(comboBox1);
            Controls.Add(lblTrangThai);
            Name = "frmKiemTraPhieuNhap";
            Text = "frmKiemTraPhieuNhap";
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTrangThai;
        private ComboBox comboBox1;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private DataGridView dgvChiTiet;
        private Button btnXacNhan;
        private Button btnHuy;
    }
}