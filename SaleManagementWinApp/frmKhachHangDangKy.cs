using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
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
            // Mặc định chọn giới tính là Nam
            cboGioiTinh.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

                // 4. Tạo đối tượng TaiKhoan và lưu vào DB
                var taiKhoan = new TaiKhoan
                {
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text, // Nhớ mã hóa mật khẩu trong dự án thực tế
                    VaiTro = "KhachHang", // Tự động gán vai trò
                    MaKH = newMaKH // Liên kết với khách hàng vừa tạo
                };
                TaiKhoanDAL.Instance.AddNew(taiKhoan);

                // 5. Thông báo thành công
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
