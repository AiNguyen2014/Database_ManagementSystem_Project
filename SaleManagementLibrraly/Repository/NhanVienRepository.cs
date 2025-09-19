using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;

namespace SaleManagementLibrraly.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {
        public IEnumerable<NhanVien> GetNhanViens() => NhanVienDBContext.Instance.GetNhanVienList();
        public IEnumerable<NhanVien> GetNhanVienByKeyword(string keyword) => NhanVienDBContext.Instance.GetNhanVienByKeyword(keyword);
        public NhanVien GetNhanVienByID(int MaNhanVien) => NhanVienDBContext.Instance.GetNhanVienByID(MaNhanVien);
        public void InsertNhanVien(NhanVien nv) => NhanVienDBContext.Instance.AddNew(nv);
        public void UpdateNhanVien(NhanVien nv) => NhanVienDBContext.Instance.Update(nv);
        public void DeleteNhanVien(int nhanVienID) => NhanVienDBContext.Instance.Delete(nhanVienID);
    }
}
