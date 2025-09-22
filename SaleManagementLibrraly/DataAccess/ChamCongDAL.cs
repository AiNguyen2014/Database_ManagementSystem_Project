using SaleManagementLibrraly.BussinessObject;
using System.Data;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;

namespace SaleManagementLibrraly.DataAccess
{
    public class ChamCongDAL
    {
        #region Singleton
        private static ChamCongDAL instance = null;
        private static readonly object instanceLock = new object();
        private ChamCongDAL() { }
        public static ChamCongDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ChamCongDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        // ==========================================================
        // SỬA LẠI PHƯƠNG THỨC NÀY
        // ==========================================================
        public DataTable GetByMaNV(int maNV)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT NgayLam, GioBD, GioKT FROM ChamCong WHERE MaNV = @MaNV ORDER BY NgayLam DESC";
            var param = StockDataProvider.CreateParameter("@MaNV", 4, maNV, DbType.Int32);

            try
            {
                // Dùng đúng phương thức GetDataReader
                using var reader = new StockDataProvider().GetDataReader(query, CommandType.Text, param);
                // Dùng phương thức Load để tự động đổ dữ liệu từ reader vào DataTable
                dataTable.Load(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lịch sử chấm công: " + ex.Message);
            }
            return dataTable;
        }

        public void ExecuteChamCong(int maNV)
        {
            string procName = "SP_ChamCong";
            var parameters = new List<SqlParameter>
            {
                StockDataProvider.CreateParameter("@MaCC", 4, new Random().Next(), DbType.Int32),
                StockDataProvider.CreateParameter("@MaNV", 4, maNV, DbType.Int32),
                StockDataProvider.CreateParameter("@NgayLam", 0, DateTime.Today, DbType.Date),
                StockDataProvider.CreateParameter("@GioBD", 0, DateTime.Now.TimeOfDay, DbType.Time),
                StockDataProvider.CreateParameter("@GioKT", 0, DateTime.Now.TimeOfDay, DbType.Time)
            };
            new StockDataProvider().Update(procName, CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}