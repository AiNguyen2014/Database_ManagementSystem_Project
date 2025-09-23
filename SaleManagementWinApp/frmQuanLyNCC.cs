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
    public partial class frmQuanLyNCC : Form
    {
        private NhaCungCapDAL nhaCungCapDAL = NhaCungCapDAL.Instance;
        public frmQuanLyNCC()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhaCungCap();
        }

        private void LoadDanhSachNhaCungCap()
        {
            try
            {
                DataTable dt = nhaCungCapDAL.GetAll();
                dgvNhacungcap.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhà cung cấp: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ///
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaNCC.Text, out int maNCC))
                {
                    MessageBox.Show("Mã NCC phải là số hợp lệ!");
                    return;
                }
                string tenNCC = txtTenNCC.Text;
                string diaChi = txtDiaChi.Text;
                string sdt = txtSoDienThoai.Text;
                string email = txtEmail.Text;

                nhaCungCapDAL.Them(maNCC, tenNCC, diaChi, sdt, email);
                MessageBox.Show("Thêm nhà cung cấp thành công!");
                LoadDanhSachNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaNCC.Text, out int maNCC))
                {
                    MessageBox.Show("Mã NCC phải là số hợp lệ!");
                    return;
                }
                string tenNCC = txtTenNCC.Text;
                string diaChi = txtDiaChi.Text;
                string sdt = txtSoDienThoai.Text;
                string email = txtEmail.Text;

                nhaCungCapDAL.CapNhat(maNCC, tenNCC, diaChi, sdt, email);
                MessageBox.Show("Cập nhật nhà cung cấp thành công!");
                LoadDanhSachNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaNCC.Text, out int maNCC))
                {
                    MessageBox.Show("Mã NCC phải là số hợp lệ!");
                    return;
                }

                nhaCungCapDAL.Xoa(maNCC);
                MessageBox.Show("Xóa nhà cung cấp thành công!");
                LoadDanhSachNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
