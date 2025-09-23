using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleManagementLibrraly.BussinessObject
{
    public class KhuyenMai
    {
        public int MaKM { get; set; }
        public string TenKM { get; set; }
        public int MaHT { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public int? DK_MaSP { get; set; }
        public int? DK_SoLuong { get; set; } 
        public int? UD_MaSP { get; set; } 
        public int? UD_SoLuong { get; set; } 
        public decimal? UD_PhanTramGiam { get; set; } 
        public decimal? UD_GiaTriGiam { get; set; } 
        public string LoaiKhuyenMai { get; set; } 
        public string DieuKien { get; set; }
    }
}