using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;

namespace SaleManagementLibrraly.Repository
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        public NguoiDung GetNguoiDungLogin(string TenDangNhap, string MatKhau) => NguoiDungDBContext.Instance.GetInfo(TenDangNhap, MatKhau);
        public IEnumerable<NguoiDung> GetNguoiDungs() => NguoiDungDBContext.Instance.GetNguoiDungList();
        public IEnumerable<NguoiDung> GetNguoiDungByKeyword(string keyword) => NguoiDungDBContext.Instance.GetNguoiDungByKeyword(keyword);
        public NguoiDung GetNguoiDungByTenDangNhap(string tenDangNhap) => NguoiDungDBContext.Instance.GetNguoiDungByTenDangNhap(tenDangNhap);
        public void InsertNguoiDung(NguoiDung nguoiDung) => NguoiDungDBContext.Instance.AddNew(nguoiDung);
        public void UpdateNguoiDung(NguoiDung nguoiDung) => NguoiDungDBContext.Instance.Update(nguoiDung);
        public void DeleteNguoiDung(string tenDangNhap) => NguoiDungDBContext.Instance.Delete(tenDangNhap);
    }
}
