using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.Repository;

namespace SaleManagementWinApp
{
    public partial class frmKhachHangUpdate : Form
    {
        public frmKhachHangUpdate()
        {
            InitializeComponent();
        }

        public IKhachHangRepository KhachHangRepository { get; set; }
        public bool InsertOrUpdate { get; set; }// true = update
        public KhachHang KhachHangInfo { get; set; }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var kh = new KhachHang
                {
                    MaKhach = Convert.ToInt32(txtMaKH.Text == "" ? "0" : txtMaKH.Text),
                    TenKhach = txtTenKH.Text,
                    DiaChi = txtDiaChiKH.Text,
                    DienThoai = txtDienThoaiKH.Text,
                };
                if (InsertOrUpdate == false)
                {
                    KhachHangRepository.InsertKhachHang(kh);

                    if (MessageBox.Show("Tạo mới thành công!!", "Thông báo") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmKhachHang)this.Owner).LoadKhachHangList();
                    }
                }
                else
                {
                    KhachHangRepository.UpdateKhachHang(kh);

                    if (MessageBox.Show("Cập nhật thành công!!", "Thông báo") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmKhachHang)this.Owner).LoadKhachHangList();
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

        private void frmKhachHangUpdate_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                txtMaKH.Text = KhachHangInfo.MaKhach.ToString();
                txtTenKH.Text = KhachHangInfo.TenKhach;
                txtDiaChiKH.Text = KhachHangInfo.DiaChi.ToString();
                txtDienThoaiKH.Text = KhachHangInfo.DienThoai.ToString();
            }
        }
    }
}
