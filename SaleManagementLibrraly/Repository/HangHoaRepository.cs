using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManagementLibrraly.BussinessObject;
using SaleManagementLibrraly.DataAccess;

namespace SaleManagementLibrraly.Repository
{
    public class HangHoaRepository : IHangHoaRepository
    {
        public IEnumerable<HangHoa> GetHangHoas() => HangHoaDBContext.Instance.GetHangHoaList();
        public IEnumerable<HangHoa> GetHangHoaByKeyword(string keyword) => HangHoaDBContext.Instance.GetHangHoaByKeyword(keyword);
        public HangHoa GetHangHoaByID(int hangHoaID) => HangHoaDBContext.Instance.GetHangHoaByID(hangHoaID);
        public void InsertHangHoa(HangHoa hangHoa) => HangHoaDBContext.Instance.AddNew(hangHoa);
        public void UpdateHangHoa(HangHoa hangHoa) => HangHoaDBContext.Instance.Update(hangHoa);
        public void DeleteHangHoa(int hangHoaID) => HangHoaDBContext.Instance.Delete(hangHoaID);
    }
}
