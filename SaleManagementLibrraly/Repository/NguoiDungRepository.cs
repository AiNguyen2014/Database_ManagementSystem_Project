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
        public NguoiDung GetNguoiDungLogin(string TenDangNhap, string MatKhau) => TaiKhoanDAL.Instance.GetInfo(TenDangNhap, MatKhau);
        public IEnumerable<NguoiDung> GetNguoiDungs() => TaiKhoanDAL.Instance.GetNguoiDungList();
        public IEnumerable<NguoiDung> GetNguoiDungByKeyword(string keyword) => TaiKhoanDAL.Instance.GetNguoiDungByKeyword(keyword);
        public NguoiDung GetNguoiDungByTenDangNhap(string tenDangNhap) => TaiKhoanDAL.Instance.GetNguoiDungByTenDangNhap(tenDangNhap);
        public void InsertNguoiDung(NguoiDung nguoiDung) => TaiKhoanDAL.Instance.AddNew(nguoiDung);
        public void UpdateNguoiDung(NguoiDung nguoiDung) => TaiKhoanDAL.Instance.Update(nguoiDung);
        public void DeleteNguoiDung(string tenDangNhap) => TaiKhoanDAL.Instance.Delete(tenDangNhap);
    }
}
