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
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách vai trò từ database và hiển thị lên ComboBox
                var vaiTroList = VaiTroDAL.Instance.GetAll();
                cboVaiTro.DataSource = vaiTroList;
                cboVaiTro.DisplayMember = "TenVaiTro";
                cboVaiTro.ValueMember = "MaVaiTro";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (cboVaiTro.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                errorProvider1?.Clear();

                // Lấy thông tin từ giao diện
                string tenDangNhap = txtDangNhap.Text;
                string matKhau = txtMatKhau.Text;
                int maVaiTro = (int)cboVaiTro.SelectedValue;

                // Chỉ gọi CheckLogin một lần duy nhất với đủ 3 tham số
                TaiKhoan taiKhoan = TaiKhoanDAL.Instance.CheckLogin(tenDangNhap, matKhau, maVaiTro);

                if (taiKhoan != null)
                {
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kiểm tra vai trò dựa trên TenVaiTro lấy từ DB
                    if (taiKhoan.TenVaiTro.Trim().Equals("Khách hàng", StringComparison.OrdinalIgnoreCase))
                    {
                        // Nếu đúng là Khách hàng -> Mở form Khách hàng
                        frmMainKhachHang f_main_kh = new frmMainKhachHang
                        {
                            LoggedInAccount = taiKhoan
                        };
                        f_main_kh.ShowDialog();
                    }
                    else
                    {
                        // Nếu là bất kỳ vai trò nào khác (Quản lý, NV Bán hàng, NV Kho) -> Mở form Nhân viên
                        frmMainNhanVien f_main_nv = new frmMainNhanVien
                        {
                            LoggedInAccount = taiKhoan
                        };
                        f_main_nv.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập, mật khẩu hoặc vai trò không chính xác.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
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