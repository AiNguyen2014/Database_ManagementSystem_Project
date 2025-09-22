using SaleManagementLibrraly.BussinessObject;
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
    public partial class ucNhanVienManager : UserControl
    {

            BindingSource source;
            public NhanVien CurrentNhanVien { get; set; }
            public ucNhanVienManager()
            {
                InitializeComponent();
            }

            private void frmNhanVien_Load(object sender, EventArgs e)
            {
                LoadNhanVienList();
            }

            public void LoadNhanVienList()
            {
                try
                {
                    // SỬA: Gọi từ NhanVienDAL.Instance
                    var nhanViens = NhanVienDAL.Instance.GetAll();

                    source = new BindingSource();
                    source.DataSource = nhanViens;

                    dgvNV.DataSource = null; // Luôn xóa datasource cũ
                    dgvNV.DataSource = source;

                    // Tùy chỉnh hiển thị cột
                    dgvNV.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvNV.Columns["HoTen"].HeaderText = "Họ Tên";
                    dgvNV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvNV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvNV.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    dgvNV.Columns["NgayVaoLam"].HeaderText = "Ngày Vào Làm";
                    dgvNV.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    dgvNV.Columns["CCCD"].HeaderText = "CCCD";

                    // Bật/tắt nút dựa trên việc có dữ liệu hay không
                    if (!nhanViens.Any())
                    {
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        btnUpdate.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi tải danh sách nhân viên");
                }
            }

            private NhanVien GetSelectedNhanVien()
            {
                if (dgvNV.SelectedRows.Count > 0)
                {
                    return dgvNV.SelectedRows[0].DataBoundItem as NhanVien;
                }
                return null;
            }

            private void btnNew_Click(object sender, EventArgs e)
            {
                // SỬA: Gọi form frmNhanVienUpdate
                frmNhanVienUpdate frmNVUpdate = new frmNhanVienUpdate
                {
                    Text = "Thêm mới Nhân Viên",
                    InsertOrUpdate = false // Chế độ Thêm mới
                };

                if (frmNVUpdate.ShowDialog() == DialogResult.OK)
                {
                    LoadNhanVienList();
                    source.Position = source.Count - 1; // Di chuyển đến dòng mới thêm
                }
            }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                NhanVien selectedNhanVien = GetSelectedNhanVien();
                if (selectedNhanVien != null)
                {
                    frmNhanVienUpdate frmNVUpdate = new frmNhanVienUpdate
                    {
                        Text = "Cập nhật Nhân Viên",
                        InsertOrUpdate = true, // Chế độ Cập nhật
                        NhanVienInfo = selectedNhanVien
                    };

                    if (frmNVUpdate.ShowDialog() == DialogResult.OK)
                    {
                        LoadNhanVienList();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để cập nhật.", "Thông báo");
                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                NhanVien selectedNhanVien = GetSelectedNhanVien();
                if (selectedNhanVien != null)
                {
                    var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        NhanVienDAL.Instance.Delete(selectedNhanVien.MaNV);
                        LoadNhanVienList();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo");
                }
            }

            private void txtSearchNV_TextChanged(object sender, EventArgs e)
            {
                // SỬA: Tối ưu tìm kiếm bằng BindingSource.Filter
                var searchText = txtSearchNV.Text;
                source.Filter = $"HoTen LIKE '%{searchText}%' OR SoDienThoai LIKE '%{searchText}%'";
            }

            private void dgvNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                btnUpdate_Click(sender, e);
            }

            private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void lblQLNV_Click(object sender, EventArgs e)
            {

            }
        }
    }