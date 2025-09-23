namespace SaleManagementWinApp
{
    partial class frmSanPham
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
            dgvHangHoa = new DataGridView();
            label1 = new Label();
            btnRefresh = new Button();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).BeginInit();
            SuspendLayout();
            // 
            // dgvHangHoa
            // 
            dgvHangHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangHoa.Location = new Point(24, 44);
            dgvHangHoa.Margin = new Padding(3, 2, 3, 2);
            dgvHangHoa.Name = "dgvHangHoa";
            dgvHangHoa.RowHeadersWidth = 51;
            dgvHangHoa.RowTemplate.Height = 29;
            dgvHangHoa.Size = new Size(718, 193);
            dgvHangHoa.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.GhostWhite;
            label1.Location = new Point(24, 20);
            label1.Name = "label1";
            label1.Size = new Size(75, 19);
            label1.TabIndex = 2;
            label1.Text = "Sản phẩm";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(161, 270);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(123, 38);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(494, 270);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 38);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(776, 338);
            Controls.Add(btnThoat);
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(dgvHangHoa);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSanPham";
            Text = "frmSanPham";
            Load += frmSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHangHoa;
        private Label label1;
        private Button btnRefresh;
        private Button btnThoat;
    }
}