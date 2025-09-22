using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class HoaDonDAL : BaseDAL
    {
        #region Singleton
        private static HoaDonDAL instance = null;
        private static readonly object instanceLock = new object();
        private HoaDonDAL() { }
        public static HoaDonDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HoaDonDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public void AddNew(HoaDon hd)
        {
            try
            {
                string procedureName = "sp_TaoHoaDonMoi";
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        ParameterName = "@MaHD",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    },
                    StockDataProvider.CreateParameter("@MaKH", 0, hd.MaKH ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaNV", 0, hd.MaNV ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@NgayLap", 0, hd.NgayLap == default(DateTime) ? DateTime.Now : hd.NgayLap, DbType.Date)
                };

                dataProvider.Insert(procedureName, CommandType.StoredProcedure, parameters.ToArray());

                // Optionally, you can retrieve the output parameter value here if needed
                // hd.MaHD = (int)parameters[0].Value; // Uncomment if you want to set MaHD in the object
            }
            catch (Exception ex) { throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message); }
            finally { CloseConnection(); }
        }

        public int GetLatestMaHD()
        {
            try
            {
                string sql = "SELECT MAX(MaHD) FROM HoaDon";
                return (int)dataProvider.ExecuteScalar(sql, CommandType.Text);
            }
            catch (Exception ex) { throw new Exception("Lỗi khi lấy MaHD mới nhất: " + ex.Message); }
            finally { CloseConnection(); }
        }
    }
}