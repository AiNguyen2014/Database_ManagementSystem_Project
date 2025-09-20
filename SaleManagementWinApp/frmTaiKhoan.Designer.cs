namespace SaleManagementWinApp
{
    partial class frmTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoan));
            btnClose = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnNew = new Button();
            dgvND = new DataGridView();
            txtSearchND = new TextBox();
            lblKeyword = new Label();
            lblQLND = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvND).BeginInit();
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
            btnClose.TabIndex = 23;
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
            btnDelete.TabIndex = 22;
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
            btnUpdate.TabIndex = 21;
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
            btnNew.TabIndex = 20;
            btnNew.Text = "Thêm mới";
            btnNew.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // dgvND
            // 
            dgvND.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvND.Location = new Point(40, 117);
            dgvND.Name = "dgvND";
            dgvND.RowHeadersWidth = 51;
            dgvND.RowTemplate.Height = 29;
            dgvND.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvND.Size = new Size(720, 251);
            dgvND.TabIndex = 19;
            //dgvND.CellClick += dgvND_CellClick;
            dgvND.CellDoubleClick += dgvND_CellDoubleClick;
            // 
            // txtSearchND
            // 
            txtSearchND.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchND.Location = new Point(230, 72);
            txtSearchND.Name = "txtSearchND";
            txtSearchND.Size = new Size(349, 30);
            txtSearchND.TabIndex = 18;
            txtSearchND.TextChanged += txtSearchND_TextChanged;
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblKeyword.ForeColor = Color.GhostWhite;
            lblKeyword.Location = new Point(68, 75);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(153, 23);
            lblKeyword.TabIndex = 17;
            lblKeyword.Text = "Từ khóa tìm kiếm";
            // 
            // lblQLND
            // 
            lblQLND.AutoSize = true;
            lblQLND.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQLND.ForeColor = Color.GhostWhite;
            lblQLND.Location = new Point(230, 11);
            lblQLND.Name = "lblQLND";
            lblQLND.Size = new Size(288, 37);
            lblQLND.TabIndex = 16;
            lblQLND.Text = "QUẢN LÝ TÀI KHOẢN";
            //lblQLND.Click += this.lblQLND_Click;
            // 
            // frmTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnNew);
            Controls.Add(dgvND);
            Controls.Add(txtSearchND);
            Controls.Add(lblKeyword);
            Controls.Add(lblQLND);
            Name = "frmTaiKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNguoiDung";
            //Load += frmNguoiDung_Load;
            ((System.ComponentModel.ISupportInitialize)dgvND).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnNew;
        private DataGridView dgvND;
        private TextBox txtSearchND;
        private Label lblKeyword;
        private Label lblQLND;
    }
}