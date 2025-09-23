using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;

namespace SaleManagementWinApp
{
    public partial class frmBanHang : Form
    {
        // Dùng để lưu danh sách sản phẩm và chi tiết hóa đơn (giỏ hàng)
        private BindingSource sanPhamSource;
        private BindingSource gioHangSource;

        // Dùng để lưu trữ giỏ hàng hiện tại
        private List<ChiTietHoaDon> gioHang;
        private KhachHang khachHangHienTai;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // Khởi tạo các đối tượng cần thiết
            gioHang = new List<ChiTietHoaDon>();
            sanPhamSource = new BindingSource();
            gioHangSource = new BindingSource();

            // Thiết lập khách hàng mặc định là khách vãng lai
            khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
            lblTenKH.Text = khachHangHienTai.Hoten; // Hiển thị khách vãng lai mặc định

            // Tải dữ liệu lên các control
            LoadLoaiSanPham();
            LoadDanhSachSanPham();
            SetupDataGridViews();
            LoadPhuongThuc();

            // Gán sự kiện cho các control
            cboLoaiSP.SelectedIndexChanged += (s, ev) => FilterSanPham();
            txtTimKiemSP.TextChanged += (s, ev) => FilterSanPham();
            dgvSanPham.CellDoubleClick += dgvSanPham_CellDoubleClick;
            dgvChiTietHoaDon.CellEndEdit += dgvChiTietHoaDon_CellEndEdit;
            btnTimKH.Click += btnTimKH_Click;
            btnThanhToan.Click += btnThanhToan_Click;
        }

