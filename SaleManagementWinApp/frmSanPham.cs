using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess; // SỬA: Dùng DataAccess
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmSanPham : Form
    {
        BindingSource source;
        // Giữ lại giỏ hàng trong bộ nhớ, đây là cách làm đơn giản và hợp lý
        List<GioHang> list_GH;

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            list_GH = new List<GioHang>();
            LoadSanPhamList();
            LoadGioHangList(); // Tải giỏ hàng rỗng ban đầu
        }

        public void LoadSanPhamList()
        {
            try
            {
                var sanPhams = SanPhamDAL.Instance.GetAll();
                source = new BindingSource();
                source.DataSource = sanPhams;

                dgvHangHoa.DataSource = null;
                dgvHangHoa.DataSource = source;
                // Có thể thêm code để tùy chỉnh các cột ở đây nếu muốn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        public void LoadGioHangList()
        {
            // Hàm này dùng để cập nhật lại DataGridView của giỏ hàng
            var sourceGH = new BindingSource();
            sourceGH.DataSource = list_GH;

            dgvCart.DataSource = null;
            dgvCart.DataSource = sourceGH;
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi người dùng bấm nút "Mua" trên lưới
            // Cần đảm bảo bạn đã thêm một cột Button vào dgvHangHoa
            // Và kiểm tra e.ColumnIndex cho đúng

            // Ví dụ, giả sử cột cuối cùng là cột Button "Mua"
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHangHoa.Columns.Count - 1)
            {
                var selectedSP = dgvHangHoa.Rows[e.RowIndex].DataBoundItem as SanPham;
                if (selectedSP != null)
                {
                    // Thêm sản phẩm vào giỏ
                    var itemInCart = list_GH.FirstOrDefault(item => item.MaHangHoa == selectedSP.MaSP);
                    if (itemInCart != null)
                    {
                        itemInCart.SoLuong++;
                    }
                    else
                    {
                        list_GH.Add(new GioHang { MaHangHoa = selectedSP.MaSP, SoLuong = 1, DonGia = selectedSP.GiaBan });
                    }
                    LoadGioHangList(); // Cập nhật lại view giỏ hàng
                }
            }
        }

        // Các hàm khác như xóa khỏi giỏ hàng...
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tương tự, xử lý khi bấm nút "Xóa" trên giỏ hàng
        }
    }
}