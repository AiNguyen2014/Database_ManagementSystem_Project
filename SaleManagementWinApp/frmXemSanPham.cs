using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmXemSanPham : Form
    {
        public frmXemSanPham()
        {
            InitializeComponent();
        }

        // PHƯƠNG THỨC frmXemSanPham_Load BỊ THIẾU
        private void frmXemSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                var products = SanPhamDAL.Instance.GetAllProducts();
                dgvSanPham.DataSource = products;

                // Tùy chỉnh lại tên cột cho đẹp
                dgvSanPham.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
                dgvSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvSanPham.Columns["DonViTinh"].HeaderText = "Đơn Vị";
                dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                dgvSanPham.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        // PHƯƠNG THỨC btnDong_Click BỊ THIẾU
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}