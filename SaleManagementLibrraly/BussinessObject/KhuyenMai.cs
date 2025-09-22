using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class KhuyenMai
    {
        public int MaKM { get; set; }
        public string TenKM { get; set; }
        public int MaHT { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public string DieuKien { get; set; }
        public HinhThucKM HinhThucKM { get; set; }
        public ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
    }
}
