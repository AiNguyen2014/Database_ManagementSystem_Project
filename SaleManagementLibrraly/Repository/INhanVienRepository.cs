using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManagementLibrraly.BussinessObject;

namespace SaleManagementLibrraly.Repository
{
    public interface INhanVienRepository
    {
        IEnumerable<NhanVien> GetNhanViens();
        IEnumerable<NhanVien> GetNhanVienByKeyword(string keyword);
        NhanVien GetNhanVienByID(int MaNhanVien);
        void InsertNhanVien(NhanVien nv);
        void UpdateNhanVien(NhanVien nv);
        void DeleteNhanVien(int nhanVienID);
    }
}
