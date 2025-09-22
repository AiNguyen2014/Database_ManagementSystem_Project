using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;
using System;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmNhanVienUpdate : Form
    {
        public bool InsertOrUpdate { get; set; }
        public NhanVien NhanVienInfo { get; set; }

        public frmNhanVienUpdate()
        {
            InitializeComponent();
        }

        private void frmNhanVienUpdate_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true) // Chế độ Cập nhật
            {
                txtMaNV.ReadOnly = true;
                txtMaNV.Text = NhanVienInfo.MaNV.ToString();
                txtTenNV.Text = NhanVienInfo.HoTen;
                dtpNgaySinh.Value = NhanVienInfo.NgaySinh;
                txtDiaChiNV.Text = NhanVienInfo.DiaChi;
                txtDienThoaiNV.Text = NhanVienInfo.SoDienThoai;
                dtpNgayVaoLam.Value = NhanVienInfo.NgayVaoLam;
                txtCCCD.Text = NhanVienInfo.CCCD;
                chkGioiTinh.Checked = NhanVienInfo.GioiTinh.Equals("Nam");
            }
            else // Chế độ Thêm mới
            {
                txtMaNV.ReadOnly = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = new NhanVien
                {
                    HoTen = txtTenNV.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChiNV.Text,
                    SoDienThoai = txtDienThoaiNV.Text,
                    NgayVaoLam = dtpNgayVaoLam.Value,
                    CCCD = txtCCCD.Text,
                    GioiTinh = chkGioiTinh.Checked ? "Nam" : "Nữ"
                };

                if (InsertOrUpdate == false)
                {
                    // MaNV sẽ do database tự tăng, không cần gán ở đây
                    NhanVienDAL.Instance.AddNew(nv);
                    MessageBox.Show("Thêm mới nhân viên thành công!", "Thông báo");
                }
                else
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
                MessageBox.Show(ex.Message, InsertOrUpdate ? "Lỗi cập nhật" : "Lỗi thêm mới");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}