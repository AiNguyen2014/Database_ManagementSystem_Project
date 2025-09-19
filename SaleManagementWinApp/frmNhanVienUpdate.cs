using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.Repository;

namespace SaleManagementWinApp
{
    public partial class frmNhanVienUpdate : Form
    {
        public INhanVienRepository NhanVienRepository { get; set; }
        public bool InsertOrUpdate { get; set; }// true = update
        public NhanVien NhanVienInfo { get; set; }
        public frmNhanVienUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = new NhanVien
                {
                    MaNhanVien = Convert.ToInt32(txtMaNV.Text == "" ? 0 : txtMaNV.Text),
                    TenNhanVien = txtTenNV.Text,
                    DiaChi = txtDiaChiNV.Text,
                    DienThoai = txtDienThoaiNV.Text,
                    GioiTinh = chkGioiTinh.Checked,
                    NgaySinh = DateTime.ParseExact(txtNgaySinhNV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                };
                if (InsertOrUpdate == false)
                {
                    NhanVienRepository.InsertNhanVien(nv);

                    if (MessageBox.Show("Bạn đã tạo mới thành công!", "Thông tin") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmNhanVien)this.Owner).LoadNhanVienList();
                    }
                }
                else
                {
                    NhanVienRepository.UpdateNhanVien(nv);
                    if (MessageBox.Show("Bạn đã cập nhật thành công!", "Thông tin") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmNhanVien)this.Owner).LoadNhanVienList();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVienUpdate_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                txtMaNV.Text = NhanVienInfo.MaNhanVien.ToString();
                txtTenNV.Text = NhanVienInfo.TenNhanVien;
                chkGioiTinh.Checked = NhanVienInfo.GioiTinh;
                txtDiaChiNV.Text = NhanVienInfo.DiaChi.ToString();
                txtDienThoaiNV.Text = NhanVienInfo.DienThoai.ToString();
                txtNgaySinhNV.Text = NhanVienInfo.NgaySinh.ToString("dd/MM/yyyy");
            }
        }
    }
}
