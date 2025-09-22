using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
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

                // Lấy và gán MaHD từ tham số output
                var maHDParam = parameters[0];
                if (maHDParam.Value != DBNull.Value)
                {
                    hd.MaHD = Convert.ToInt32(maHDParam.Value);
                }
                else
                {
                    throw new Exception("Không thể lấy MaHD từ stored procedure.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetLichSuMuaHang(int maKH)
        {
            try
            {
                string sql = "EXEC sp_KhachHang_GetLichSuMuaHang @MaKH";

                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaKH", sizeof(int), maKH, DbType.Int32)
                };

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