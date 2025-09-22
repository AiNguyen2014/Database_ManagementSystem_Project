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

                TaiKhoan taiKhoan = TaiKhoanDAL.Instance.CheckLogin(txtDangNhap.Text, txtMatKhau.Text);

                if (taiKhoan != null) // Nếu tìm thấy tài khoản
                {
                    this.Hide();

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (taiKhoan.VaiTro.Equals("NhanVien", StringComparison.OrdinalIgnoreCase))
                    {
                        frmMainNhanVien f_main_nv = new frmMainNhanVien
                        {
                            LoggedInAccount = taiKhoan // Truyền thông tin tài khoản qua
                        };
                        f_main_nv.ShowDialog();
                    }

                    else if (taiKhoan.VaiTro.Equals("KhachHang", StringComparison.OrdinalIgnoreCase))
                    {
                        frmMainKhachHang f_main_kh = new frmMainKhachHang
                        {
                            LoggedInAccount = taiKhoan
                        };
                        f_main_kh.ShowDialog();
                    }
                    this.Close();
                }
                else
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}