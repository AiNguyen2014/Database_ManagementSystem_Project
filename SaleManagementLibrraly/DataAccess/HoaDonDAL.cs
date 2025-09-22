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
                string sql = "INSERT INTO HoaDon (MaHD, NgayLap, MaKH, MaNV, TongTien) VALUES (@MaHD, @NgayLap, @MaKH, @MaNV, @TongTien)";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaHD", 0, hd.MaHD, DbType.Int32),
                    StockDataProvider.CreateParameter("@NgayLap", 0, hd.NgayLap, DbType.Date),
                    StockDataProvider.CreateParameter("@MaKH", 0, hd.MaKH ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaNV", 0, hd.MaNV ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@TongTien", 0, hd.TongTien ?? (object)DBNull.Value, DbType.Decimal)
                };
                dataProvider.Insert(sql, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex) { throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message); }
            finally { CloseConnection(); }
        }


        public DataTable GetLichSuMuaHang(int maKH)
        {
            try
            {
                string sql = "EXEC sp_KhachHang_GetLichSuMuaHang @MaKH";

                // Tạo parameter theo đúng cách mà bạn đã làm ở các hàm khác
                var parameters = new List<SqlParameter>
        {
            StockDataProvider.CreateParameter("@MaKH", sizeof(int), maKH, DbType.Int32)
        };

                // Gọi phương thức ExecuteQuery mới
                DataTable data = dataProvider.ExecuteQuery(sql, CommandType.Text, parameters.ToArray());
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lịch sử mua hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}