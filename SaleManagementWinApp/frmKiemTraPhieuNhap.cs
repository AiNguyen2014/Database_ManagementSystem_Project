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
    public partial class frmKiemTraPhieuNhap : Form
    {
        private PhieuNhapDAL phieuNhapDAL = PhieuNhapDAL.Instance;
        private int maPN;

        public frmKiemTraPhieuNhap(int maPN)
        {
            InitializeComponent();
            this.maPN = maPN;
            this.Text = $"Kiểm tra phiếu nhập MaPN = {maPN}";
            LoadChiTiet();
            comboBox1.Items.AddRange(new string[] { "Đang xử lý", "Đã nhập", "Đã hủy" });
            comboBox1.SelectedIndex = 0; // Mặc định là Đang xử lý
        }

        private void LoadChiTiet()
        {
            try
            {
                DataTable dt = phieuNhapDAL.GetChiTietByMaPN(maPN);
                dgvChiTiet.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết: {ex.Message}");
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string trangThai = comboBox1.Text;
                string ghiChu = txtGhiChu.Text;

                // Kiểm tra hạn sử dụng từ SanPham khi chuyển sang Đã nhập
                DataTable dtChiTiet = phieuNhapDAL.GetChiTietByMaPN(maPN);
                if (trangThai == "Đã nhập")
                {
                    foreach (DataRow row in dtChiTiet.Rows)
                    {
                        int maSP = Convert.ToInt32(row["MaSP"]);
                        DateTime hanSuDung = Convert.ToDateTime(row["HanSuDung"]);
                        if ((hanSuDung - DateTime.Today).TotalDays < 30)
                        {
                            if (MessageBox.Show("Có sản phẩm có hạn sử dụng dưới 30 ngày. Bạn có muốn tiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                            ghiChu += (string.IsNullOrEmpty(ghiChu) ? "" : "\n") + $"Sản phẩm MaSP={maSP} hạn sử dụng dưới 30 ngày ({hanSuDung:dd/MM/yyyy}).";
                        }
                    }
                }

                phieuNhapDAL.XacNhan(maPN, trangThai, ghiChu);
                if (trangThai == "Đã nhập")
                {
                    phieuNhapDAL.CapNhatTonKho(maPN); // Cập nhật SoLuongTon trong SanPham
                }
                MessageBox.Show("Xác nhận phiếu nhập thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận: {ex.Message}");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
