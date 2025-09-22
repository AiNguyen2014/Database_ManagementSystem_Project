using SaleManagementLibrraly.BussinessObject;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class ucLuong : UserControl
    {
        public NhanVien CurrentNhanVien { get; set; }

        public ucLuong()
        {
            InitializeComponent();
        }

        private void ucLuong_Load(object sender, EventArgs e)
        {
            // Load các tháng và năm vào ComboBox
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            // Load 12 tháng
            cBoxThang.DataSource = Enumerable.Range(1, 12).ToList();
            // Load 5 năm gần nhất
            cBoxNam.DataSource = Enumerable.Range(DateTime.Now.Year - 4, 5).Reverse().ToList();

            // Mặc định chọn tháng và năm hiện tại
            cBoxThang.SelectedItem = DateTime.Now.Month;
            cBoxNam.SelectedItem = DateTime.Now.Year;
        }

        private void btnXemLuong_Click(object sender, EventArgs e)
        {
            // TODO: Viết code lấy dữ liệu lương theo tháng/năm đã chọn và hiển thị trên dgvLuong
            int thang = (int)cBoxThang.SelectedItem;
            int nam = (int)cBoxNam.SelectedItem;
            MessageBox.Show($"Xem lương tháng {thang}/{nam} cho NV {CurrentNhanVien?.MaNV}");
        }
    }
}