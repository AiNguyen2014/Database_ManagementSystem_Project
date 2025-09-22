namespace SaleManagementWinApp
{
    partial class frmMain
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
            tệpTinToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            qLNhânViênToolStripMenuItem = new ToolStripMenuItem();
            qLKháchHàngToolStripMenuItem = new ToolStripMenuItem();
            qLHàngHóaToolStripMenuItem = new ToolStripMenuItem();
            qLNgườiDùngToolStripMenuItem = new ToolStripMenuItem();
            qLKhuyếnMãiToolStripMenuItem = new ToolStripMenuItem();
            hóaĐơnToolStripMenuItem = new ToolStripMenuItem();
            bánHàngToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tệpTinToolStripMenuItem, danhMụcToolStripMenuItem, hóaĐơnToolStripMenuItem, bánHàngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1451, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tệpTinToolStripMenuItem
            // 
            tệpTinToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thoátToolStripMenuItem });
            tệpTinToolStripMenuItem.Name = "tệpTinToolStripMenuItem";
            tệpTinToolStripMenuItem.Size = new Size(69, 24);
            tệpTinToolStripMenuItem.Text = "Tệp tin";
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(130, 26);
            thoátToolStripMenuItem.Text = "Thoát";
            thoátToolStripMenuItem.Click += thoátToolStripMenuItem_Click;
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { qLNhânViênToolStripMenuItem, qLKháchHàngToolStripMenuItem, qLHàngHóaToolStripMenuItem, qLNgườiDùngToolStripMenuItem, qLKhuyếnMãiToolStripMenuItem });
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(90, 24);
            danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // qLNhânViênToolStripMenuItem
            // 
            qLNhânViênToolStripMenuItem.Name = "qLNhânViênToolStripMenuItem";
            qLNhânViênToolStripMenuItem.Size = new Size(224, 26);
            qLNhânViênToolStripMenuItem.Text = "QL Nhân Viên";
            qLNhânViênToolStripMenuItem.Click += qLNhânViênToolStripMenuItem_Click;
            // 
            // qLKháchHàngToolStripMenuItem
            // 
            qLKháchHàngToolStripMenuItem.Name = "qLKháchHàngToolStripMenuItem";
            qLKháchHàngToolStripMenuItem.Size = new Size(224, 26);
            qLKháchHàngToolStripMenuItem.Text = "QL Khách Hàng";
            qLKháchHàngToolStripMenuItem.Click += qLKháchHàngToolStripMenuItem_Click;
            // 
            // qLHàngHóaToolStripMenuItem
            // 
            qLHàngHóaToolStripMenuItem.Name = "qLHàngHóaToolStripMenuItem";
            qLHàngHóaToolStripMenuItem.Size = new Size(224, 26);
            qLHàngHóaToolStripMenuItem.Text = "QL Hàng Hóa";
            qLHàngHóaToolStripMenuItem.Click += qLHàngHóaToolStripMenuItem_Click;
            // 
            // qLNgườiDùngToolStripMenuItem
            // 
            qLNgườiDùngToolStripMenuItem.Name = "qLNgườiDùngToolStripMenuItem";
            qLNgườiDùngToolStripMenuItem.Size = new Size(224, 26);
            qLNgườiDùngToolStripMenuItem.Text = "QL Người Dùng";
            qLNgườiDùngToolStripMenuItem.Click += qLNgườiDùngToolStripMenuItem_Click;
            // 
            // qLKhuyếnMãiToolStripMenuItem
            // 
            qLKhuyếnMãiToolStripMenuItem.Name = "qLKhuyếnMãiToolStripMenuItem";
            qLKhuyếnMãiToolStripMenuItem.Size = new Size(224, 26);
            qLKhuyếnMãiToolStripMenuItem.Text = "QL Khuyến Mãi";
            qLKhuyếnMãiToolStripMenuItem.Click += qLKhuyếnMãiToolStripMenuItem_Click;
            // 
            // hóaĐơnToolStripMenuItem
            // 
            hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            hóaĐơnToolStripMenuItem.Size = new Size(83, 24);
            hóaĐơnToolStripMenuItem.Text = "Hóa Đơn";
            hóaĐơnToolStripMenuItem.Click += hóaĐơnToolStripMenuItem_Click;
            // 
            // bánHàngToolStripMenuItem
            // 
            bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            bánHàngToolStripMenuItem.Size = new Size(88, 24);
            bánHàngToolStripMenuItem.Text = "Bán Hàng";
            bánHàngToolStripMenuItem.Click += bánHàngToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1451, 633);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tệpTinToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem qLNhânViênToolStripMenuItem;
        private ToolStripMenuItem qLKháchHàngToolStripMenuItem;
        private ToolStripMenuItem qLHàngHóaToolStripMenuItem;
        private ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private ToolStripMenuItem qLNgườiDùngToolStripMenuItem;
        private ToolStripMenuItem bánHàngToolStripMenuItem;
        private ToolStripMenuItem qLKhuyếnMãiToolStripMenuItem;
    }
}