using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmKhachHangDangKy : Form
    {
        public frmKhachHangDangKy()
        {
            InitializeComponent();
        }

        private void frmKhachHangDangKy_Load(object sender, EventArgs e)
        {
            cboGioiTinh.SelectedIndex = 0; // Mặc định chọn Nam
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                    string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                    string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtMatKhau.Text != txtXacNhanMK.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Kiểm tra dữ liệu có bị trùng không
                if (TaiKhoanDAL.Instance.GetByTenDangNhap(txtTenDangNhap.Text) != null)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (KhachHangDAL.Instance.GetBySoDienThoai(txtSoDienThoai.Text) != null)
                {
                    MessageBox.Show("Số điện thoại này đã được đăng ký. Vui lòng dùng SĐT khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Tạo đối tượng KhachHang và lưu vào DB
                var khachHang = new KhachHang
                {
                    Hoten = txtHoTen.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    GioiTinh = cboGioiTinh.SelectedItem.ToString()
                };
                // Thêm khách hàng và lấy lại MaKH vừa tạo
                int newMaKH = KhachHangDAL.Instance.AddNew(khachHang);

                // Tạo đối tượng TaiKhoan
                var taiKhoan = new TaiKhoan
                {
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text,
                    // SỬA LẠI: Gán MaVaiTro của KhachHang (giả sử là 4)
                    MaVaiTro = 4,
                    MaKH = newMaKH
                };
                TaiKhoanDAL.Instance.AddNew(taiKhoan);

                MessageBox.Show("Đăng ký tài khoản thành công!", "Thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi");
            }
        }
    }
}
