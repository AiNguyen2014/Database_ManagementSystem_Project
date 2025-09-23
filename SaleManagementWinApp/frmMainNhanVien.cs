using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmMainNhanVien : Form
    {

        public TaiKhoan LoggedInAccount { get; set; }
        private NhanVien currentNhanVien;

        // BIẾN MỚI: Dùng để lưu trữ tất cả các tab gốc từ Designer
        private List<TabPage> originalTabPages;

        public frmMainNhanVien()
        {
            InitializeComponent();
        }

        private void frmMainNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                // Lưu lại danh sách các tab gốc trước khi làm bất cứ điều gì
                if (originalTabPages == null)
                {
                    originalTabPages = tabControl1.TabPages.Cast<TabPage>().ToList();
                }

                if (LoggedInAccount != null && LoggedInAccount.MaNV.HasValue)
                {
                    // Chỉ gọi phương thức này khi MaNV có giá trị
                    currentNhanVien = NhanVienDAL.Instance.GetNhanVienByID(LoggedInAccount.MaNV.Value);

                    if (currentNhanVien != null)
                    {
                        this.Text = $"Nhân viên: {currentNhanVien.HoTen} ({LoggedInAccount.TenVaiTro})";
                        PhanQuyenTabs(LoggedInAccount.TenVaiTro);
                        TruyenThongTinVaoUserControls();
                    }
                }
                else
                {
                    // THÊM LOGIC XỬ LÝ KHI TÀI KHOẢN KHÔNG PHẢI NHÂN VIÊN
                    // Ví dụ: ẩn hết các tab hoặc hiển thị một thông báo
                    MessageBox.Show("Tài khoản này không liên kết với một nhân viên.");
                    // Ẩn tất cả các tab nếu tài khoản không phải là nhân viên
                    tabControl1.TabPages.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message);
            }
        }

        // SỬA LẠI HOÀN TOÀN PHƯƠNG THỨC NÀY
        private void PhanQuyenTabs(string tenVaiTro)
        {
            // 1. Xóa sạch tất cả các tab hiện có
            tabControl1.TabPages.Clear();

            // 2. Thêm lại các tab mà vai trò nào cũng được xem
            tabControl1.TabPages.Add(originalTabPages.Find(t => t.Name == "tabHoSo"));
            tabControl1.TabPages.Add(originalTabPages.Find(t => t.Name == "tabChamCong"));
            tabControl1.TabPages.Add(originalTabPages.Find(t => t.Name == "tabCongViec"));

            // 3. Nếu là Quản lý, thêm các tab đặc biệt
            if (tenVaiTro.Equals("Quản lý", StringComparison.OrdinalIgnoreCase))
            {
                tabControl1.TabPages.Add(originalTabPages.Find(t => t.Name == "tabLuong"));
                tabControl1.TabPages.Add(originalTabPages.Find(t => t.Name == "tabBaoCao"));
            }
        }

        // Phương thức này giữ nguyên, không cần sửa
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

        private void btBangHang_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() != typeof(frmBanHang))
                {
                    form.Close();
                }
            }
            frmBanHang frmBH = new frmBanHang();
            frmBH.Show();
        }
    }
}