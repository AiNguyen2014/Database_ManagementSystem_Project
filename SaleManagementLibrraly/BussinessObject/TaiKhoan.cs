using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int? MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }
        public int? MaNV { get; set; }
        public int? MaKH { get; set; }
        public VaiTro VaiTro { get; set; }
    }
}