        #region Tải dữ liệu và Cài đặt ban đầu
        private void LoadLoaiSanPham()
        {
            try
            {
                var loaiSPList = LoaiSanPhamDAL.Instance.GetAll().ToList();
                loaiSPList.Insert(0, new LoaiSanPham { MaLoaiSP = 0, TenLoaiSP = "Tất cả loại" });
                cboLoaiSP.DataSource = loaiSPList;
                cboLoaiSP.DisplayMember = "TenLoaiSP";
                cboLoaiSP.ValueMember = "MaLoaiSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải loại sản phẩm: " + ex.Message);
            }
        }

        private void LoadDanhSachSanPham()
        {
            try
            {
                var sanPhams = SanPhamDAL.Instance.GetAll();
                sanPhamSource.DataSource = sanPhams;
                dgvSanPham.DataSource = sanPhamSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }
        private void LoadPhuongThuc()
        {
            var phuongThucList = new List<string> { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" };
            cboPhuongThuc.DataSource = phuongThucList;
            cboPhuongThuc.SelectedIndex = 0;
        }

        private void SetupDataGridViews()
        {
            // Cấu hình cho lưới sản phẩm (đã bỏ các cột khuyến mãi)
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSP", HeaderText = "Tên Sản Phẩm", Width = 350 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaBan", HeaderText = "Giá Bán", Width = 150 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongTon", HeaderText = "SL Tồn", Width = 80 });

            // Cấu hình cho lưới giỏ hàng (đã bỏ các cột khuyến mãi và thông tin thừa)
            dgvChiTietHoaDon.AutoGenerateColumns = false;
            dgvChiTietHoaDon.Columns.Clear();
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên Sản Phẩm", ReadOnly = true, Width = 250 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số Lượng", Width = 100 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn Giá", ReadOnly = true, Width = 150 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành Tiền", ReadOnly = true, Width = 200 });
        }
        #endregion

        #region Xử lý Nghiệp vụ Bán hàng

        private void FilterSanPham()
        {
            try
            {
                var keyword = txtTimKiemSP.Text.Trim().ToLower();
                var selectedLoaiSP = (int)cboLoaiSP.SelectedValue;
                var allSanPham = SanPhamDAL.Instance.GetAll();

                if (!string.IsNullOrEmpty(keyword))
                {
                    allSanPham = allSanPham.Where(sp => sp.TenSP.ToLower().Contains(keyword)).ToList();
                }

                if (selectedLoaiSP > 0)
                {
                    allSanPham = allSanPham.Where(sp => sp.MaLoaiSP == selectedLoaiSP).ToList();
                }

                sanPhamSource.DataSource = allSanPham;
                dgvSanPham.DataSource = sanPhamSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc sản phẩm: " + ex.Message);
            }
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedSanPham = dgvSanPham.Rows[e.RowIndex].DataBoundItem as SanPham;
                if (selectedSanPham != null)
                {
                    ThemSanPhamVaoGioHang(selectedSanPham);
                }
            }
        }

        // Cập nhật lại thành tiền của một sản phẩm trong giỏ hàng
        private void CapNhatThanhTien(ChiTietHoaDon item)
        {
            item.ThanhTien = item.SoLuong * item.DonGia;
        }

        // Thêm sản phẩm vào giỏ hàng (đã bỏ logic khuyến mãi)
        private void ThemSanPhamVaoGioHang(SanPham sp)
        {
            var itemInCart = gioHang.FirstOrDefault(item => item.MaSP == sp.MaSP);

            if (itemInCart != null)
            {
                // Nếu sản phẩm đã có, chỉ tăng số lượng
                itemInCart.SoLuong++;
                CapNhatThanhTien(itemInCart);
            }
            else
            {
                // Nếu sản phẩm chưa có, thêm mới vào giỏ hàng với giá gốc
                var newItem = new ChiTietHoaDon
                {
                    MaSP = sp.MaSP,
                    TenSanPham = sp.TenSP,
                    SoLuong = 1,
                    DonGia = sp.DonGia
                });
                    DonGia = sp.GiaBan,
                    ThanhTien = sp.GiaBan // Số lượng là 1 nên thành tiền bằng đơn giá
                };
                gioHang.Add(newItem);
            }

            RefreshGioHang();
        }

        private void dgvChiTietHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvChiTietHoaDon.Columns[e.ColumnIndex].DataPropertyName == "SoLuong")
            {
                var itemEdited = gioHang[e.RowIndex];
                var cellValue = dgvChiTietHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (int.TryParse(cellValue?.ToString(), out int newQuantity))
                {
                    if (newQuantity <= 0)
                    {
                        var result = MessageBox.Show("Số lượng không hợp lệ. Bạn có muốn xóa sản phẩm này khỏi giỏ hàng không?", "Xác nhận", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            gioHang.Remove(itemEdited);
                        }
                        else
                        {
                            dgvChiTietHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = itemEdited.SoLuong;
                        }
                    }
                    else
                    {
                        itemEdited.SoLuong = newQuantity;
                        CapNhatThanhTien(itemEdited);
                    }
                }
                RefreshGioHang();
            }
        }

        // Làm mới giỏ hàng và tính lại tổng tiền (đã bỏ logic khuyến mãi)
        private void RefreshGioHang()
        {
            gioHangSource.DataSource = null;
            gioHangSource.DataSource = gioHang;
            dgvChiTietHoaDon.DataSource = gioHangSource;

            decimal tongTien = gioHang.Sum(item => item.ThanhTien ?? 0);
            lblTongTienValue.Text = tongTien > 0 ? $"{tongTien:N0} VNĐ" : "0 VNĐ";
        }
        #endregion

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtTimKiemKH.Text.Trim();
            try
            {
                if (string.IsNullOrWhiteSpace(soDienThoai))
                {
                    khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
                    lblTenKH.Text = "Khách vãng lai";
                    return;
                }

                var result = KhachHangDAL.Instance.GetBySoDienThoai(soDienThoai);
                if (result != null)
                {
                    khachHangHienTai = result;
                    lblTenKH.Text = result.Hoten;
                    MessageBox.Show($"Đã tìm thấy khách hàng: {khachHangHienTai.Hoten}", "Thông báo");
                }
                else
                {
                    khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
                    lblTenKH.Text = "Khách vãng lai";
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
                lblTenKH.Text = "Khách vãng lai";
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!gioHang.Any())
            {
                MessageBox.Show("Giỏ hàng đang trống, không thể thanh toán.", "Thông báo");
                return;
            }

            try
            {
                var hoaDon = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    MaKH = khachHangHienTai.MaKH,
                    MaNV = 1 // Giả định nhân viên đăng nhập
                };

                HoaDonDAL.Instance.AddNew(hoaDon);

                int maHD = hoaDon.MaHD ?? throw new Exception("Không thể lấy MaHD sau khi tạo hóa đơn.");

                foreach (var item in gioHang)
                {
                    var chiTiet = new ChiTietHoaDon
                    {
                        MaHD = maHD,
                        MaSP = item.MaSP,
                        SoLuong = item.SoLuong,
                        // 'DonGia' trong giỏ hàng đã là giá gốc của sản phẩm
                        DonGia = item.DonGia
                    };
                    ChiTietHoaDonDAL.Instance.AddNew(chiTiet);
                }

                BienLaiDAL.Instance.CapNhatBienLai(maHD, cboPhuongThuc.SelectedValue.ToString(), "Đã thanh toán");

                MessageBox.Show($"Tạo hóa đơn {maHD} thành công!", "Thành công");
                ClearFormBanHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi");
            }
        }

        private void ClearFormBanHang()
        {
            gioHang.Clear();
            RefreshGioHang();

            khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
            lblTenKH.Text = "Khách vãng lai";
            txtTimKiemKH.Clear();

            LoadDanhSachSanPham();
        }
    }
}