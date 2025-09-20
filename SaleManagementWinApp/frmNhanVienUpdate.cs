using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess; // SỬA: Dùng DataAccess
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmNhanVienUpdate : Form
    {
        // KHÔNG CẦN Repository nữa
        // public INhanVienRepository NhanVienRepository { get; set; }
        public bool InsertOrUpdate { get; set; } // true = update, false = insert
        public NhanVien NhanVienInfo { get; set; }

        public frmNhanVienUpdate()
        {
            InitializeComponent();
        }

        private void frmNhanVienUpdate_Load(object sender, EventArgs e)
        {
            // Nếu là chế độ Cập nhật, đổ dữ liệu của nhân viên vào các ô
            if (InsertOrUpdate == true)
            {
                txtMaNV.Text = NhanVienInfo.MaNV.ToString();
                // SỬA: Dùng đúng tên thuộc tính mới
                txtTenNV.Text = NhanVienInfo.HoTen;
                // SỬA: Chuyển đổi từ string "Nam"/"Nữ" sang boolean của CheckBox
                chkGioiTinh.Checked = NhanVienInfo.GioiTinh.Equals("Nam");
                txtDiaChiNV.Text = NhanVienInfo.DiaChi;
                txtDienThoaiNV.Text = NhanVienInfo.SoDienThoai;
                dtpNgaySinh.Value = NhanVienInfo.NgaySinh;
                dtpNgayVaoLam.Value = NhanVienInfo.NgayVaoLam;
                txtCCCD.Text = NhanVienInfo.CCCD;
                cboChucVu.SelectedItem = NhanVienInfo.ChucVu;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) // Nút này có thể đổi tên thành btnSave
        {
            try
            {
                // TODO: Thêm kiểm tra dữ liệu đầu vào (không được để trống...)

                var nv = new NhanVien
                {
                    // SỬA: Dùng đúng tên thuộc tính từ Model mới
                    HoTen = txtTenNV.Text,
                    DiaChi = txtDiaChiNV.Text,
                    SoDienThoai = txtDienThoaiNV.Text,
                    // SỬA: Chuyển từ CheckBox (boolean) sang string "Nam"/"Nữ"
                    GioiTinh = chkGioiTinh.Checked ? "Nam" : "Nữ",
                    NgaySinh = dtpNgaySinh.Value,
                    NgayVaoLam = dtpNgayVaoLam.Value,
                    CCCD = txtCCCD.Text,
                    ChucVu = cboChucVu.SelectedItem.ToString()
                };

                if (InsertOrUpdate == false) // Chế độ Insert
                {
                    NhanVienDAL.Instance.AddNew(nv);
                    MessageBox.Show("Thêm mới nhân viên thành công!", "Thông báo");
                }
                else // Chế độ Update
                {
                    nv.MaNV = int.Parse(txtMaNV.Text); // Lấy MaNV để biết update dòng nào
                    NhanVienDAL.Instance.Update(nv);
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo");
                }

                // SỬA: Giao tiếp với form cha một cách mềm dẻo hơn
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