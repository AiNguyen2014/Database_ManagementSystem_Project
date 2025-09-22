using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess; // SỬA: Dùng DataAccess
using System;
using System.Linq;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmQuanLySanPham : Form // SỬA: Tên class đã đổi
    {
        // KHÔNG DÙNG Repository nữa
        BindingSource source;

        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadSanPhamList();
        }

        public void LoadSanPhamList()
        {
            try
            {
                var sanPhams = SanPhamDAL.Instance.GetAll();
                source = new BindingSource();
                source.DataSource = sanPhams;

                dgvHH.DataSource = null;
                dgvHH.DataSource = source;

                // Tự động tạo cột, không cần tạo thủ công
                dgvHH.AutoGenerateColumns = true;
                // Tùy chỉnh tiêu đề cột cho thân thiện hơn
                dgvHH.Columns["MaSP"].HeaderText = "Mã SP";
                dgvHH.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvHH.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
                dgvHH.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                dgvHH.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvHH.Columns["HanSuDung"].HeaderText = "Hạn Sử Dụng";
                dgvHH.Columns["SoLuongTon"].HeaderText = "SL Tồn";
                dgvHH.Columns["MaLoaiSP"].HeaderText = "Mã Loại SP";
                dgvHH.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvHH.Columns["DonGia"].Visible = false; // Có thể ẩn cột không cần thiết

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải danh sách sản phẩm");
            }
        }

        private SanPham GetSelectedSanPham()
        {
            if (dgvHH.SelectedRows.Count > 0)
            {
                return dgvHH.SelectedRows[0].DataBoundItem as SanPham;
            }
            return null;
        }

        private void txtSearchHH_TextChanged(object sender, EventArgs e)
        {
            // Tối ưu tìm kiếm bằng BindingSource.Filter
            var searchText = txtSearchHH.Text;
            // Tìm theo Tên sản phẩm hoặc Trạng thái
            source.Filter = $"TenSP LIKE '%{searchText}%' OR TrangThai LIKE '%{searchText}%'";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Chúng ta sẽ sửa form này ở bước sau
            // frmSanPhamUpdate frmUpdate = new frmSanPhamUpdate { InsertOrUpdate = false };
            // if (frmUpdate.ShowDialog() == DialogResult.OK)
            // {
            //     LoadSanPhamList();
            // }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SanPham selectedSanPham = GetSelectedSanPham();
            if (selectedSanPham != null)
            {
                // Chúng ta sẽ sửa form này ở bước sau
                // frmSanPhamUpdate frmUpdate = new frmSanPhamUpdate {
                //     InsertOrUpdate = true,
                //     SanPhamInfo = selectedSanPham
                // };
                // if (frmUpdate.ShowDialog() == DialogResult.OK)
                // {
                //     LoadSanPhamList();
                // }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để cập nhật.");
            }
        }

        private void dgvHH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        

        // Các nút Delete, Close bạn có thể thêm vào tương tự như form Nhân Viên
    }
}