using SaleManagementLibrraly.BussinessObject;
using System.Collections.Generic;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class VaiTroDAL
    {
        #region Singleton
        private static VaiTroDAL instance = null;
        private static readonly object instanceLock = new object();
        private VaiTroDAL() { }
        public static VaiTroDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new VaiTroDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public IEnumerable<VaiTro> GetAll()
        {
            var vaiTroList = new List<VaiTro>();
            string SQLSelect = "SELECT MaVaiTro, TenVaiTro FROM VaiTro";
            try
            {
                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text);
                while (reader.Read())
                {
                    vaiTroList.Add(new VaiTro
                    {
                        MaVaiTro = reader.GetInt32(0),
                        TenVaiTro = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách vai trò: " + ex.Message);
            }
            return vaiTroList;
        }
    }
}