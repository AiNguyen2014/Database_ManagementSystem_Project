using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class ChiTietKhuyenMai
    {
        public int MaKM { get; set; }
        public int MaSP { get; set; }
        public decimal GiaTriGiam { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public SanPham SanPham { get; set; }
    }
}
