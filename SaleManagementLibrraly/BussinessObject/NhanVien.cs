using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; } // Dùng string vì trong DB là nvarchar('Nam', 'Nữ')
        public DateTime NgayVaoLam { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string CCCD { get; set; }
    }
}
