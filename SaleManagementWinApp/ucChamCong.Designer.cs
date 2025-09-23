namespace SaleManagementWinApp
{
    partial class ucChamCong
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
            btnCheckIn = new Button();
            dgvChamCong = new DataGridView();
            btnCheckOut = new Button();
            lblQLNV = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(83, 59);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(94, 29);
            btnCheckIn.TabIndex = 0;
            btnCheckIn.Text = "Check-in";
            btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // dgvChamCong
            // 
            dgvChamCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChamCong.Location = new Point(30, 107);
            dgvChamCong.Name = "dgvChamCong";
            dgvChamCong.RowHeadersWidth = 51;
            dgvChamCong.RowTemplate.Height = 29;
            dgvChamCong.Size = new Size(813, 436);
            dgvChamCong.TabIndex = 1;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(476, 59);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(94, 29);
            btnCheckOut.TabIndex = 2;
            btnCheckOut.Text = "Check-out";
            btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // lblQLNV
            // 
            lblQLNV.AutoSize = true;
            lblQLNV.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQLNV.ForeColor = Color.GhostWhite;
            lblQLNV.Location = new Point(237, 14);
            lblQLNV.Name = "lblQLNV";
            lblQLNV.Size = new Size(183, 37);
            lblQLNV.TabIndex = 17;
            lblQLNV.Text = "CHẤM CÔNG";
            // 
            // ucChamCong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            Controls.Add(lblQLNV);
            Controls.Add(btnCheckOut);
            Controls.Add(dgvChamCong);
            Controls.Add(btnCheckIn);
            Name = "ucChamCong";
            Size = new Size(881, 600);
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCheckIn;
        private DataGridView dgvChamCong;
        private Button btnCheckOut;
        private Label lblQLNV;
    }
}
