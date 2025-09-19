using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManagementLibrraly.BussinessObject;

namespace SaleManagementLibrraly.Repository
{
    public interface IKhachHangRepository
    {
        IEnumerable<KhachHang> GetKhachHangs();
        IEnumerable<KhachHang> GetKhachHangByKeyword(string keyword);
        KhachHang GetKhachHangByID(int MaKhach);
        void InsertKhachHang(KhachHang kh);
        void UpdateKhachHang(KhachHang kh);
        void DeleteKhachHang(int MaKhach);
    }
}
