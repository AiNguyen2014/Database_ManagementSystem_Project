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
    public partial class frmChiTietPhieuNhap : Form
    {
        private PhieuNhapDAL phieuNhapDAL = PhieuNhapDAL.Instance;
        private int maPN;
        public frmChiTietPhieuNhap(int maPN)
        {
            InitializeComponent();
            this.maPN = maPN;
            this.Text = $"Thêm chi tiết cho phiếu nhập MaPN = {maPN}";
            LoadChiTiet();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaSP.Text, out int maSP) || maSP <= 0)
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ!");
                    return;
                }
                if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!");
                    return;
                }
                if (!decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) || giaNhap <= 0)
                {
                    MessageBox.Show("Giá nhập phải lớn hơn 0!");
                    return;
                }

                phieuNhapDAL.ThemChiTiet(maPN, maSP, soLuong, giaNhap);
                MessageBox.Show("Thêm chi tiết thành công!");
                LoadChiTiet(); // Reload danh sách sau khi thêm
                ClearInput(); // Xóa input để thêm tiếp
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm chi tiết: {ex.Message}");
            }
        }

        private void ClearInput()
        {
            txtMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtMaSP.Focus(); // Focus vào txtMaSP để tiếp tục nhập
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
