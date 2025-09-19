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
    public partial class frmHangHoaUpdate : Form
    {
        public IHangHoaRepository HangHoaRepository { get; set; }
        public bool InsertOrUpdate { get; set; }//True Update
        public HangHoa HangHoaInfo { get; set; }
        public string pathName;
        private OpenFileDialog openFileDialog;
        public frmHangHoaUpdate()
        {
            InitializeComponent();
            // Khởi tạo đối tượng OpenFileDialog
            openFileDialog = new OpenFileDialog();

            // Cấu hình các thuộc tính của OpenFileDialog
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
            openFileDialog.Multiselect = false;
        }

        private void frmHangHoaUpdate_Load(object sender, EventArgs e)
        {
            //If Update is true then fill data into form
            if (InsertOrUpdate == true)
            {
                txtMaHH.Text = HangHoaInfo.MaHangHoa.ToString();
                txtTenHH.Text = HangHoaInfo.TenHangHoa.ToString();
                txtSoLuong.Text = HangHoaInfo.SoLuong.ToString();
                txtDGNhap.Text = HangHoaInfo.DonGiaNhap.ToString();
                txtDGBan.Text = HangHoaInfo.DonGiaBan.ToString();
                picAvatar.Image = Image.FromFile(Application.StartupPath + "/Avatar/" + HangHoaInfo.Anh);
                pathName = Path.GetFileName(Application.StartupPath + "/Avatar/" + HangHoaInfo.Anh);
                txtGhiChu.Text = HangHoaInfo.GhiChu.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var hh = new HangHoa
                {
                    MaHangHoa = Convert.ToInt32(txtMaHH.Text == "" ? 0 : txtMaHH.Text),
                    TenHangHoa = txtTenHH.Text,
                    SoLuong = Convert.ToInt32(txtSoLuong.Text),
                    DonGiaNhap = Convert.ToDecimal(txtDGNhap.Text),
                    DonGiaBan = Convert.ToDecimal(txtDGBan.Text),
                    Anh = pathName,
                    GhiChu = txtGhiChu.Text
                };
                if (InsertOrUpdate == false)
                {
                    HangHoaRepository.InsertHangHoa(hh);

                    if (MessageBox.Show("Bạn đã tạo mới thành công!", "Thông tin") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmHangHoa)this.Owner).LoadHangHoaList();
                    }
                }
                else
                {
                    HangHoaRepository.UpdateHangHoa(hh);
                    if (MessageBox.Show("Bạn đã cập nhật thành công!", "Thông tin") == DialogResult.OK)
                    {
                        this.Visible = false;
                        ((frmHangHoa)this.Owner).LoadHangHoaList();
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tệp ảnh đã chọn
                string imagePath = openFileDialog.FileName;

                // Hiển thị ảnh lên PictureBox
                picAvatar.Image = Image.FromFile(imagePath);
                // Lấy đường dẫn thư mục để lưu tệp ảnh
                string directoryPath = Application.StartupPath + "/Avatar";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                pathName = Path.GetFileName(imagePath);
                File.Copy(openFileDialog.FileName, Path.Combine(directoryPath, Path.GetFileName(openFileDialog.FileName)));

            }
        }
    }
}
