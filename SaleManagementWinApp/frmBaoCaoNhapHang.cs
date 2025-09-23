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
    public partial class frmBaoCaoNhapHang : Form
    {
        private BaoCaoNhapHangDAL baoCaoDAL = BaoCaoNhapHangDAL.Instance;
        public frmBaoCaoNhapHang()
        {
            InitializeComponent();
        }

        private void frmBaoCaoNhapHang_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.Value = DateTime.Now.AddMonths(-1); // Mặc định tháng trước
            dtpNgayKetThuc.Value = DateTime.Now;
            comboBox1.Items.AddRange(new string[] { "Ngày", "Tuần", "Tháng", "Quý", "Năm" });
            comboBox1.SelectedIndex = 0;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayBatDau = dtpNgayBatDau.Value;
                DateTime ngayKetThuc = dtpNgayKetThuc.Value;
                string loaiThoiGian = comboBox1.SelectedItem.ToString();

                // 1. Thống kê số lượng sản phẩm nhập
                DataTable dtSoLuong = baoCaoDAL.ThongKeSoLuongNhap(ngayBatDau, ngayKetThuc, loaiThoiGian);
                dgvSoLuong.DataSource = dtSoLuong;

                // 2. Thống kê tổng chi phí
                decimal tongChiPhi = baoCaoDAL.ThongKeTongChiPhiNhap(ngayBatDau, ngayKetThuc);
                lblTongChiPhi.Text = tongChiPhi.ToString("N0") + " VNĐ";

                // 3. Sản phẩm nhập nhiều nhất
                DataTable dtSanPham = baoCaoDAL.SanPhamNhapNhieuNhat(ngayBatDau, ngayKetThuc);
                dgvSanPhamNhap.DataSource = dtSanPham;

                // 4. Nhà cung cấp cung cấp nhiều nhất
                DataTable dtNhaCungCap = baoCaoDAL.NhaCungCapNhieuNhat(ngayBatDau, ngayKetThuc);
                dgvNhaCungCap.DataSource = dtNhaCungCap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message);
            }
        }
    }
}
