using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmMainNhanVien : Form
    {
        public TaiKhoan LoggedInAccount { get; set; }
        private NhanVien currentNhanVien;

        public frmMainNhanVien()
        {
            InitializeComponent();
        }

        private void frmMainNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                if (LoggedInAccount != null && LoggedInAccount.MaNV.HasValue)
                {
                    currentNhanVien = NhanVienDAL.Instance.GetNhanVienByID(LoggedInAccount.MaNV.Value);
                    if (currentNhanVien != null)
                    {
                        this.Text = $"Nhân viên: {currentNhanVien.HoTen} ({currentNhanVien.ChucVu})";
                        PhanQuyenTabs(currentNhanVien.ChucVu);
                        TruyenThongTinVaoUserControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message);
            }
        }

        private void PhanQuyenTabs(string chucVu)
        {
            // Tạm thời ẩn các tab mà chỉ quản lý mới thấy
            tabControl1.TabPages.Remove(tabLuong);
            tabControl1.TabPages.Remove(tabBaoCao);

            if (chucVu.Equals("Quản lý", StringComparison.OrdinalIgnoreCase))
            {
                // Nếu là Quản lý, thêm các tab đó trở lại
                tabControl1.TabPages.Add(tabLuong);
                tabControl1.TabPages.Add(tabBaoCao);
            }
        }

        private void TruyenThongTinVaoUserControls()
        {
            // Giả sử tên các UserControl bạn kéo vào Designer là ucNhanVienManager1, ucChamCong1...
            if (tabHoSo.Controls.Count > 0 && tabHoSo.Controls[0] is ucNhanVienManager ucNV)
            {
                ucNV.CurrentNhanVien = this.currentNhanVien;
            }
            if (tabChamCong.Controls.Count > 0 && tabChamCong.Controls[0] is ucChamCong ucCC)
            {
                ucCC.CurrentNhanVien = this.currentNhanVien;
            }
            if (tabControl1.TabPages.Contains(tabLuong) && tabLuong.Controls.Count > 0 && tabLuong.Controls[0] is ucLuong ucL)
            {
                ucL.CurrentNhanVien = this.currentNhanVien;
            }
        }
    }
}