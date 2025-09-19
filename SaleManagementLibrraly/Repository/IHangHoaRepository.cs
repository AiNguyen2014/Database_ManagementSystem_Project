using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManagementLibrraly.BussinessObject;

namespace SaleManagementLibrraly.Repository
{
    public interface IHangHoaRepository
    {
        IEnumerable<HangHoa> GetHangHoas();
        IEnumerable<HangHoa> GetHangHoaByKeyword(string keyword);
        HangHoa GetHangHoaByID(int hangHoaID);
        void InsertHangHoa(HangHoa hh);
        void UpdateHangHoa(HangHoa hh);
        void DeleteHangHoa(int hangHoaID);
    }
}
