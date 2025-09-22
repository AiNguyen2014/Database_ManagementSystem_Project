using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmKhachHangUpdate : Form
    {
        public bool InsertOrUpdate { get; set; } // true = update
        public KhachHang KhachHangInfo { get; set; }

        public frmKhachHangUpdate()
        {
            InitializeComponent();
        }

        private void frmKhachHangUpdate_Load(object sender, EventArgs e)
        {
            // Nếu là chế độ Cập nhật, đổ dữ liệu của khách hàng vào các ô
            if (InsertOrUpdate == true)
            {
                txtMaKH.ReadOnly = true; // Không cho sửa khóa chính
                txtMaKH.Text = KhachHangInfo.MaKH.ToString();
                txtTenKH.Text = KhachHangInfo.Hoten;
                txtDiaChiKH.Text = KhachHangInfo.DiaChi;
                txtDienThoaiKH.Text = KhachHangInfo.SoDienThoai;
                // Giả sử bạn có ComboBox tên cboGioiTinh
                // cboGioiTinh.SelectedItem = KhachHangInfo.GioiTinh;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào cơ bản
                if (string.IsNullOrWhiteSpace(txtTenKH.Text) || string.IsNullOrWhiteSpace(txtDienThoaiKH.Text))
                {
                    MessageBox.Show("Tên và Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var kh = new KhachHang
                {
                    Hoten = txtTenKH.Text,
                    DiaChi = txtDiaChiKH.Text,
                    SoDienThoai = txtDienThoaiKH.Text,
                    // Giả định giới tính mặc định là "Nam", bạn có thể thêm ComboBox để chọn
                    GioiTinh = "Nam"
                };

                if (InsertOrUpdate == false) // Chế độ Insert
                {
                    KhachHangDAL.Instance.AddNew(kh);
                    MessageBox.Show("Thêm mới khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Chế độ Update
                {
                    kh.MaKH = int.Parse(txtMaKH.Text);
                    KhachHangDAL.Instance.Update(kh);
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate ? "Lỗi cập nhật khách hàng" : "Lỗi thêm mới khách hàng");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}