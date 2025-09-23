using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Text = "Đăng Nhập";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TaiKhoan taiKhoan = TaiKhoanDAL.Instance.CheckLogin(txtDangNhap.Text, txtMatKhau.Text);

                if (taiKhoan != null) // Nếu tìm thấy tài khoản
                {
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hệ thống tự động kiểm tra vai trò từ đối tượng taiKhoan trả về
                    string tenVaiTro = taiKhoan.VaiTro.TenVaiTro;

                    if (tenVaiTro.Equals("Khách hàng", StringComparison.OrdinalIgnoreCase))
                    {
                        frmMainKhachHang f_main_kh = new frmMainKhachHang { LoggedInAccount = taiKhoan };
                        f_main_kh.ShowDialog();
                    }
                    else // Các vai trò còn lại là của nhân viên/quản lý
                    {
                        frmMainNhanVien f_main_nv = new frmMainNhanVien { LoggedInAccount = taiKhoan };
                        f_main_nv.ShowDialog();
                    }
                    this.Close();
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