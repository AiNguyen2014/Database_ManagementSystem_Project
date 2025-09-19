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
    public partial class frmNhanVien : Form
    {
        INhanVienRepository nhanVienRepository = new NhanVienRepository();
        BindingSource source;
        NhanVien nv;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNhanVienUpdate frmNVUpdate = new frmNhanVienUpdate()
            {
                Text = "Update Nhân Viên",
                InsertOrUpdate = false,
                NhanVienInfo = nv,
                NhanVienRepository = nhanVienRepository
            };
            frmNVUpdate.Owner = this;
            if (frmNVUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadNhanVienList();
                source.Position = source.Count - 1;
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVienList();
        }

        public void LoadNhanVienList()
        {
            var nhanViens = nhanVienRepository.GetNhanViens();
            try
            {
                source = new BindingSource();
                source.DataSource = nhanViens;

                dgvNV.DataSource = null;
                dgvNV.DataSource = source;
                if (nhanViens.Count() == 0)
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

        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            var nhanViens = nhanVienRepository.GetNhanVienByKeyword(txtSearchNV.Text);
            try
            {
                source = new BindingSource();
                source.DataSource = nhanViens;

                dgvNV.DataSource = null;
                dgvNV.DataSource = source;
                if (nhanViens.Count() == 0)
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

        private void dgvNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                nhanVienRepository.DeleteNhanVien(nv.MaNhanVien);
                LoadNhanVienList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa nhân viên");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmNhanVienUpdate frmNhanVienUpdate = new frmNhanVienUpdate()
            {
                Text = "Cập nhật Nhân viên",
                InsertOrUpdate = true,
                NhanVienInfo = nv,
                NhanVienRepository = nhanVienRepository
            };
            frmNhanVienUpdate.Owner = this;
            if (frmNhanVienUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadNhanVienList();
                source.Position = source.Count - 1;
            }
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Kiểm tra người dùng nếu click vào 1 ô hợp lệ
            {
                DataGridViewRow row = dgvNV.Rows[e.RowIndex];
                nv = new NhanVien
                {
                    MaNhanVien = Convert.ToInt32(row.Cells[0].Value),
                    TenNhanVien = row.Cells[1].Value.ToString(),
                    GioiTinh = Convert.ToBoolean(row.Cells[2].Value.ToString()),
                    DiaChi = row.Cells[3].Value.ToString(),
                    DienThoai = row.Cells[4].Value.ToString(),
                    NgaySinh = Convert.ToDateTime(row.Cells[5].Value.ToString())
                };
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
