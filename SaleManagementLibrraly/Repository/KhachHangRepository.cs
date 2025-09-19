using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;

namespace SaleManagementLibrraly.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        public IEnumerable<KhachHang> GetKhachHangs() => KhachHangDBContext.Instance.GetKhachHangList();
        public IEnumerable<KhachHang> GetKhachHangByKeyword(string keyword) => KhachHangDBContext.Instance.GetKhachHangByKeyword(keyword);
        public KhachHang GetKhachHangByID(int MaKhach) => KhachHangDBContext.Instance.GetKhachHangByID(MaKhach);
        public void InsertKhachHang(KhachHang kh) => KhachHangDBContext.Instance.AddNew(kh);
        public void UpdateKhachHang(KhachHang kh) => KhachHangDBContext.Instance.Update(kh);
        public void DeleteKhachHang(int MaKhach) => KhachHangDBContext.Instance.Delete(MaKhach);
    }
}
