namespace SaleManagementWinApp
{
    partial class frmMainKhachHang
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
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuSanPham = new ToolStripMenuItem();
            mnuChao = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuThongTinCaNhan = new ToolStripMenuItem();
            mnuLichSuMuaHang = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.DarkBlue;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuSanPham, mnuChao });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(912, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.BackColor = Color.SkyBlue;
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuThoat, mnuThongTinCaNhan, mnuLichSuMuaHang, đăngXuấtToolStripMenuItem, thoátToolStripMenuItem });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(69, 24);
            mnuFile.Text = "Tệp tin";
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(224, 26);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuSanPham
            // 
            mnuSanPham.BackColor = Color.White;
            mnuSanPham.Name = "mnuSanPham";
            mnuSanPham.Size = new Size(89, 24);
            mnuSanPham.Text = "Sản phẩm";
            // 
            // mnuChao
            // 
            mnuChao.BackColor = Color.White;
            mnuChao.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat });
            mnuChao.Name = "mnuChao";
            mnuChao.Size = new Size(57, 24);
            mnuChao.Text = "Chào";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(224, 26);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuThongTinCaNhan
            // 
            mnuThongTinCaNhan.Name = "mnuThongTinCaNhan";
            mnuThongTinCaNhan.Size = new Size(224, 26);
            mnuThongTinCaNhan.Text = "Thông tin cá nhân";
            // 
            // mnuLichSuMuaHang
            // 
            mnuLichSuMuaHang.Name = "mnuLichSuMuaHang";
            mnuLichSuMuaHang.Size = new Size(224, 26);
            mnuLichSuMuaHang.Text = "Lịch sử mua hàng";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(224, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(224, 26);
            thoátToolStripMenuItem.Text = "Thoát";
            // 
            // frmMainKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(912, 553);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMainKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMainKhachHang";
            Load += frmMainKhachHang_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuSanPham;
        private ToolStripMenuItem mnuChao;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThongTinCaNhan;
        private ToolStripMenuItem mnuLichSuMuaHang;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
    }
}