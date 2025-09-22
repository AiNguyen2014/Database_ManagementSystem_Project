namespace SaleManagementWinApp
{
    partial class ucLuong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvLuong = new DataGridView();
            cBoxThang = new ComboBox();
            cBoxNam = new ComboBox();
            lblQLNV = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLuong).BeginInit();
            SuspendLayout();
            // 
            // dgvLuong
            // 
            dgvLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLuong.Location = new Point(17, 113);
            dgvLuong.Name = "dgvLuong";
            dgvLuong.RowHeadersWidth = 51;
            dgvLuong.RowTemplate.Height = 29;
            dgvLuong.Size = new Size(739, 363);
            dgvLuong.TabIndex = 0;
            // 
            // cBoxThang
            // 
            cBoxThang.FormattingEnabled = true;
            cBoxThang.Location = new Point(85, 63);
            cBoxThang.Name = "cBoxThang";
            cBoxThang.Size = new Size(151, 28);
            cBoxThang.TabIndex = 1;
            cBoxThang.Text = "Tháng";
            // 
            // cBoxNam
            // 
            cBoxNam.FormattingEnabled = true;
            cBoxNam.Location = new Point(416, 63);
            cBoxNam.Name = "cBoxNam";
            cBoxNam.Size = new Size(151, 28);
            cBoxNam.TabIndex = 2;
            cBoxNam.Text = "Năm";
            // 
            // lblQLNV
            // 
            lblQLNV.AutoSize = true;
            lblQLNV.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQLNV.ForeColor = Color.GhostWhite;
            lblQLNV.Location = new Point(274, 14);
            lblQLNV.Name = "lblQLNV";
            lblQLNV.Size = new Size(113, 37);
            lblQLNV.TabIndex = 18;
            lblQLNV.Text = "LƯƠNG";
            // 
            // ucLuong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            Controls.Add(lblQLNV);
            Controls.Add(cBoxNam);
            Controls.Add(cBoxThang);
            Controls.Add(dgvLuong);
            Name = "ucLuong";
            Size = new Size(770, 509);
            Load += ucLuong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLuong;
        private ComboBox cBoxThang;
        private ComboBox cBoxNam;
        private Label lblQLNV;
    }
}
