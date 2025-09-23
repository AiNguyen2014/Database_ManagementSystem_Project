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
    public partial class frmTaoPhieuNhap : Form
    {
        private PhieuNhapDAL phieuNhapDAL = PhieuNhapDAL.Instance; // Khai báo instance Singleton

        public frmTaoPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmTaoPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhieuNhap(); // Tải danh sách khi form mở
            comboBox2.Items.AddRange(new string[] { "Đã nhập", "Đang xử lý", "Đã hủy" });
            comboBox2.SelectedIndex = 0; // Mặc định "Đang xử lý"
        }

        private void btnTaophieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaNCC.Text, out int maNCC))
                {
                    MessageBox.Show("Mã NCC phải là số hợp lệ!");
                    return;
                }
                if (!int.TryParse(txtMaNV.Text, out int maNV))
                {
                    MessageBox.Show("Mã NV phải là số hợp lệ!");
                    return;
                }
                DateTime ngayNhap = dtpNgayNhap.Value;

                int maPN;
                int result = phieuNhapDAL.TaoMoi(maNCC, maNV, ngayNhap, out maPN); // Sử dụng instance
                txtMaPN.Text = maPN.ToString();
                MessageBox.Show($"Tạo phiếu nhập thành công với MaPN = {maPN}");

                LoadDanhSachPhieuNhap(); // Refresh danh sách
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo phiếu: {ex.Message}");
            }
        }

        private void LoadDanhSachPhieuNhap()
        {
            try
            {
                DataTable dt = phieuNhapDAL.GetAll(); // Lấy dữ liệu từ DAL
                dgvPhieuNhap.DataSource = dt; // Gán dữ liệu vào DataGridView
                                              // Tùy chỉnh cột nếu cần (tùy chọn)
                                              // dgvPhieuNhap.Columns["MaPN"].HeaderText = "Mã PN";
                                              // dgvPhieuNhap.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu nhập: {ex.Message}");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic để cập nhật giao diện khi chọn trạng thái
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }



        private void frmTaoPhieuNhap_Load_1(object sender, EventArgs e)
        {

        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaPN.Text) || !int.TryParse(txtMaPN.Text, out int maPN))
                {
                    MessageBox.Show("Vui lòng chọn phiếu nhập để thêm chi tiết!");
                    return;
                }

                frmChiTietPhieuNhap frm = new frmChiTietPhieuNhap(maPN);
                frm.ShowDialog();

                LoadDanhSachPhieuNhap(); // Refresh danh sách sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form chi tiết: {ex.Message}");
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaPN.Text) || !int.TryParse(txtMaPN.Text, out int maPN))
                {
                    MessageBox.Show("Vui lòng chọn phiếu nhập để kiểm tra!");
                    return;
                }

                frmKiemTraPhieuNhap frm = new frmKiemTraPhieuNhap(maPN);
                frm.ShowDialog();

                LoadDanhSachPhieuNhap(); // Refresh danh sách phiếu sau khi xác nhận
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form kiểm tra: {ex.Message}");
            }
        }

        private void btnXemKhoHang_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang();
                frm.ShowDialog(); // Mở form báo cáo dưới dạng dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form báo cáo: {ex.Message}");
            }
        }
    }
}