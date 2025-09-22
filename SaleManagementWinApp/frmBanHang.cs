using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
                MessageBox.Show("Số loại SP lấy được: " + loaiSPList.Count);

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
            // Danh sách phương thức thanh toán cố định
            var phuongThucList = new List<string> { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" };

            cboPhuongThuc.DataSource = phuongThucList;
            cboPhuongThuc.SelectedIndex = 0; // chọn mặc định
        }


        private void SetupDataGridViews()
        {
            // Cấu hình cho lưới sản phẩm
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSP", HeaderText = "Tên Sản Phẩm", Width = 250 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaBan", HeaderText = "Giá Bán", Width = 120 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongTon", HeaderText = "SL Tồn", Width = 80 });

            // Cấu hình cho lưới giỏ hàng (Chi tiết hóa đơn)
            dgvChiTietHoaDon.AutoGenerateColumns = false;
            dgvChiTietHoaDon.Columns.Clear();
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSP", HeaderText = "Mã SP", ReadOnly = true, Width = 80 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số Lượng", Width = 100 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn Giá", ReadOnly = true, Width = 120 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành Tiền", ReadOnly = true, Width = 150 });
        }
        #endregion

        #region Xử lý Nghiệp vụ Bán hàng

        private void FilterSanPham()
        {
            try
            {
                var keyword = txtTimKiemSP.Text.Trim().ToLower();
                var selectedLoaiSP = (int)cboLoaiSP.SelectedValue;

                // Lấy danh sách tất cả sản phẩm từ DAL
                var allSanPham = SanPhamDAL.Instance.GetAll();

                // Lọc theo từ khóa
                if (!string.IsNullOrEmpty(keyword))
                {
                    allSanPham = allSanPham
                        .Where(sp => sp.TenSP.ToLower().Contains(keyword))
                        .ToList();
                }

                // Lọc theo loại SP nếu chọn khác "Tất cả"
                if (selectedLoaiSP > 0)
                {
                    allSanPham = allSanPham
                        .Where(sp => sp.MaLoaiSP == selectedLoaiSP)
                        .ToList();
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

        private void ThemSanPhamVaoGioHang(SanPham sp)
        {
            var itemInCart = gioHang.FirstOrDefault(item => item.MaSP == sp.MaSP);

            if (itemInCart != null)
            {
                itemInCart.SoLuong++;
            }
            else
            {
                gioHang.Add(new ChiTietHoaDon
                {
                    MaSP = sp.MaSP,
                    SoLuong = 1,
                    DonGia = sp.GiaBan
                });
            }

            RefreshGioHang();
        }

        private void dgvChiTietHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RefreshGioHang();
        }

        private void RefreshGioHang()
        {
            gioHangSource.DataSource = null;
            gioHangSource.DataSource = gioHang;
            dgvChiTietHoaDon.DataSource = gioHangSource;

            decimal tongTien = gioHang.Sum(item => item.ThanhTien ?? 0);
            lblTongTienValue.Text = $"{tongTien:N0} VNĐ";
        }
        #endregion

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtTimKiemKH.Text.Trim();

            try
            {
                if (string.IsNullOrWhiteSpace(soDienThoai))
                {
                    // Nếu ô tìm kiếm trống, hiển thị khách vãng lai
                    khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
                    lblTenKH.Text = "Khách vãng lai";
                    return;
                }

                var result = KhachHangDAL.Instance.GetBySoDienThoai(soDienThoai);
                if (result != null)
                {
                    // Nếu tìm thấy khách hàng, cập nhật và hiển thị tên
                    khachHangHienTai = result;
                    lblTenKH.Text = result.Hoten; // Hiển thị tên khách hàng
                    MessageBox.Show($"Đã tìm thấy khách hàng: {khachHangHienTai.Hoten}", "Thông báo");
                }
                else
                {
                    // Nếu không tìm thấy, hiển thị khách vãng lai
                    khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
                    lblTenKH.Text = "Khách vãng lai";
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị khách vãng lai
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
                    MaHD = (int)(DateTime.Now.Ticks % 1000000000),
                    NgayLap = DateTime.Now,
                    MaKH = khachHangHienTai.MaKH,
                    MaNV = 1, // Giả định nhân viên đăng nhập
                    TongTien = gioHang.Sum(item => item.ThanhTien ?? 0)
                };

                HoaDonDAL.Instance.AddNew(hoaDon);

                foreach (var item in gioHang)
                {
                    item.MaHD = hoaDon.MaHD;
                    item.MaCTHD = (int)(DateTime.Now.Ticks % 1000000000) + item.MaSP.Value;
                    ChiTietHoaDonDAL.Instance.AddNew(item);
                    SanPhamDAL.Instance.UpdateSoLuongTon(item.MaSP.Value, item.SoLuong.Value);
                }

                MessageBox.Show($"Tạo hóa đơn {hoaDon.MaHD} thành công!", "Thành công");
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