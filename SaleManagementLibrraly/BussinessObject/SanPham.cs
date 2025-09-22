using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public DateTime? HanSuDung { get; set; } // Dùng DateTime? vì có thể NULL
        public int? SoLuongTon { get; set; }
        public int? MaLoaiSP { get; set; }
        public string TrangThai { get; set; }
        public decimal? DonGia { get; set; }
    }
}
