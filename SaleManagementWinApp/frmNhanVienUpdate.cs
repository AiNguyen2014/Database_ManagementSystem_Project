using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmNhanVienUpdate : Form
    {
        public bool InsertOrUpdate { get; set; } // true = update
        public NhanVien NhanVienInfo { get; set; }

        public frmNhanVienUpdate()
        {
            InitializeComponent();
        }

        private void frmNhanVienUpdate_Load(object sender, EventArgs e)
        {
            cboChucVu.SelectedIndex = 0; // Mặc định chọn chức vụ đầu tiên

            // Nếu là chế độ Cập nhật, đổ dữ liệu của nhân viên vào các ô
            if (InsertOrUpdate == true)
            {
                txtMaNV.Text = NhanVienInfo.MaNV.ToString();
                txtTenNV.Text = NhanVienInfo.HoTen;
                dtpNgaySinh.Value = NhanVienInfo.NgaySinh;
                txtDiaChiNV.Text = NhanVienInfo.DiaChi;
                txtDienThoaiNV.Text = NhanVienInfo.SoDienThoai;
                dtpNgayVaoLam.Value = NhanVienInfo.NgayVaoLam;
                txtCCCD.Text = NhanVienInfo.CCCD;
                cboChucVu.SelectedItem = NhanVienInfo.ChucVu;
                chkGioiTinh.Checked = NhanVienInfo.GioiTinh.Equals("Nam");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Thêm kiểm tra dữ liệu đầu vào chi tiết hơn

                var nv = new NhanVien
                {
                    HoTen = txtTenNV.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChiNV.Text,
                    SoDienThoai = txtDienThoaiNV.Text,
                    NgayVaoLam = dtpNgayVaoLam.Value,
                    CCCD = txtCCCD.Text,
                    ChucVu = cboChucVu.SelectedItem.ToString(),
                    GioiTinh = chkGioiTinh.Checked ? "Nam" : "Nữ"
                };

                if (InsertOrUpdate == false) // Chế độ Insert
                {
                    NhanVienDAL.Instance.AddNew(nv);
                    MessageBox.Show("Thêm mới nhân viên thành công!", "Thông báo");
                }
                else // Chế độ Update
                {
                    nv.MaNV = int.Parse(txtMaNV.Text);
                    NhanVienDAL.Instance.Update(nv);
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate ? "Lỗi cập nhật nhân viên" : "Lỗi thêm mới nhân viên");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}