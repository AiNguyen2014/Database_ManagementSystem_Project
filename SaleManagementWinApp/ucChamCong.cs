using SaleManagementLibrraly.BussinessObject;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class ucChamCong : UserControl
    {
        public NhanVien CurrentNhanVien { get; set; }

        public ucChamCong()
        {
            InitializeComponent();
        }

        private void ucChamCong_Load(object sender, EventArgs e)
        {
            // Khi load, hiển thị lịch sử chấm công của ngày hôm nay
            LoadLichSuChamCong(DateTime.Today);
        }

        private void LoadLichSuChamCong(DateTime ngay)
        {
            // TODO: Viết code để lấy dữ liệu chấm công từ DB và đổ vào dgvChamCong
            // Ví dụ: dgvChamCong.DataSource = ChamCongDAL.Instance.GetByNVAndDate(CurrentNhanVien.MaNV, ngay);
            MessageBox.Show($"Đang tải lịch sử chấm công ngày {ngay.ToShortDateString()} cho NV {CurrentNhanVien?.MaNV}");
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            // TODO: Viết code gọi SP_ChamCong để check-in
            MessageBox.Show("Đã nhấn Check-in!");
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            // TODO: Viết code gọi SP_ChamCong để check-out
            MessageBox.Show("Đã nhấn Check-out!");
        }
    }
}