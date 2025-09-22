using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class ChiTietHoaDonDAL : BaseDAL
    {
        #region Singleton
        private static ChiTietHoaDonDAL instance = null;
        private static readonly object instanceLock = new object();
        private ChiTietHoaDonDAL() { }
        public static ChiTietHoaDonDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ChiTietHoaDonDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        // Hàm để thêm một dòng chi tiết vào hóa đơn bằng stored procedure
        public void AddNew(ChiTietHoaDon cthd)
        {
            try
            {
                string procedureName = "sp_ThemChiTietHoaDon";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaHD", 0, cthd.MaHD, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 0, cthd.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@SoLuong", 0, cthd.SoLuong, DbType.Int32)
                };
                // Gọi stored procedure thay vì INSERT trực tiếp
                dataProvider.Insert(procedureName, CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}