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
            khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" }; // Giả định MaKH=1 là khách vãng lai

            // Tải dữ liệu lên các control
            LoadLoaiSanPham();
            LoadDanhSachSanPham();
            SetupDataGridViews();

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
                // Thêm một mục "Tất cả" vào đầu danh sách
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
            var keyword = txtTimKiemSP.Text;
            var selectedLoaiSP = (int)cboLoaiSP.SelectedValue;

            string filter = "";

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $"TenSP LIKE '%{keyword}%'";
            }

            if (selectedLoaiSP > 0)
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"MaLoaiSP = {selectedLoaiSP}";
            }

            sanPhamSource.Filter = filter;
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
            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            var itemInCart = gioHang.FirstOrDefault(item => item.MaSP == sp.MaSP);

            if (itemInCart != null)
            {
                // Nếu có rồi thì tăng số lượng lên 1
                itemInCart.SoLuong++;
            }
            else
            {
                // Nếu chưa có thì thêm mới vào giỏ hàng
                gioHang.Add(new ChiTietHoaDon
                {
                    MaSP = sp.MaSP,
                    SoLuong = 1,
                    DonGia = sp.GiaBan
                });
            }

            // Cập nhật lại giỏ hàng và tổng tiền
            RefreshGioHang();
        }

        private void dgvChiTietHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Khi người dùng sửa số lượng trong giỏ hàng, cập nhật lại tổng tiền
            RefreshGioHang();
        }

        private void RefreshGioHang()
        {
            gioHangSource.DataSource = null;
            gioHangSource.DataSource = gioHang;
            dgvChiTietHoaDon.DataSource = gioHangSource;

            // Tính toán và hiển thị tổng tiền
            decimal tongTien = gioHang.Sum(item => item.ThanhTien ?? 0);
            lblTongTienValue.Text = $"{tongTien:N0} VNĐ"; // Format tiền tệ
        }
        #endregion

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtTimKiemKH.Text;
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                // Nếu ô tìm kiếm trống, quay về khách vãng lai
                khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
                lblTenKH.Text = khachHangHienTai.Hoten;
                return;
            }

            try
            {
                var result = KhachHangDAL.Instance.GetBySoDienThoai(soDienThoai);
                if (result != null)
                {
                    khachHangHienTai = result;
                    lblTenKH.Text = $"KH: {khachHangHienTai.Hoten}"; // Hiển thị tên khách hàng tìm thấy
                    MessageBox.Show("Đã chọn khách hàng: " + khachHangHienTai.Hoten);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng. Vui lòng thêm mới nếu cần.");
                    khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
                    lblTenKH.Text = khachHangHienTai.Hoten;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message);
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
                // Bước 1: Tạo đối tượng Hóa Đơn
                var hoaDon = new HoaDon
                {
                    // Lưu ý: MaHD của bạn không phải tự tăng, nên ta phải tự tạo.
                    // Cách đơn giản là dùng ticks, nhưng không an toàn trong thực tế.
                    MaHD = (int)(DateTime.Now.Ticks % 1000000000),
                    NgayLap = DateTime.Now,
                    MaKH = khachHangHienTai.MaKH,
                    MaNV = 1, // Giả định nhân viên đăng nhập có MaNV=1, bạn sẽ thay thế sau
                    TongTien = gioHang.Sum(item => item.ThanhTien ?? 0)
                };

                // Bước 2: Lưu Hóa Đơn vào DB
                HoaDonDAL.Instance.AddNew(hoaDon);

                // Bước 3: Lưu từng Chi Tiết Hóa Đơn và cập nhật số lượng sản phẩm
                foreach (var item in gioHang)
                {
                    // Gán MaHD mới tạo cho từng chi tiết
                    item.MaHD = hoaDon.MaHD;
                    // MaCTHD cũng cần tự tạo
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
            // Reset giỏ hàng
            gioHang.Clear();
            RefreshGioHang();

            // Reset khách hàng
            khachHangHienTai = new KhachHang { MaKH = 1, Hoten = "Khách vãng lai" };
            lblTenKH.Text = khachHangHienTai.Hoten;
            txtTimKiemKH.Clear();

            // Tải lại danh sách sản phẩm (để cập nhật số lượng tồn)
            LoadDanhSachSanPham();
        }
    }
}