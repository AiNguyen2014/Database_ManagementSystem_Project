using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess; // SỬA: Dùng namespace DataAccess
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmTaiKhoan : Form
    {
        // Sử dụng BindingSource để quản lý dữ liệu hiệu quả hơn
        BindingSource source;

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        // SỰ KIỆN KHI FORM ĐƯỢC TẢI LÊN
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTaiKhoanList();
        }

        // HÀM TẢI DỮ LIỆU CHÍNH
        public void LoadTaiKhoanList()
        {
            try
            {
                var taiKhoans = TaiKhoanDAL.Instance.GetAll();
                source = new BindingSource();
                source.DataSource = taiKhoans;

                dgvND.DataSource = null; // Luôn xóa datasource cũ trước
                dgvND.DataSource = source;

                // Tùy chỉnh giao diện cho DataGridView
                if (dgvND.Columns["MatKhau"] != null)
                {
                    dgvND.Columns["MatKhau"].Visible = false; // Luôn ẩn mật khẩu!
                }
                dgvND.Columns["MaTaiKhoan"].HeaderText = "Mã TK";
                dgvND.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
                dgvND.Columns["VaiTro"].HeaderText = "Vai Trò";
                dgvND.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dgvND.Columns["MaKH"].HeaderText = "Mã Khách Hàng";

                // Bật/tắt nút dựa trên việc có dữ liệu hay không
                btnDelete.Enabled = taiKhoans.Any();
                btnUpdate.Enabled = taiKhoans.Any();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải danh sách tài khoản");
            }
        }

        // HÀM LẤY TÀI KHOẢN ĐANG ĐƯỢC CHỌN
        private TaiKhoan GetSelectedTaiKhoan()
        {
            if (dgvND.SelectedRows.Count > 0)
            {
                return dgvND.SelectedRows[0].DataBoundItem as TaiKhoan;
            }
            return null;
        }

        // SỰ KIỆN CÁC NÚT BẤM
        private void btnNew_Click(object sender, EventArgs e)
        {
            // Code mẫu để mở form Thêm mới
            // frmTaiKhoanUpdate frm = new frmTaiKhoanUpdate { InsertOrUpdate = false };
            // if (frm.ShowDialog() == DialogResult.OK)
            // {
            //     LoadTaiKhoanList();
            // }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TaiKhoan selectedTaiKhoan = GetSelectedTaiKhoan();
            if (selectedTaiKhoan != null)
            {
                // Code mẫu để mở form Cập nhật
                // frmTaiKhoanUpdate frm = new frmTaiKhoanUpdate {
                //     InsertOrUpdate = true,
                //     TaiKhoanInfo = selectedTaiKhoan
                // };
                // if (frm.ShowDialog() == DialogResult.OK)
                // {
                //     LoadTaiKhoanList();
                // }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để cập nhật.", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TaiKhoan selectedTaiKhoan = GetSelectedTaiKhoan();
            if (selectedTaiKhoan != null)
            {
                DialogResult d = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    // SỬA: Xóa theo MaTaiKhoan (khóa chính) an toàn hơn
                    TaiKhoanDAL.Instance.Delete(selectedTaiKhoan.MaTaiKhoan);
                    LoadTaiKhoanList(); // Tải lại danh sách
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        // SỰ KIỆN DOUBLE-CLICK TRÊN LƯỚI SẼ MỞ FORM CẬP NHẬT
        private void dgvND_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        // TÌM KIẾM DỮ LIỆU (ĐÃ TỐI ƯU)
        private void txtSearchND_TextChanged(object sender, EventArgs e)
        {
            // Lọc dữ liệu trực tiếp trên BindingSource, không cần gọi lại database
            var searchText = txtSearchND.Text;
            source.Filter = $"TenDangNhap LIKE '%{searchText}%'";
        }
    }
}