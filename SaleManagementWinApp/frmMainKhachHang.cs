using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.Repository;

namespace SaleManagementWinApp
{
    public partial class frmMainKhachHang : Form
    {
        public NguoiDung NguoiDungInfo { get; set; }
        public IKhachHangRepository khachHangRepository = new KhachHangRepository();
        public frmMainKhachHang()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            foreach (Form form in this.MdiChildren)
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(0, 0);
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham f_SP = new frmSanPham()
            {
                Text = "Mua hàng"
            };
            f_SP.MdiParent = this;
            f_SP.Show();
        }

        private void frmMainKhachHang_Load(object sender, EventArgs e)
        {
            mnuChao.Text = "Chào: " + khachHangRepository.GetKhachHangByID(Convert.ToInt32(NguoiDungInfo.MaNguoiDung)).TenKhach;
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmLogin f_Login = new frmLogin();
            f_Login.Show();
        }
    }
}
