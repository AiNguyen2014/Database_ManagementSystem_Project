using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmLichSuMuaHang : Form
    {
        // Property để nhận tài khoản từ form Main
        public TaiKhoan LoggedInAccount { get; set; }

        public frmLichSuMuaHang()
        {
            InitializeComponent();
        }

        // PHƯƠNG THỨC frmLichSuMuaHang_Load BỊ THIẾU MÀ BẠN CẦN THÊM
        private void frmLichSuMuaHang_Load(object sender, EventArgs e)
        {
            try
            {
                var historyTable = HoaDonDAL.Instance.GetLichSuMuaHang(LoggedInAccount.MaKH.Value);
                dgvLichSu.DataSource = historyTable;

                dgvLichSu.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
                dgvLichSu.Columns["NgayLap"].HeaderText = "Ngày Lập";
                dgvLichSu.Columns["TongTien"].HeaderText = "Tổng Tiền";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử mua hàng: " + ex.Message);
            }
        }

        // PHƯƠNG THỨC btnDong_Click BỊ THIẾU MÀ BẠN CẦN THÊM
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}