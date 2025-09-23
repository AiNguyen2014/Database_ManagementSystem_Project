namespace SaleManagementWinApp
{
    partial class frmKhuyenMai
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
            lbTitle = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            btUpdate = new Button();
            btAdd = new Button();
            btRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.ForeColor = SystemColors.ControlLightLight;
            lbTitle.Location = new Point(559, 49);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(230, 28);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "QUẢN LÝ KHUYẾN MÃI";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(55, 130);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 1;
            label1.Text = "Từ khóa tìm kiếm:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(197, 127);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(613, 27);
            textBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(41, 176);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(769, 298);
            dataGridView1.TabIndex = 3;
            // 
            // btUpdate
            // 
            btUpdate.Location = new Point(41, 538);
            btUpdate.Name = "btUpdate";
            btUpdate.Size = new Size(94, 29);
            btUpdate.TabIndex = 4;
            btUpdate.Text = "Cập nhật ";
            btUpdate.UseVisualStyleBackColor = true;
            // 
            // btAdd
            // 
            btAdd.Location = new Point(197, 538);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(94, 29);
            btAdd.TabIndex = 5;
            btAdd.Text = "Thêm";
            btAdd.UseVisualStyleBackColor = true;
            // 
            // btRemove
            // 
            btRemove.Location = new Point(346, 538);
            btRemove.Name = "btRemove";
            btRemove.Size = new Size(94, 29);
            btRemove.TabIndex = 6;
            btRemove.Text = "Xóa";
            btRemove.UseVisualStyleBackColor = true;
            // 
            // frmKhuyenMai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(1409, 636);
            Controls.Add(btRemove);
            Controls.Add(btAdd);
            Controls.Add(btUpdate);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(lbTitle);
            Name = "frmKhuyenMai";
            Text = "frmKhuyenMai";
            Load += frmKhuyenMai_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button btUpdate;
        private Button btAdd;
        private Button btRemove;
    }
}