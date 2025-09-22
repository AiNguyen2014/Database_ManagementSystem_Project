using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmMainKhachHang : Form
    {
        public TaiKhoan LoggedInAccount { get; set; }

        public frmMainKhachHang()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Biến form này thành form cha
        }

        private void frmMainKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị lời chào
                if (LoggedInAccount != null && LoggedInAccount.MaKH.HasValue)
                {
                    // Lấy thông tin chi tiết của khách hàng từ MaKH
                    var khachHang = KhachHangDAL.Instance.GetKhachHangByID(LoggedInAccount.MaKH.Value);
                    if (khachHang != null)
                    {
                        // Giả sử bạn có một ToolStripMenuItem tên là mnuChao
                        mnuChao.Text = "Chào: " + khachHang.Hoten;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin chính: " + ex.Message);
            }
        }

        // TẠO SỰ KIỆN NÀY ĐỂ MỞ FORM THÔNG TIN CÁ NHÂN
        private void mnuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan frm = new frmThongTinCaNhan();
            // Truyền thông tin tài khoản đang đăng nhập sang form con
            frm.LoggedInAccount = this.LoggedInAccount;
            frm.ShowDialog();
        }

        // TẠO SỰ KIỆN NÀY ĐỂ MỞ FORM LỊCH SỬ MUA HÀNG
        private void mnuLichSuMuaHang_Click(object sender, EventArgs e)
        {
            // Chúng ta sẽ làm form này sau
            // frmLichSuMuaHang frm = new frmLichSuMuaHang();
            // frm.LoggedInAccount = this.LoggedInAccount;
            // frm.ShowDialog();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form này, form Login sẽ tự hiện ra
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
