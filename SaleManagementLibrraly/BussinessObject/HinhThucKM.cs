using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.BussinessObject
{
    public class HinhThucKM
    {
        public int MaHT { get; set; }
        public string TenHT { get; set; }
        public ICollection<KhuyenMai> KhuyenMais { get; set; }
    }
}
