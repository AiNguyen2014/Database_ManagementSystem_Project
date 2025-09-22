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
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaBan", HeaderText = "Giá Gốc", Width = 100 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaTriGiam", HeaderText = "Giảm Giá", Width = 100 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaSauGiam", HeaderText = "Giá Sau Giảm", Width = 100 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongTon", HeaderText = "SL Tồn", Width = 80 });

            // Cấu hình cho lưới giỏ hàng (Chi tiết hóa đơn)
            dgvChiTietHoaDon.AutoGenerateColumns = false;
            dgvChiTietHoaDon.Columns.Clear();
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên Sản Phẩm", ReadOnly = true, Width = 200 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số Lượng", Width = 100 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn Giá", ReadOnly = true, Width = 100 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiamGia", HeaderText = "Giảm Giá", ReadOnly = true, Width = 100 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTienSauGiam", HeaderText = "Thành Tiền Sau Giảm", ReadOnly = true, Width = 150 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenKH", HeaderText = "Tên KH", ReadOnly = true, Width = 150 });
            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNV", HeaderText = "Tên NV", ReadOnly = true, Width = 150 });
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

        // Thêm một phương thức nhỏ để tính toán lại thành tiền cho một dòng, tránh lặp code
        private void CapNhatThanhTien(ChiTietHoaDon item)
        {
            // Thành tiền sau giảm = Số lượng * Đơn giá (đã áp dụng giảm giá)
            item.ThanhTienSauGiam = item.SoLuong * item.DonGia;
        }

        private void ThemSanPhamVaoGioHang(SanPham sp)
        {
            var itemInCart = gioHang.FirstOrDefault(item => item.MaSP == sp.MaSP);

            if (itemInCart != null)
            {
                itemInCart.SoLuong++;
                CapNhatThanhTien(itemInCart);
            }
            else
            {
                SanPhamKhuyenMai spKhuyenMai = ChiTietHoaDonDAL.Instance.GetSanPhamKhuyenMai(sp.MaSP);

                decimal donGiaApDung;
                decimal giamGiaValue;

                if (spKhuyenMai != null)
                {
                    // SỬA Ở ĐÂY: Thêm ?? 0 để xử lý trường hợp giá trị có thể là null
                    donGiaApDung = spKhuyenMai.GiaSauGiam ?? 0;
                    giamGiaValue = spKhuyenMai.GiaTriGiam ?? 0;
                }
                else
                {
                    // SỬA Ở ĐÂY: Thêm ?? 0 để phòng trường hợp GiaBan cũng là nullable
                    donGiaApDung = sp.GiaBan;
                    giamGiaValue = 0;
                }

                var newItem = new ChiTietHoaDon
                {
                    MaSP = sp.MaSP,
                    TenSanPham = sp.TenSP,
                    SoLuong = 1,
                    DonGia = donGiaApDung,
                    GiamGia = giamGiaValue,
                    ThanhTienSauGiam = donGiaApDung
                };
                gioHang.Add(newItem);
            }

            RefreshGioHang();
        }

        private void dgvChiTietHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải cột "Số Lượng" được sửa không
            if (e.RowIndex >= 0 && dgvChiTietHoaDon.Columns[e.ColumnIndex].DataPropertyName == "SoLuong")
            {
                // Lấy đối tượng ChiTietHoaDon tương ứng với dòng vừa sửa
                var itemEdited = gioHang[e.RowIndex];

                // Lấy giá trị mới từ ô
                var cellValue = dgvChiTietHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Cố gắng chuyển đổi giá trị sang số nguyên
                if (int.TryParse(cellValue?.ToString(), out int newQuantity))
                {
                    if (newQuantity <= 0)
                    {
                        // Nếu người dùng nhập số <= 0, hỏi để xóa sản phẩm
                        var result = MessageBox.Show("Số lượng không hợp lệ. Bạn có muốn xóa sản phẩm này khỏi giỏ hàng không?", "Xác nhận", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            gioHang.Remove(itemEdited);
                        }
                        else
                        {
                            // Nếu không xóa, khôi phục lại số lượng cũ
                            dgvChiTietHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = itemEdited.SoLuong;
                        }
                    }
                    else
                    {
                        // Nếu số lượng hợp lệ, cập nhật và tính lại thành tiền
                        itemEdited.SoLuong = newQuantity;
                        CapNhatThanhTien(itemEdited);
                    }
                }
            }

            // Luôn làm mới giỏ hàng sau khi chỉnh sửa để cập nhật tổng tiền
            RefreshGioHang();
        }

        private void RefreshGioHang()
        {
            gioHangSource.DataSource = null;
            gioHangSource.DataSource = gioHang;
            dgvChiTietHoaDon.DataSource = gioHangSource;

            // Tính tổng tiền dựa trên ThanhTienSauGiam từ view
            decimal tongTien = gioHang.Sum(item => item.ThanhTienSauGiam ?? 0);
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
                // Tạo đối tượng HoaDon
                var hoaDon = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    MaKH = khachHangHienTai.MaKH,
                    MaNV = 1 // Giả định nhân viên đăng nhập
                };

                // Gọi AddNew từ HoaDonDAL để tạo hóa đơn
                HoaDonDAL.Instance.AddNew(hoaDon);

                // Lấy MaHD từ đối tượng hoaDon
                int maHD = hoaDon.MaHD ?? throw new Exception("Không thể lấy MaHD sau khi tạo hóa đơn.");

                // Debug để kiểm tra giá trị MaHD
                MessageBox.Show($"MaHD sau khi tạo hóa đơn: {maHD}");

                // Thêm chi tiết hóa đơn
                foreach (var item in gioHang)
                {
                    var chiTiet = new ChiTietHoaDon
                    {
                        MaHD = maHD,
                        MaSP = item.MaSP,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    ChiTietHoaDonDAL.Instance.AddNew(chiTiet);
                }

                // Lấy danh sách chi tiết hóa đơn từ view để cập nhật giao diện
                var chiTietList = ChiTietHoaDonDAL.Instance.GetChiTietHoaDonByMaHD(maHD);
                if (chiTietList != null && chiTietList.Any())
                {
                    gioHang.Clear();
                    gioHang.AddRange(chiTietList);
                    RefreshGioHang();
                }
                else
                {
                    throw new Exception("Không thể lấy chi tiết hóa đơn từ view sau khi thêm.");
                }

                // Cập nhật biên lai
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