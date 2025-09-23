using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class ChiTietPhieuNhap
    {
        public int MaCTPN { get; set; }
        public int MaPN { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien { get; set; }

        // Phương thức tính ThanhTien (nếu cần)
        public void CalculateThanhTien()
        {
            ThanhTien = SoLuong * GiaNhap;
        }
    }
}