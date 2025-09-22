using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmThongTinCaNhan : Form
    {
        // Property để nhận thông tin tài khoản từ form Main
        public TaiKhoan LoggedInAccount { get; set; }
        private KhachHang currentKhachHang;

        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            // Khi form được tải, lấy thông tin khách hàng và hiển thị
            LoadKhachHangInfo();
        }

        private void LoadKhachHangInfo()
        {
            try
            {
                // Dùng MaKH từ tài khoản đăng nhập để lấy thông tin khách hàng tương ứng
                if (LoggedInAccount != null && LoggedInAccount.MaKH.HasValue)
                {
                    currentKhachHang = KhachHangDAL.Instance.GetKhachHangByID(LoggedInAccount.MaKH.Value);
                    if (currentKhachHang != null)
                    {
                        // Đổ dữ liệu vào các ô textbox
                        txtHoTen.Text = currentKhachHang.Hoten;
                        txtDiaChi.Text = currentKhachHang.DiaChi;
                        txtSoDienThoai.Text = currentKhachHang.SoDienThoai;
                    }
                }
                else
                {
                    MessageBox.Show("Không có thông tin tài khoản để hiển thị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin cá nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentKhachHang == null) return;

                // Lấy dữ liệu mới từ các textbox
                var updatedKhachHang = new KhachHang
                {
                    MaKH = currentKhachHang.MaKH, // Giữ lại MaKH cũ
                    Hoten = txtHoTen.Text,
                    DiaChi = txtDiaChi.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    GioiTinh = currentKhachHang.GioiTinh // Giả định không thay đổi giới tính ở form này
                };

                // Gọi hàm DAL để gọi Stored Procedure
                KhachHangDAL.Instance.UpdateThongTin(updatedKhachHang);

                // ĐỔI MẬT KHẨU (NẾU NGƯỜI DÙNG NHẬP VÀO)
                if (!string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
                {
                    // Bắt buộc phải nhập mật khẩu cũ để xác thực
                    if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu cũ để xác nhận thay đổi.", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Dùng lại hàm CheckLogin để kiểm tra mật khẩu cũ có đúng không
                    TaiKhoan tk = TaiKhoanDAL.Instance.CheckLogin(LoggedInAccount.TenDangNhap, txtMatKhauCu.Text);
                    if (tk == null)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra mật khẩu mới và xác nhận phải khớp nhau
                    if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
                    {
                        MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Nếu mọi thứ hợp lệ, tiến hành đổi mật khẩu
                    TaiKhoanDAL.Instance.ChangePassword(LoggedInAccount.TenDangNhap, txtMatKhauMoi.Text);
                }

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thay đổi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}