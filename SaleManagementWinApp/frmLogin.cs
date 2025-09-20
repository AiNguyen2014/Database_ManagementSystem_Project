using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess; // SỬA: Dùng DataAccess thay vì Repository
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Giữ lại phần kiểm tra dữ liệu trống, rất tốt!
                if (string.IsNullOrEmpty(txtDangNhap.Text))
                {
                    errorProvider1?.SetError(txtDangNhap, "Vui lòng nhập tên đăng nhập");
                    return;
                }
                if (string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    errorProvider1?.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
                    return;
                }

                errorProvider1?.Clear();

                // SỬA: Gọi trực tiếp hàm CheckLogin từ TaiKhoanDAL
                TaiKhoan taiKhoan = TaiKhoanDAL.Instance.CheckLogin(txtDangNhap.Text, txtMatKhau.Text);

                if (taiKhoan != null) // Nếu tìm thấy tài khoản
                {
                    this.Hide(); // Ẩn form login đi

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // SỬA: Kiểm tra vai trò bằng chuỗi (string), không dùng số
                    if (taiKhoan.VaiTro.Equals("NhanVien", StringComparison.OrdinalIgnoreCase))
                    {
                        // Mở form chính cho nhân viên/quản trị
                        frmMain f_main = new frmMain();
                        f_main.ShowDialog(); // Dùng ShowDialog để form chính đóng thì ứng dụng mới thoát
                    }
                    else if (taiKhoan.VaiTro.Equals("KhachHang", StringComparison.OrdinalIgnoreCase))
                    {
                        // Mở form cho khách hàng
                        frmMainKhachHang f_main_kh = new frmMainKhachHang();
                        // Nếu cần truyền thông tin khách hàng sang form chính thì làm ở đây
                        // f_main_kh.ThongTinKhachHang = khachHang; 
                        f_main_kh.ShowDialog();
                    }
                    this.Close(); // Sau khi form chính đóng, đóng luôn form login
                }
                else // Nếu không tìm thấy
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelDangKyNgay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmKhachHangDangKy frm = new frmKhachHangDangKy();
            frm.ShowDialog();
        }
    }
}