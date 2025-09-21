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

        // Thuộc tính này tự tính toán giống như trong database
        public decimal? ThanhTien => SoLuong * DonGia;

        public decimal? ThanhTienSauGiam { get; set; }
    }
}
