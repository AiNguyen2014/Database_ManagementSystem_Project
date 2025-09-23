using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmGioHang : Form
    {
        public List<ChiTietHoaDon> DanhSachMuaHang { get; set; }
        public TaiKhoan KhachHangHienTai { get; set; }

        public frmGioHang()
        {
            InitializeComponent();
        }

        private void frmGioHang_Load(object sender, EventArgs e)
        {
            LoadCartDetails();
        }

        private void LoadCartDetails()
        {
            // Tạo một danh sách tạm để hiển thị thông tin thân thiện hơn
            var displayList = new List<object>();
            if (DanhSachMuaHang != null)
            {
                foreach (var item in DanhSachMuaHang)
                {
                    // Lấy tên sản phẩm từ MaSP
                    var sanPham = SanPhamDAL.Instance.GetSanPhamByID(item.MaSP.Value); // Giả sử có hàm GetByID
                    displayList.Add(new
                    {
                        TenSanPham = sanPham.TenSP,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia,
                        ThanhTien = (item.SoLuong ?? 0) * (item.DonGia ?? 0)
                    });
                }
            }

            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = displayList;

            // Tùy chỉnh lại tên cột
            if (displayList.Any())
            {
                dgvGioHang.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dgvGioHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvGioHang.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            }

            // Tính tổng tiền
            decimal tongTien = DanhSachMuaHang?.Sum(item => (item.SoLuong ?? 0) * (item.DonGia ?? 0)) ?? 0;
            lblTongTienValue.Text = tongTien.ToString("N0") + " VND";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (DanhSachMuaHang == null || !DanhSachMuaHang.Any())
            {
                MessageBox.Show("Giỏ hàng của bạn đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Tạo hóa đơn mới
                var hoaDon = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    MaKH = KhachHangHienTai.MaKH,
                    TongTien = DanhSachMuaHang.Sum(item => (item.SoLuong ?? 0) * (item.DonGia ?? 0))
                };

                // Gọi hàm AddNew và lấy MaHD mới từ đối tượng hoaDon
                HoaDonDAL.Instance.AddNew(hoaDon);

                // Kiểm tra xem MaHD có giá trị không rồi mới lấy
                if (!hoaDon.MaHD.HasValue)
                {
                    throw new Exception("Không thể lấy mã hóa đơn mới sau khi tạo.");
                }
                int newMaHD = hoaDon.MaHD.Value; // Dùng .Value để lấy giá trị

                // 2. Thêm chi tiết hóa đơn
                foreach (var item in DanhSachMuaHang)
                {
                    item.MaHD = newMaHD;
                    ChiTietHoaDonDAL.Instance.AddNew(item);

                    // 3. Cập nhật số lượng tồn kho
                    if (item.MaSP.HasValue && item.SoLuong.HasValue)
                    {
                        SanPhamDAL.Instance.UpdateSoLuongTon(item.MaSP.Value, item.SoLuong.Value);
                    }
                }

                MessageBox.Show("Thanh toán thành công! Cảm ơn bạn đã mua hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}