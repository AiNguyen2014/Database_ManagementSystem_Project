namespace SaleManagementWinApp
{
    partial class frmMainNhanVien
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
            tabControl1 = new TabControl();
            tabHoSo = new TabPage();
            ucNhanVienManager1 = new ucNhanVienManager();
            tabChamCong = new TabPage();
            ucChamCong1 = new ucChamCong();
            tabLuong = new TabPage();
            ucLuong1 = new ucLuong();
            tabBaoCao = new TabPage();
            ucBaoCao1 = new ucBaoCao();
            tabControl1.SuspendLayout();
            tabHoSo.SuspendLayout();
            tabChamCong.SuspendLayout();
            tabLuong.SuspendLayout();
            tabBaoCao.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabHoSo);
            tabControl1.Controls.Add(tabChamCong);
            tabControl1.Controls.Add(tabLuong);
            tabControl1.Controls.Add(tabBaoCao);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(951, 596);
            tabControl1.TabIndex = 0;
            // 
            // tabHoSo
            // 
            tabHoSo.Controls.Add(ucNhanVienManager1);
            tabHoSo.Location = new Point(4, 29);
            tabHoSo.Name = "tabHoSo";
            tabHoSo.Padding = new Padding(3);
            tabHoSo.Size = new Size(943, 563);
            tabHoSo.TabIndex = 0;
            tabHoSo.Text = "Hồ sơ nhân viên";
            tabHoSo.UseVisualStyleBackColor = true;
            // 
            // ucNhanVienManager1
            // 
            ucNhanVienManager1.BackColor = Color.DarkBlue;
            ucNhanVienManager1.CurrentNhanVien = null;
            ucNhanVienManager1.Location = new Point(-11, 0);
            ucNhanVienManager1.Name = "ucNhanVienManager1";
            ucNhanVienManager1.Size = new Size(958, 591);
            ucNhanVienManager1.TabIndex = 0;
            // 
            // tabChamCong
            // 
            tabChamCong.Controls.Add(ucChamCong1);
            tabChamCong.Location = new Point(4, 29);
            tabChamCong.Name = "tabChamCong";
            tabChamCong.Padding = new Padding(3);
            tabChamCong.Size = new Size(943, 563);
            tabChamCong.Size = new Size(780, 508);
            tabChamCong.TabIndex = 1;
            tabChamCong.Text = "Chấm công";
            tabChamCong.UseVisualStyleBackColor = true;
            // 
            // ucChamCong1
            // 
            ucChamCong1.BackColor = Color.DarkBlue;
            ucChamCong1.CurrentNhanVien = null;
            ucChamCong1.Location = new Point(-4, 0);
            ucChamCong1.Name = "ucChamCong1";
            ucChamCong1.Size = new Size(999, 558);
            ucChamCong1.TabIndex = 0;
            // 
            // tabLuong
            // 
            tabLuong.Controls.Add(ucLuong1);
            tabLuong.Location = new Point(4, 29);
            tabLuong.Name = "tabLuong";
            tabLuong.Padding = new Padding(3);
            tabLuong.Size = new Size(943, 563);
            tabLuong.Size = new Size(780, 508);
            tabLuong.TabIndex = 2;
            tabLuong.Text = "Lương";
            tabLuong.UseVisualStyleBackColor = true;
            // 
            // ucLuong1
            // 
            ucLuong1.BackColor = Color.DarkBlue;
            ucLuong1.CurrentNhanVien = null;
            ucLuong1.Location = new Point(-4, 3);
            ucLuong1.Name = "ucLuong1";
            ucLuong1.Size = new Size(962, 636);
            ucLuong1.TabIndex = 0;
            // 
            // tabBaoCao
            // 
            tabBaoCao.Controls.Add(ucBaoCao1);
            tabBaoCao.Location = new Point(4, 29);
            tabBaoCao.Name = "tabBaoCao";
            tabBaoCao.Padding = new Padding(3);
            tabBaoCao.Size = new Size(943, 563);
            tabBaoCao.TabIndex = 3;
            tabBaoCao.Text = "Báo cáo";
            tabBaoCao.UseVisualStyleBackColor = true;
            // 
            // ucBaoCao1
            // 
            ucBaoCao1.BackColor = Color.DarkBlue;
            ucBaoCao1.Dock = DockStyle.Fill;
            ucBaoCao1.Location = new Point(3, 3);
            ucBaoCao1.Name = "ucBaoCao1";
            ucBaoCao1.Size = new Size(937, 557);
            ucBaoCao1.TabIndex = 0;
            // 
            // frmMainNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(951, 596);
            Controls.Add(tabControl1);
            Name = "frmMainNhanVien";
            Text = "frmMainNhanVien";
            Load += frmMainNhanVien_Load;
            tabControl1.ResumeLayout(false);
            tabHoSo.ResumeLayout(false);
            tabChamCong.ResumeLayout(false);
            tabLuong.ResumeLayout(false);
            tabBaoCao.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabHoSo;
        private TabPage tabChamCong;
        private TabPage tabLuong;
        private TabPage tabBaoCao;
        private ucChamCong ucChamCong1;
        private ucNhanVienManager ucNhanVienManager1;
        private ucLuong ucLuong1;
        private ucBaoCao ucBaoCao1;
    }
}