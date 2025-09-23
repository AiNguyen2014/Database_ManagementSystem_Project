namespace SaleManagementLibrraly.BussinessObject
{
    public class SanPhamKhuyenMai
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaSauGiam { get; set; }
        public decimal GiaTriGiam { get; set; }
        public string TenKhuyenMai { get; set; } // Thuộc tính mới
        public string MoTaKhuyenMaiDacBiet { get; set; } // Thuộc tính mới
    }
}