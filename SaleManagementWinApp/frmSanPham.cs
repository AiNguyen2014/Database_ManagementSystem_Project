using SaleManagementLibrraly.DataAccess;
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
    public partial class frmSanPham : Form
    {
        private SanPhamDAL sanPhamDAL = SanPhamDAL.Instance;

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }

        private void LoadDanhSachSanPham()
        {
            try
            {
                DataTable dt = sanPhamDAL.GetAllSanPham();
                dgvHangHoa.DataSource = dt;
                // Tùy chỉnh tiêu đề cột cho thân thiện hơn
                if (dgvHangHoa.Columns.Contains("MaSP")) dgvHangHoa.Columns["MaSP"].HeaderText = "Mã SP";
                if (dgvHangHoa.Columns.Contains("TenSP")) dgvHangHoa.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                if (dgvHangHoa.Columns.Contains("DonViTinh")) dgvHangHoa.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
                if (dgvHangHoa.Columns.Contains("GiaNhap")) dgvHangHoa.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                if (dgvHangHoa.Columns.Contains("DonGia")) dgvHangHoa.Columns["DonGia"].HeaderText = "Đơn Giá";
                if (dgvHangHoa.Columns.Contains("HanSuDung")) dgvHangHoa.Columns["HanSuDung"].HeaderText = "Hạn Sử Dụng";
                if (dgvHangHoa.Columns.Contains("SoLuongTon")) dgvHangHoa.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
                if (dgvHangHoa.Columns.Contains("MaLoaiSP")) dgvHangHoa.Columns["MaLoaiSP"].HeaderText = "Mã Loại SP";
                if (dgvHangHoa.Columns.Contains("TrangThai"))   dgvHangHoa.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}