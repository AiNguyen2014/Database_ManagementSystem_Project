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
    public partial class frmNguoiDung : Form
    {
        INguoiDungRepository nguoiDungRepository = new NguoiDungRepository();
        BindingSource source;
        NguoiDung nd;
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void txtSearchND_TextChanged(object sender, EventArgs e)
        {
            var nguoiDungs = nguoiDungRepository.GetNguoiDungByKeyword(txtSearchND.Text);
            try
            {
                source = new BindingSource();
                source.DataSource = nguoiDungs;

                dgvND.DataSource = null;
                dgvND.DataSource = source;
                if (nguoiDungs.Count() == 0)
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
                throw new Exception(ex.Message);
            }
        }

        private void dgvND_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvND.Rows.Count - 1)
            // Kiểm tra nếu người dùng click vào một ô hợp lệ
            {
                DataGridViewRow row = dgvND.Rows[e.RowIndex];
                var nguoiDung = nguoiDungRepository.GetNguoiDungByTenDangNhap(row.Cells[0].Value.ToString());
                nd = new NguoiDung()
                {
                    TenDangNhap = nguoiDung.TenDangNhap,
                    MatKhau = nguoiDung.MatKhau,
                    LoaiNguoiDung = nguoiDung.LoaiNguoiDung,
                    MaNguoiDung = nguoiDung.MaNguoiDung
                };
            }
        }

        private void dgvND_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNguoiDungUpdate frmNguoiDungUpdate = new frmNguoiDungUpdate()
            {
                Text = "Cập nhật Người dùng",
                InsertOrUpdate = false,
                NguoiDungInfo = nd,
                NguoiDungRepository = nguoiDungRepository
            };
            frmNguoiDungUpdate.Owner = this;
            if (frmNguoiDungUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadNguoiDungList();
                source.Position = source.Count - 1;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmNguoiDungUpdate frmNguoiDungUpdate = new frmNguoiDungUpdate()
            {
                Text = "Cập nhật Người dùng",
                InsertOrUpdate = true,
                NguoiDungInfo = nd,
                NguoiDungRepository = nguoiDungRepository
            };
            frmNguoiDungUpdate.Owner = this;
            if (frmNguoiDungUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadNguoiDungList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                nguoiDungRepository.DeleteNguoiDung(nd.TenDangNhap);
                LoadNguoiDungList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            LoadNguoiDungList();
        }

        public void LoadNguoiDungList()
        {
            var nguoiDungs = nguoiDungRepository.GetNguoiDungs();
            try
            {
                source = new BindingSource();
                source.DataSource = nguoiDungs;

                dgvND.DataSource = null;
                dgvND.DataSource = source;
                if (nguoiDungs.Count() == 0)
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
                throw new Exception(ex.Message);
            }
        }
    }
}
