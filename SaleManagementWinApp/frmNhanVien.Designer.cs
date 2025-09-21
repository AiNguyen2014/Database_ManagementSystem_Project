namespace SaleManagementWinApp
{
    partial class frmNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien));
            btnClose = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnNew = new Button();
            dgvNV = new DataGridView();
            txtSearchNV = new TextBox();
            lblKeyword = new Label();
            lblQLNV = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNV).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.Purple;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(643, 399);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 41);
            btnClose.TabIndex = 15;
            btnClose.Text = "Thoát";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.Purple;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.Location = new Point(455, 399);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 41);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.Purple;
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.Location = new Point(241, 399);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 41);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnNew
            // 
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew.ForeColor = Color.Purple;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.Location = new Point(40, 399);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(140, 41);
            btnNew.TabIndex = 12;
            btnNew.Text = "Thêm mới";
            btnNew.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // dgvNV
            // 
            dgvNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNV.Location = new Point(40, 117);
            dgvNV.Name = "dgvNV";
            dgvNV.RowHeadersWidth = 51;
            dgvNV.RowTemplate.Height = 29;
            dgvNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNV.Size = new Size(720, 251);
            dgvNV.TabIndex = 11;
            //dgvNV.CellClick += dgvNV_CellClick;
            dgvNV.CellDoubleClick += dgvNV_CellDoubleClick;
            // 
            // txtSearchNV
            // 
            txtSearchNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchNV.Location = new Point(230, 72);
            txtSearchNV.Name = "txtSearchNV";
            txtSearchNV.Size = new Size(349, 30);
            txtSearchNV.TabIndex = 10;
            txtSearchNV.TextChanged += txtSearchNV_TextChanged;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblKeyword.ForeColor = Color.GhostWhite;
            lblKeyword.Location = new Point(68, 75);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(153, 23);
            lblKeyword.TabIndex = 9;
            lblKeyword.Text = "Từ khóa tìm kiếm";
            // 
            // lblQLNV
            // 
            lblQLNV.AutoSize = true;
            lblQLNV.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQLNV.ForeColor = Color.GhostWhite;
            lblQLNV.Location = new Point(230, 11);
            lblQLNV.Name = "lblQLNV";
            lblQLNV.Size = new Size(291, 37);
            lblQLNV.TabIndex = 8;
            lblQLNV.Text = "QUẢN LÝ NHÂN VIÊN";
            //lblQLNV.Click += lblQLNV_Click;
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnNew);
            Controls.Add(dgvNV);
            Controls.Add(txtSearchNV);
            Controls.Add(lblKeyword);
            Controls.Add(lblQLNV);
            Name = "frmNhanVien";
            Text = "Nhân Viên";
            Load += frmNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnNew;
        private DataGridView dgvNV;
        private TextBox txtSearchNV;
        private Label lblKeyword;
        private Label lblQLNV;
    }
}