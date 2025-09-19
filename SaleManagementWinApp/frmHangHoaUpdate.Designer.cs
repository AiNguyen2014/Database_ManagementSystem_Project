namespace SaleManagementWinApp
{
    partial class frmHangHoaUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangHoaUpdate));
            lblDGBan = new Label();
            btnClose = new Button();
            btnUpdate = new Button();
            txtTenHH = new TextBox();
            txtMaHH = new TextBox();
            lblDGNhap = new Label();
            lblSL = new Label();
            lblTenHH = new Label();
            lblMaHH = new Label();
            lblCNHH = new Label();
            txtSoLuong = new NumericUpDown();
            txtDGNhap = new TextBox();
            txtDGBan = new TextBox();
            picAvatar = new PictureBox();
            btnUpload = new Button();
            txtGhiChu = new TextBox();
            lblGhiChu = new Label();
            ((System.ComponentModel.ISupportInitialize)txtSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // lblDGBan
            // 
            lblDGBan.AutoSize = true;
            lblDGBan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDGBan.ForeColor = Color.GhostWhite;
            lblDGBan.Location = new Point(403, 198);
            lblDGBan.Name = "lblDGBan";
            lblDGBan.Size = new Size(104, 23);
            lblDGBan.TabIndex = 38;
            lblDGBan.Text = "Đơn giá bán";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.Purple;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(632, 337);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 41);
            btnClose.TabIndex = 8;
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
            btnUpdate.Location = new Point(459, 337);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 41);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtTenHH
            // 
            txtTenHH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenHH.Location = new Point(157, 109);
            txtTenHH.Name = "txtTenHH";
            txtTenHH.Size = new Size(229, 30);
            txtTenHH.TabIndex = 1;
            // 
            // txtMaHH
            // 
            txtMaHH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMaHH.Location = new Point(157, 68);
            txtMaHH.Name = "txtMaHH";
            txtMaHH.ReadOnly = true;
            txtMaHH.Size = new Size(229, 30);
            txtMaHH.TabIndex = 26;
            // 
            // lblDGNhap
            // 
            lblDGNhap.AutoSize = true;
            lblDGNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDGNhap.ForeColor = Color.GhostWhite;
            lblDGNhap.Location = new Point(23, 198);
            lblDGNhap.Name = "lblDGNhap";
            lblDGNhap.Size = new Size(114, 23);
            lblDGNhap.TabIndex = 37;
            lblDGNhap.Text = "Đơn giá nhập";
            // 
            // lblSL
            // 
            lblSL.AutoSize = true;
            lblSL.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSL.ForeColor = Color.GhostWhite;
            lblSL.Location = new Point(23, 154);
            lblSL.Name = "lblSL";
            lblSL.Size = new Size(78, 23);
            lblSL.TabIndex = 36;
            lblSL.Text = "Số lượng";
            // 
            // lblTenHH
            // 
            lblTenHH.AutoSize = true;
            lblTenHH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTenHH.ForeColor = Color.GhostWhite;
            lblTenHH.Location = new Point(21, 112);
            lblTenHH.Name = "lblTenHH";
            lblTenHH.Size = new Size(114, 23);
            lblTenHH.TabIndex = 35;
            lblTenHH.Text = "Tên hàng hóa";
            // 
            // lblMaHH
            // 
            lblMaHH.AutoSize = true;
            lblMaHH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaHH.ForeColor = Color.GhostWhite;
            lblMaHH.Location = new Point(23, 71);
            lblMaHH.Name = "lblMaHH";
            lblMaHH.Size = new Size(112, 23);
            lblMaHH.TabIndex = 34;
            lblMaHH.Text = "Mã hàng hóa";
            // 
            // lblCNHH
            // 
            lblCNHH.AutoSize = true;
            lblCNHH.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblCNHH.ForeColor = Color.GhostWhite;
            lblCNHH.Location = new Point(77, 9);
            lblCNHH.Name = "lblCNHH";
            lblCNHH.Size = new Size(308, 37);
            lblCNHH.TabIndex = 33;
            lblCNHH.Text = "CẬP NHẬT HÀNG HÓA";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSoLuong.Location = new Point(156, 152);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(230, 30);
            txtSoLuong.TabIndex = 2;
            // 
            // txtDGNhap
            // 
            txtDGNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDGNhap.Location = new Point(156, 195);
            txtDGNhap.Name = "txtDGNhap";
            txtDGNhap.Size = new Size(229, 30);
            txtDGNhap.TabIndex = 3;
            // 
            // txtDGBan
            // 
            txtDGBan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDGBan.Location = new Point(519, 195);
            txtDGBan.Name = "txtDGBan";
            txtDGBan.Size = new Size(230, 30);
            txtDGBan.TabIndex = 4;
            // 
            // picAvatar
            // 
            picAvatar.Location = new Point(424, 68);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(225, 114);
            picAvatar.TabIndex = 44;
            picAvatar.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(655, 77);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(94, 29);
            btnUpload.TabIndex = 6;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtGhiChu.Location = new Point(156, 240);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(297, 138);
            txtGhiChu.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblGhiChu.ForeColor = Color.GhostWhite;
            lblGhiChu.Location = new Point(23, 243);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(69, 23);
            lblGhiChu.TabIndex = 46;
            lblGhiChu.Text = "Ghi chú";
            // 
            // frmHangHoaUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 192);
            ClientSize = new Size(780, 408);
            Controls.Add(txtGhiChu);
            Controls.Add(lblGhiChu);
            Controls.Add(btnUpload);
            Controls.Add(picAvatar);
            Controls.Add(txtDGBan);
            Controls.Add(txtDGNhap);
            Controls.Add(txtSoLuong);
            Controls.Add(lblDGBan);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(txtTenHH);
            Controls.Add(txtMaHH);
            Controls.Add(lblDGNhap);
            Controls.Add(lblSL);
            Controls.Add(lblTenHH);
            Controls.Add(lblMaHH);
            Controls.Add(lblCNHH);
            Name = "frmHangHoaUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hàng Hóa Update";
            Load += frmHangHoaUpdate_Load;
            ((System.ComponentModel.ISupportInitialize)txtSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDGBan;
        private Button btnClose;
        private Button btnUpdate;
        private TextBox txtTenHH;
        private TextBox txtMaHH;
        private Label lblDGNhap;
        private Label lblSL;
        private Label lblTenHH;
        private Label lblMaHH;
        private Label lblCNHH;
        private NumericUpDown txtSoLuong;
        private TextBox txtDGNhap;
        private TextBox txtDGBan;
        private PictureBox picAvatar;
        private Button btnUpload;
        private TextBox txtGhiChu;
        private Label lblGhiChu;
    }
}