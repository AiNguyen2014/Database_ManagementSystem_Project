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
    public partial class frmKhachHang : Form
    {
        IKhachHangRepository khachHangRepository = new KhachHangRepository();
        BindingSource source;
        KhachHang kh;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmKhachHangUpdate frmKHUpdate = new frmKhachHangUpdate()
            {
                Text = "Update Khách hàng",
                InsertOrUpdate = false,
                KhachHangInfo = kh,
                KhachHangRepository = khachHangRepository
            };
            frmKHUpdate.Owner = this;
            if (frmKHUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadKhachHangList();
                source.Position = source.Count - 1;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmKhachHangUpdate frmKHUpdate = new frmKhachHangUpdate()
            {
                Text = "Update khachHang",
                InsertOrUpdate = true,
                KhachHangInfo = kh,
                KhachHangRepository = khachHangRepository
            };
            frmKHUpdate.Owner = this;
            if (frmKHUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadKhachHangList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                khachHangRepository.DeleteKhachHang(kh.MaKhach);
                LoadKhachHangList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa Khách hàng");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHangList();
        }
        public void LoadKhachHangList()
        {
            var khachHangs = khachHangRepository.GetKhachHangs();
            try
            {
                source = new BindingSource();
                source.DataSource = khachHangs;

                dgvKH.DataSource = null;
                dgvKH.DataSource = source;
                if (khachHangs.Count() == 0)
                {
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void txtSearchKH_TextChanged(object sender, EventArgs e)
        {
            var khachHangs = khachHangRepository.GetKhachHangByKeyword(txtSearchKH.Text);
            try
            {
                source = new BindingSource();
                source.DataSource = khachHangs;

                dgvKH.DataSource = null;
                dgvKH.DataSource = source;
                if (khachHangs.Count() == 0)
                {
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Kiểm tra người dùng nếu click vào 1 ô hợp lệ
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];
                kh = new KhachHang
                {
                    MaKhach = Convert.ToInt32(row.Cells[0].Value),
                    TenKhach = row.Cells[1].Value.ToString(),
                    DiaChi = row.Cells[2].Value.ToString(),
                    DienThoai = row.Cells[3].Value.ToString()
                };
            }
        }
    }
}
