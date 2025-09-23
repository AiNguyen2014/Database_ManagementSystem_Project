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
        public decimal? ThanhTien { get; set; }
        public string TenSanPham { get; set; }
    }
}
