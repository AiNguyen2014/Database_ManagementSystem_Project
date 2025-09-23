using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmMainKhachHang : Form
    {
        public TaiKhoan LoggedInAccount { get; set; }

        // KHAI BÁO BIẾN "gioHang" BỊ THIẾU
        private List<ChiTietHoaDon> gioHang;

        public frmMainKhachHang()
        {
            InitializeComponent();
            // Khởi tạo giỏ hàng khi form được tạo
            gioHang = new List<ChiTietHoaDon>();
        }

        private void frmMainKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                if (LoggedInAccount != null && LoggedInAccount.MaKH.HasValue)
                {
                    var khachHang = KhachHangDAL.Instance.GetKhachHangByID(LoggedInAccount.MaKH.Value);
                    if (khachHang != null)
                    {
                        mnuChao.Text = "Chào: " + khachHang.Hoten;
                    }
                }
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin chính: " + ex.Message);
            }
        }

        private void LoadProductList()
        {
            try
            {
                var products = SanPhamDAL.Instance.GetAllProducts();
                dgvSanPham.DataSource = null; // Xóa dữ liệu cũ để cập nhật
                dgvSanPham.DataSource = products;

                // --- BỔ SUNG ĐOẠN CODE NÀY ---

                // 1. Tùy chỉnh lại tên cột cho thân thiện hơn
                dgvSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvSanPham.Columns["DonViTinh"].HeaderText = "Đơn Vị";
                dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvSanPham.Columns["HanSuDung"].HeaderText = "Hạn Sử Dụng";
                dgvSanPham.Columns["TrangThai"].HeaderText = "Tình Trạng";
                dgvSanPham.Columns["TenLoaiSP"].HeaderText = "Loại Sản Phẩm";

                // 2. Ẩn các cột không cần thiết cho khách hàng
                dgvSanPham.Columns["MaSP"].Visible = false;
                dgvSanPham.Columns["GiaNhap"].Visible = false;       // Rất quan trọng, không để lộ giá vốn!
                dgvSanPham.Columns["SoLuongTon"].Visible = false;    // Khách hàng chỉ cần biết còn hàng hay hết hàng
                dgvSanPham.Columns["MaLoaiSP"].Visible = false;
                dgvSanPham.Columns["DonGia"].Visible = false;        // Ẩn vì đã có cột GiaBan rõ ràng hơn

                // -----------------------------
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void mnuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan frm = new frmThongTinCaNhan();
            frm.LoggedInAccount = this.LoggedInAccount;
            frm.ShowDialog();
        }

        private void mnuLichSuMuaHang_Click(object sender, EventArgs e)
        {
            frmLichSuMuaHang frm = new frmLichSuMuaHang();
            frm.LoggedInAccount = this.LoggedInAccount;
            frm.ShowDialog();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
            {
                // Lấy thông tin từ dòng được chọn
                var trangThai = dgvSanPham.CurrentRow.Cells["TrangThai"].Value.ToString();
                var soLuongTon = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["SoLuongTon"].Value);
                var tenSP = dgvSanPham.CurrentRow.Cells["TenSP"].Value.ToString();

                // KIỂM TRA ĐIỀU KIỆN TRƯỚC KHI THÊM
                if (trangThai.Equals("Hết hàng", StringComparison.OrdinalIgnoreCase) || soLuongTon <= 0)
                {
                    MessageBox.Show($"Sản phẩm '{tenSP}' đã hết hàng. Vui lòng chọn sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại, không cho thêm
                }

                var soLuongMua = (int)numSoLuong.Value;
                if (soLuongMua > soLuongTon)
                {
                    MessageBox.Show($"Số lượng tồn kho của '{tenSP}' không đủ. Chỉ còn lại {soLuongTon}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại, không cho thêm
                }

                // Nếu mọi thứ hợp lệ, tiến hành thêm vào giỏ hàng
                var maSP = (int)dgvSanPham.CurrentRow.Cells["MaSP"].Value;
                var donGia = (decimal)dgvSanPham.CurrentRow.Cells["GiaBan"].Value;

                gioHang.Add(new ChiTietHoaDon { MaSP = maSP, SoLuong = soLuongMua, DonGia = donGia });
                MessageBox.Show($"Đã thêm {soLuongMua} {tenSP} vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numSoLuong.Value = 1;
            }
        }

        private void btnXemGioHang_Click(object sender, EventArgs e)
        {
            frmGioHang frm = new frmGioHang();
            frm.DanhSachMuaHang = this.gioHang;
            frm.KhachHangHienTai = this.LoggedInAccount;
            frm.ShowDialog();
            gioHang.Clear();
        }

        // PHƯƠNG THỨC mnuThoat_Click BỊ THIẾU
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}