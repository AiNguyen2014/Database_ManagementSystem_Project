using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class TaiKhoan
    {
        // MaTaiKhoan INT PRIMARY KEY
        public int MaTaiKhoan { get; set; }

        // TenDangNhap NVARCHAR(50)
        public string TenDangNhap { get; set; }

        // MatKhau VARCHAR(50)
        public string MatKhau { get; set; }

        // VaiTro NVARCHAR(50)
        public string VaiTro { get; set; }

        // MaNV INT (có thể là NULL)
        // Dùng "int?" để cho phép giá trị null trong trường hợp tài khoản là của khách hàng
        public int? MaNV { get; set; }

        // MaKH INT (có thể là NULL)
        // Dùng "int?" để cho phép giá trị null trong trường hợp tài khoản là của nhân viên
        public int? MaKH { get; set; }
    }
}
