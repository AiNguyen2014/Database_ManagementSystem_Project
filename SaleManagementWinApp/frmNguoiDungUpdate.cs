using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaleManagementLibrraly.App.Code;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.Repository;

namespace SaleManagementWinApp
{
    public partial class frmNguoiDungUpdate : Form
    {
        public INguoiDungRepository NguoiDungRepository { get; set; }
        public bool InsertOrUpdate { get; set; }//True Update
        public NguoiDung NguoiDungInfo { get; set; }

        List<LoaiNguoiDung> loaiNguoiDung;
        public frmNguoiDungUpdate()
        {
            InitializeComponent();

            loaiNguoiDung = new List<LoaiNguoiDung>()
            {
                new LoaiNguoiDung(){Id= 1 ,Name = "Quản trị"},
                new LoaiNguoiDung(){Id= 2 ,Name = "Khách hàng"},
                new LoaiNguoiDung(){Id= 3 ,Name = "Nhân viên"}
            };
            cboLoaiNguoiDung.DataSource = loaiNguoiDung;
            cboLoaiNguoiDung.DisplayMember = "Name";
            cboLoaiNguoiDung.ValueMember = "Id";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var kh = new NguoiDung
                {
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = string.IsNullOrEmpty(txtMatKhau.Text) ? NguoiDungInfo.MatKhau : Common.EncryptMD5(txtMatKhau.Text),
                    LoaiNguoiDung = Convert.ToInt32(cboLoaiNguoiDung.SelectedValue),
                    MaNguoiDung = Convert.ToInt32(txtMaNguoiDung.Text)
                };
                if (InsertOrUpdate == false)
                {
                    NguoiDungRepository.InsertNguoiDung(kh);

                    if (MessageBox.Show("Bạn đã tạo mới thành công!", "Thông tin") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmNguoiDung)this.Owner).LoadNguoiDungList();
                    }
                }
                else
                {
                    NguoiDungRepository.UpdateNguoiDung(kh);
                    if (MessageBox.Show("Bạn đã cập nhật thành công!", "Thông tin") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmNguoiDung)this.Owner).LoadNguoiDungList();
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

        private void frmNguoiDungUpdate_Load(object sender, EventArgs e)
        {
            //If Update is true then fill data into form
            if (InsertOrUpdate == true)
            {
                txtTenDangNhap.Text = NguoiDungInfo.TenDangNhap.ToString();
                //txtMatKhau.Text = NguoiDungInfo.MatKhau.ToString();
                txtMaNguoiDung.Text = NguoiDungInfo.MaNguoiDung.ToString();
                cboLoaiNguoiDung.SelectedValue = NguoiDungInfo.LoaiNguoiDung;
            }
        }
    }
}
