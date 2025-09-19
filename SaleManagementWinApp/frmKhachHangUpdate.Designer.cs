namespace SaleManagementWinApp
{
    partial class frmKhachHangUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHangUpdate));
            lblCNKH = new Label();
            lblMaKH = new Label();
            lblTenKH = new Label();
            lblDiaChi = new Label();
            lblDienThoai = new Label();
            txtMaKH = new TextBox();
            txtTenKH = new TextBox();
            txtDiaChiKH = new TextBox();
            txtDienThoaiKH = new MaskedTextBox();
            btnClose = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lblCNKH
            // 
            lblCNKH.AutoSize = true;
            lblCNKH.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblCNKH.ForeColor = Color.GhostWhite;
            lblCNKH.Location = new Point(67, 14);
            lblCNKH.Name = "lblCNKH";
            lblCNKH.Size = new Size(344, 37);
            lblCNKH.TabIndex = 1;
            lblCNKH.Text = "CẬP NHẬT KHÁCH HÀNG";
            // 
            // lblMaKH
            // 
            lblMaKH.AutoSize = true;
            lblMaKH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaKH.ForeColor = Color.GhostWhite;
            lblMaKH.Location = new Point(13, 76);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(128, 23);
            lblMaKH.TabIndex = 2;
            lblMaKH.Text = "Mã khách hàng";
            // 
            // lblTenKH
            // 
            lblTenKH.AutoSize = true;
            lblTenKH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTenKH.ForeColor = Color.GhostWhite;
            lblTenKH.Location = new Point(13, 114);
            lblTenKH.Name = "lblTenKH";
            lblTenKH.Size = new Size(130, 23);
            lblTenKH.TabIndex = 3;
            lblTenKH.Text = "Tên khách hàng";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDiaChi.ForeColor = Color.GhostWhite;
            lblDiaChi.Location = new Point(13, 155);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(65, 23);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "Địa Chỉ";
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDienThoai.ForeColor = Color.GhostWhite;
            lblDienThoai.Location = new Point(13, 200);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(111, 23);
            lblDienThoai.TabIndex = 5;
            lblDienThoai.Text = "Số điện thoại";
            // 
            // txtMaKH
            // 
            txtMaKH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMaKH.Location = new Point(147, 73);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(290, 30);
            txtMaKH.TabIndex = 100;
            // 
            // txtTenKH
            // 
            txtTenKH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenKH.Location = new Point(147, 114);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(290, 30);
            txtTenKH.TabIndex = 1;
            // 
            // txtDiaChiKH
            // 
            txtDiaChiKH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDiaChiKH.Location = new Point(147, 155);
            txtDiaChiKH.Name = "txtDiaChiKH";
            txtDiaChiKH.Size = new Size(290, 30);
            txtDiaChiKH.TabIndex = 2;
            // 
            // txtDienThoaiKH
            // 
            txtDienThoaiKH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDienThoaiKH.Location = new Point(147, 199);
            txtDienThoaiKH.Mask = "(84)00.000.0000";
            txtDienThoaiKH.Name = "txtDienThoaiKH";
            txtDienThoaiKH.Size = new Size(290, 30);
            txtDienThoaiKH.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.Purple;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(320, 258);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 41);
            btnClose.TabIndex = 5;
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
            btnUpdate.Location = new Point(147, 258);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 41);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // frmKhachHangUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(504, 356);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(txtDienThoaiKH);
            Controls.Add(txtDiaChiKH);
            Controls.Add(txtTenKH);
            Controls.Add(txtMaKH);
            Controls.Add(lblDienThoai);
            Controls.Add(lblDiaChi);
            Controls.Add(lblTenKH);
            Controls.Add(lblMaKH);
            Controls.Add(lblCNKH);
            Name = "frmKhachHangUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách hàng update";
            Load += frmKhachHangUpdate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCNKH;
        private Label lblMaKH;
        private Label lblTenKH;
        private Label lblDiaChi;
        private Label lblDienThoai;
        private TextBox txtMaKH;
        private TextBox txtTenKH;
        private TextBox txtDiaChiKH;
        private MaskedTextBox txtDienThoaiKH;
        private Button btnClose;
        private Button btnUpdate;
    }
}