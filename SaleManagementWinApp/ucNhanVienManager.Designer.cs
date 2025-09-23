namespace SaleManagementWinApp
{
    partial class ucNhanVienManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNhanVienManager));
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
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.Purple;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.Location = new Point(586, 509);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 41);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Xóa";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.Purple;
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.Location = new Point(314, 509);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 41);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew.ForeColor = Color.Purple;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.Location = new Point(64, 509);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(140, 41);
            btnNew.TabIndex = 20;
            btnNew.Text = "Thêm mới";
            btnNew.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNew.UseVisualStyleBackColor = true;
            // 
            // dgvNV
            // 
            dgvNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNV.Location = new Point(32, 127);
            dgvNV.Name = "dgvNV";
            dgvNV.RowHeadersWidth = 51;
            dgvNV.RowTemplate.Height = 29;
            dgvNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNV.Size = new Size(800, 355);
            dgvNV.TabIndex = 19;
            dgvNV.CellContentClick += dgvNV_CellContentClick;
            // 
            // txtSearchNV
            // 
            txtSearchNV.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchNV.Location = new Point(226, 82);
            txtSearchNV.Name = "txtSearchNV";
            txtSearchNV.Size = new Size(349, 30);
            txtSearchNV.TabIndex = 18;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblKeyword.ForeColor = Color.GhostWhite;
            lblKeyword.Location = new Point(64, 85);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(153, 23);
            lblKeyword.TabIndex = 17;
            lblKeyword.Text = "Từ khóa tìm kiếm";
            // 
            // lblQLNV
            // 
            lblQLNV.AutoSize = true;
            lblQLNV.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQLNV.ForeColor = Color.GhostWhite;
            lblQLNV.Location = new Point(226, 21);
            lblQLNV.Name = "lblQLNV";
            lblQLNV.Size = new Size(291, 37);
            lblQLNV.TabIndex = 16;
            lblQLNV.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // ucNhanVienManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnNew);
            Controls.Add(dgvNV);
            Controls.Add(txtSearchNV);
            Controls.Add(lblKeyword);
            Controls.Add(lblQLNV);
            Name = "ucNhanVienManager";
            Size = new Size(859, 601);
            ((System.ComponentModel.ISupportInitialize)dgvNV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnNew;
        private DataGridView dgvNV;
        private TextBox txtSearchNV;
        private Label lblKeyword;
        private Label lblQLNV;
    }
}
