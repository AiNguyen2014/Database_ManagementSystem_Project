using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmSanPhamUpdate : Form
    {
        public bool InsertOrUpdate { get; set; } // true = update
        public SanPham SanPhamInfo { get; set; }

        public frmSanPhamUpdate()
        {
            InitializeComponent();
        }

        private void frmSanPhamUpdate_Load(object sender, EventArgs e)
        {
            // Mặc định chọn trạng thái đầu tiên
            cboTrangThai.SelectedIndex = 0;

            // Nếu là chế độ Cập nhật, đổ dữ liệu của sản phẩm vào các ô
            if (InsertOrUpdate == true)
            {
                // Vô hiệu hóa ô Mã SP vì không cho sửa khóa chính
                txtMaSP.ReadOnly = true;

                txtMaSP.Text = SanPhamInfo.MaSP.ToString();
                txtTenSP.Text = SanPhamInfo.TenSP;
                txtGiaNhap.Text = SanPhamInfo.GiaNhap.ToString();
                txtGiaBan.Text = SanPhamInfo.DonGia.ToString();
                numSoLuongTon.Value = SanPhamInfo.SoLuongTon ?? 0;
                txtDonViTinh.Text = SanPhamInfo.DonViTinh;

                if (SanPhamInfo.HanSuDung.HasValue)
                {
                    dtpHanSuDung.Value = SanPhamInfo.HanSuDung.Value;
                }

                if (!string.IsNullOrEmpty(SanPhamInfo.TrangThai))
                {
                    cboTrangThai.SelectedItem = SanPhamInfo.TrangThai;
                }
            }
        }

        // HÀM MÀ DESIGNER ĐANG TÌM NẰM Ở ĐÂY
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Thêm kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Mã và Tên sản phẩm không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var sp = new SanPham
                {
                    MaSP = int.Parse(txtMaSP.Text),
                    TenSP = txtTenSP.Text,
                    GiaNhap = decimal.Parse(txtGiaNhap.Text),
                    DonGia = decimal.Parse(txtGiaBan.Text),
                    SoLuongTon = (int)numSoLuongTon.Value,
                    DonViTinh = txtDonViTinh.Text,
                    HanSuDung = dtpHanSuDung.Value,
                    TrangThai = cboTrangThai.SelectedItem.ToString()
                };

                if (InsertOrUpdate == false) // Chế độ Insert
                {
                    SanPhamDAL.Instance.AddNew(sp);
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo");
                }
                else // Chế độ Update
                {
                    SanPhamDAL.Instance.Update(sp);
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate ? "Lỗi cập nhật sản phẩm" : "Lỗi thêm mới sản phẩm");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}