using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            foreach (Form form in this.MdiChildren)
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(0, 0);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void qLNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() != typeof(frmNhanVien))
                {
                    form.Close();
                }
            }
            frmNhanVien frmNV = new frmNhanVien();
            frmNV.MdiParent = this;
            frmNV.Show();
        }

        private void qLKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() != typeof(frmKhachHang))
                {
                    form.Close();
                }
            }
            frmKhachHang frmKH = new frmKhachHang();
            frmKH.MdiParent = this;
            frmKH.Show();
        }

        private void qLHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() != typeof(frmQuanLySanPham))
                {
                    form.Close();
                }
            }
            frmQuanLySanPham frmHH = new frmQuanLySanPham();
            frmHH.MdiParent = this;
            frmHH.Show();
        }

        private void qLNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() != typeof(frmTaiKhoan))
                {
                    form.Close();
                }
            }
            frmTaiKhoan frmND = new frmTaiKhoan();
            frmND.MdiParent = this;
            frmND.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() != typeof(frmBanHang))
                {
                    form.Close();
                }
            }
            frmBanHang frmBH = new frmBanHang();
            frmBH.MdiParent = this;
            frmBH.Show();
        }

        private void qLKhuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() != typeof(frmKhuyenMai))
                {
                    form.Close();
                }
            }
            frmKhuyenMai frmBH = new frmKhuyenMai();
            frmBH.MdiParent = this;
            frmBH.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
