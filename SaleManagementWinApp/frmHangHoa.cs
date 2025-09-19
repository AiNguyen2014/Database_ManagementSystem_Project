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
    public partial class frmHangHoa : Form
    {
        IHangHoaRepository hangHoaRepository = new HangHoaRepository();
        BindingSource source;
        HangHoa hh;
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void txtSearchHH_TextChanged(object sender, EventArgs e)
        {
            var hangHoas = hangHoaRepository.GetHangHoaByKeyword(txtSearchHH.Text);
            try
            {
                source = new BindingSource();
                source.DataSource = hangHoas;

                dgvHH.DataSource = null;
                dgvHH.DataSource = source;
                if (hangHoas.Count() == 0)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmHangHoaUpdate frmHangHoaUpdate = new frmHangHoaUpdate()
            {
                Text = "Cập nhật Hàng hoá",
                InsertOrUpdate = false,
                HangHoaInfo = hh,
                HangHoaRepository = hangHoaRepository
            };
            frmHangHoaUpdate.Owner = this;
            if (frmHangHoaUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadHangHoaList();
                source.Position = source.Count - 1;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmHangHoaUpdate frmHangHoaUpdate = new frmHangHoaUpdate()
            {
                Text = "Cập nhật Hàng hoá",
                InsertOrUpdate = true,
                HangHoaInfo = hh,
                HangHoaRepository = hangHoaRepository
            };
            frmHangHoaUpdate.Owner = this;
            if (frmHangHoaUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadHangHoaList();
                source.Position = source.Count - 1;
            }
        }

        public void LoadHangHoaList()
        {
            var hangHoas = hangHoaRepository.GetHangHoas();
            try
            {
                source = new BindingSource();
                source.DataSource = hangHoas;

                dgvHH.DataSource = null;
                dgvHH.AutoGenerateColumns = false;
                dgvHH.Columns.Clear();  // Xóa tất cả các cột hiện có trên DataGridView
                // Thêm cột ID và Tên vào DataGridView
                var maHangHoa = new DataGridViewTextBoxColumn();
                maHangHoa.DataPropertyName = "MaHangHoa";
                maHangHoa.HeaderText = "Mã Hàng hoá";
                dgvHH.Columns.Add(maHangHoa);

                var tenHangHoa = new DataGridViewTextBoxColumn();
                tenHangHoa.DataPropertyName = "TenHangHoa";
                tenHangHoa.HeaderText = "Tên Hàng hoá";
                dgvHH.Columns.Add(tenHangHoa);

                var soLuong = new DataGridViewTextBoxColumn();
                soLuong.DataPropertyName = "SoLuong";
                soLuong.HeaderText = "Số lượng";
                dgvHH.Columns.Add(soLuong);

                var donGiaNhap = new DataGridViewTextBoxColumn();
                donGiaNhap.DataPropertyName = "DonGiaNhap";
                donGiaNhap.HeaderText = "Đơn giá nhập";
                dgvHH.Columns.Add(donGiaNhap);

                var donGiaBan = new DataGridViewTextBoxColumn();
                donGiaBan.DataPropertyName = "DonGiaBan";
                donGiaBan.HeaderText = "Đơn giá bán";
                dgvHH.Columns.Add(donGiaBan);
                // Ẩn cột Ảnh
                //dgvHangHoa.Columns[5].Visible = false;
                dgvHH.DataSource = source;


                if (hangHoas.Count() == 0)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                hangHoaRepository.DeleteHangHoa(hh.MaHangHoa);
                LoadHangHoaList();
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

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadHangHoaList();
        }

        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvHH.Rows.Count - 1)
            // Kiểm tra nếu người dùng click vào một ô hợp lệ
            {
                DataGridViewRow row = dgvHH.Rows[e.RowIndex];
                var hangHoa = hangHoaRepository.GetHangHoaByID(Convert.ToInt32(row.Cells[0].Value));
                hh = new HangHoa()
                {
                    MaHangHoa = hangHoa.MaHangHoa,
                    TenHangHoa = hangHoa.TenHangHoa,
                    SoLuong = hangHoa.SoLuong,
                    DonGiaNhap = hangHoa.DonGiaNhap,
                    DonGiaBan = hangHoa.DonGiaBan,
                    Anh = hangHoa.Anh,
                    GhiChu = hangHoa.GhiChu
                };
            }
        }

        private void dgvHH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }
    }
}
