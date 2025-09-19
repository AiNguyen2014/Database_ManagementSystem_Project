namespace SaleManagementWinApp
{
    partial class frmKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHang));
            lblQLKH = new Label();
            lblKeyword = new Label();
            txtSearchKH = new TextBox();
            dgvKH = new DataGridView();
            btnNew = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKH).BeginInit();
            SuspendLayout();
            // 
            // lblQLKH
            // 
            lblQLKH.AutoSize = true;
            lblQLKH.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQLKH.ForeColor = Color.GhostWhite;
            lblQLKH.Location = new Point(229, 9);
            lblQLKH.Name = "lblQLKH";
            lblQLKH.Size = new Size(323, 37);
            lblQLKH.TabIndex = 0;
            lblQLKH.Text = "QUẢN LÝ KHÁCH HÀNG";
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblKeyword.ForeColor = Color.GhostWhite;
            lblKeyword.Location = new Point(67, 73);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(153, 23);
            lblKeyword.TabIndex = 1;
            lblKeyword.Text = "Từ khóa tìm kiếm";
            // 
            // txtSearchKH
            // 
            txtSearchKH.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchKH.Location = new Point(229, 70);
            txtSearchKH.Name = "txtSearchKH";
            txtSearchKH.Size = new Size(349, 30);
            txtSearchKH.TabIndex = 2;
            txtSearchKH.TextChanged += txtSearchKH_TextChanged;
            // 
            // dgvKH
            // 
            dgvKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKH.Location = new Point(39, 115);
            dgvKH.Name = "dgvKH";
            dgvKH.RowHeadersWidth = 51;
            dgvKH.RowTemplate.Height = 29;
            dgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKH.Size = new Size(720, 251);
            dgvKH.TabIndex = 3;
            dgvKH.CellClick += dgvKH_CellClick;
            dgvKH.CellDoubleClick += dgvKH_CellDoubleClick;
            // 
            // btnNew
            // 
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew.ForeColor = Color.Purple;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.Location = new Point(39, 397);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(140, 41);
            btnNew.TabIndex = 4;
            btnNew.Text = "Thêm mới";
            btnNew.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.Purple;
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.Location = new Point(240, 397);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 41);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.Purple;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.Location = new Point(454, 397);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 41);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Xóa";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.Purple;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(642, 397);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 41);
            btnClose.TabIndex = 7;
            btnClose.Text = "Thoát";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnNew);
            Controls.Add(dgvKH);
            Controls.Add(txtSearchKH);
            Controls.Add(lblKeyword);
            Controls.Add(lblQLKH);
            Name = "frmKhachHang";
            Text = "Khách hàng";
            Load += frmKhachHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKH).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQLKH;
        private Label lblKeyword;
        private TextBox txtSearchKH;
        private DataGridView dgvKH;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClose;
    }
}