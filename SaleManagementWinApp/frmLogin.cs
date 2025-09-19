using SaleManagementLibrraly.App.Code;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.Repository;
/*using static System.Windows.Forms.VisualStyles.VisualStyleElement;*/


namespace SaleManagementWinApp
{
    public partial class frmLogin : Form
    {
        public INguoiDungRepository NguoiDungRepository { get; set; }
        INguoiDungRepository nguoiDungRepository = new NguoiDungRepository();
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
                else
                {
                    errorProvider1?.Clear();
                    // Thực hiện xử lý đăng nhập ở đây
                    var nguoiDung = GetNguoiDungObject();
                    var user = nguoiDungRepository.GetNguoiDungLogin(nguoiDung.TenDangNhap, Common.EncryptMD5(nguoiDung.MatKhau));
                    if (user != null)
                    {
                        this.Visible = false;
                        if (MessageBox.Show("Bạn đã đăng nhập thành công", "Thông tin") == DialogResult.OK)
                        {
                            Common.WriteLog("Login", "btnDangNhap_Click", nguoiDung.TenDangNhap + " đăng nhập hệ thống");
                            if (user.LoaiNguoiDung == 1)
                            {
                                frmMain f_main = new frmMain()
                                {
                                    Text = "Hệ thống Quản trị",
                                };
                                f_main.Show();
                            }
                            else
                            {
                                //Khách hàng
                                if (user.LoaiNguoiDung == 2)
                                {
                                    frmMainKhachHang f_main = new frmMainKhachHang()
                                    {
                                        Text = "Quản trị của Khách hàng",
                                        NguoiDungInfo = user
                                    };
                                    f_main.Show();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã đăng nhập thất bại", "Thông tin");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private NguoiDung GetNguoiDungObject()
        {
            NguoiDung nguoiDung = null;
            try
            {
                nguoiDung = new NguoiDung
                {
                    TenDangNhap = txtDangNhap.Text,
                    MatKhau = txtMatKhau.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get car");
            }
            return nguoiDung;
        }
    }
}
