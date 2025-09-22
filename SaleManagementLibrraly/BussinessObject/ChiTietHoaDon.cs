using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class ChiTietHoaDon
    {
        public int MaCTHD { get; set; }
        public int? MaHD { get; set; }
        public int? MaSP { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }

        public decimal? ThanhTien{ get; set; }

        public decimal? ThanhTienSauGiam { get; set; }
        public DateTime? NgayLap { get; set; }
        public string TenKH { get; set; }
        public string TenNV { get; set; }
        public string TenSanPham { get; set; }
        public decimal? GiamGia { get; set; }
        public decimal? TongTien { get; set; }
    }
}