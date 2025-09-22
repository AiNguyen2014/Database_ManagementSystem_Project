using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmThongTinCaNhan : Form
    {
        public TaiKhoan LoggedInAccount { get; set; }
        private KhachHang currentKhachHang;

        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadKhachHangInfo();
        }

        private void LoadKhachHangInfo()
        {
            try
            {
                if (LoggedInAccount != null && LoggedInAccount.MaKH.HasValue)
                {
                    currentKhachHang = KhachHangDAL.Instance.GetKhachHangByID(LoggedInAccount.MaKH.Value);
                    if (currentKhachHang != null)
                    {
                        txtHoTen.Text = currentKhachHang.Hoten;
                        txtDiaChi.Text = currentKhachHang.DiaChi;
                        txtSoDienThoai.Text = currentKhachHang.SoDienThoai;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin cá nhân: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentKhachHang == null) return;

                // Cập nhật thông tin Khách hàng
                currentKhachHang.Hoten = txtHoTen.Text;
                currentKhachHang.DiaChi = txtDiaChi.Text;
                currentKhachHang.SoDienThoai = txtSoDienThoai.Text;
                KhachHangDAL.Instance.Update(currentKhachHang);

                // Đổi mật khẩu nếu người dùng nhập vào
                if (!string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu cũ để xác nhận.", "Yêu cầu");
                        return;
                    }

                    // SỬA LẠI: Gọi CheckLogin với đủ 3 tham số
                    TaiKhoan tk = TaiKhoanDAL.Instance.CheckLogin(
                        LoggedInAccount.TenDangNhap,
                        txtMatKhauCu.Text,
                        (int)LoggedInAccount.MaVaiTro); // Thêm MaVaiTro vào

                    if (tk == null)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi");
                        return;
                    }

                    if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
                    {
                        MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Lỗi");
                        return;
                    }

                    TaiKhoanDAL.Instance.ChangePassword(LoggedInAccount.TenDangNhap, txtMatKhauMoi.Text);
                }

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thay đổi: " + ex.Message);
            }
        }

private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}