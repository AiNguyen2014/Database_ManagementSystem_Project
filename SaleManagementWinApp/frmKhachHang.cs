using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmKhachHang : Form
    {
        BindingSource source;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHangList();
        }

        public void LoadKhachHangList()
        {
            try
            {
                var khachHangs = KhachHangDAL.Instance.GetAll();
                source = new BindingSource();
                source.DataSource = khachHangs;

                dgvKH.DataSource = null;
                dgvKH.DataSource = source;

                dgvKH.Columns["MaKH"].HeaderText = "Mã KH";
                dgvKH.Columns["Hoten"].HeaderText = "Họ Tên";
                dgvKH.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dgvKH.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgvKH.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";

                bool hasData = khachHangs.Any();
                btnDelete.Enabled = hasData;
                btnUpdate.Enabled = hasData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải danh sách khách hàng");
            }
        }

        private KhachHang GetSelectedKhachHang()
        {
            if (dgvKH.SelectedRows.Count > 0)
            {
                return dgvKH.SelectedRows[0].DataBoundItem as KhachHang;
            }
            return null;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Mở form chi tiết ở chế độ "Thêm mới"
            frmKhachHangUpdate frmUpdate = new frmKhachHangUpdate
            {
                Text = "Thêm mới Khách hàng",
                InsertOrUpdate = false
            };

            if (frmUpdate.ShowDialog() == DialogResult.OK)
            {
                LoadKhachHangList(); // Tải lại danh sách sau khi thêm thành công
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            KhachHang selectedKhachHang = GetSelectedKhachHang();
            if (selectedKhachHang != null)
            {
                // Mở form chi tiết ở chế độ "Cập nhật" và truyền thông tin qua
                frmKhachHangUpdate frmUpdate = new frmKhachHangUpdate
                {
                    Text = "Cập nhật Khách hàng",
                    InsertOrUpdate = true,
                    KhachHangInfo = selectedKhachHang
                };

                if (frmUpdate.ShowDialog() == DialogResult.OK)
                {
                    LoadKhachHangList(); // Tải lại danh sách sau khi cập nhật thành công
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            KhachHang selectedKhachHang = GetSelectedKhachHang();
            if (selectedKhachHang != null)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    KhachHangDAL.Instance.Delete(selectedKhachHang.MaKH);
                    LoadKhachHangList();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo");
            }
        }

        private void txtSearchKH_TextChanged(object sender, EventArgs e)
        {
            var searchText = txtSearchKH.Text;
            source.Filter = $"Hoten LIKE '%{searchText}%' OR SoDienThoai LIKE '%{searchText}%'";
        }

        private void dgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}