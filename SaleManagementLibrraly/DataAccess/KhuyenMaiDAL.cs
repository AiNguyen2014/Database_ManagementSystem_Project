using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SaleManagementLibrraly.DataAccess
{
    public class KhuyenMaiDAL
    {
        private static KhuyenMaiDAL instance = null;
        private static readonly object instanceLock = new object();

        private KhuyenMaiDAL() { }

        public static KhuyenMaiDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new KhuyenMaiDAL();
                    }
                    return instance;
                }
            }
        }

        private IEnumerable<KhuyenMai> GetKhuyenMaiListFromDataReader(IDataReader reader)
        {
            var khuyenMaiList = new List<KhuyenMai>();
            while (reader.Read())
            {
                khuyenMaiList.Add(new KhuyenMai
                {
                    MaKM = reader.GetInt32(reader.GetOrdinal("MaKM")),
                    TenKM = reader.GetString(reader.GetOrdinal("TenKM")),
                    MaHT = reader.GetInt32(reader.GetOrdinal("MaHT")),
                    NgayBD = reader.GetDateTime(reader.GetOrdinal("NgayBD")),
                    NgayKT = reader.GetDateTime(reader.GetOrdinal("NgayKT")),
                    DieuKien = reader.IsDBNull(reader.GetOrdinal("DieuKien")) ? null : reader.GetString(reader.GetOrdinal("DieuKien"))
                });
            }
            return khuyenMaiList;
        }

        public IEnumerable<KhuyenMai> GetAll()
        {
            string SQL = "SELECT MaKM, TenKM, MaHT, NgayBD, NgayKT, DieuKien FROM KhuyenMai";
            try
            {
                var provider = new StockDataProvider();
                var reader = provider.GetDataReader(SQL, CommandType.Text, null);
                return GetKhuyenMaiListFromDataReader(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khuyến mãi: " + ex.Message, ex);
            }
        }

        public KhuyenMai GetByMaKM(int maKM)
        {
            string SQL = "SELECT MaKM, TenKM, MaHT, NgayBD, NgayKT, DieuKien FROM KhuyenMai WHERE MaKM = @MaKM";
            try
            {
                var provider = new StockDataProvider();
                var parameter = StockDataProvider.CreateParameter("@MaKM", 4, maKM, DbType.Int32);
                var reader = provider.GetDataReader(SQL, CommandType.Text, parameter);
                var result = GetKhuyenMaiListFromDataReader(reader);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy khuyến mãi theo mã: " + ex.Message, ex);
            }
        }

        public void AddNew(KhuyenMai km)
        {
            string SQL = "INSERT INTO KhuyenMai (MaKM, TenKM, MaHT, NgayBD, NgayKT, DieuKien) VALUES (@MaKM, @TenKM, @MaHT, @NgayBD, @NgayKT, @DieuKien)";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@MaKM", 4, km.MaKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@TenKM", 50, km.TenKM, DbType.String),
                    StockDataProvider.CreateParameter("@MaHT", 4, km.MaHT, DbType.Int32),
                    StockDataProvider.CreateParameter("@NgayBD", 8, km.NgayBD, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKT", 8, km.NgayKT, DbType.Date),
                    StockDataProvider.CreateParameter("@DieuKien", 200, km.DieuKien, DbType.String)
                };
                provider.Insert(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khuyến mãi mới: " + ex.Message, ex);
            }
        }

        public void Update(KhuyenMai km)
        {
            string SQL = "UPDATE KhuyenMai SET TenKM = @TenKM, MaHT = @MaHT, NgayBD = @NgayBD, NgayKT = @NgayKT, DieuKien = @DieuKien WHERE MaKM = @MaKM";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@TenKM", 50, km.TenKM, DbType.String),
                    StockDataProvider.CreateParameter("@MaHT", 4, km.MaHT, DbType.Int32),
                    StockDataProvider.CreateParameter("@NgayBD", 8, km.NgayBD, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKT", 8, km.NgayKT, DbType.Date),
                    StockDataProvider.CreateParameter("@DieuKien", 200, km.DieuKien, DbType.String),
                    StockDataProvider.CreateParameter("@MaKM", 4, km.MaKM, DbType.Int32)
                };
                provider.Update(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khuyến mãi: " + ex.Message, ex);
            }
        }

        public void Delete(int maKM)
        {
            string SQL = "DELETE FROM KhuyenMai WHERE MaKM = @MaKM";
            try
            {
                var provider = new StockDataProvider();
                var parameter = StockDataProvider.CreateParameter("@MaKM", 4, maKM, DbType.Int32);
                provider.Delete(SQL, CommandType.Text, parameter);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khuyến mãi: " + ex.Message, ex);
            }
        }
    }
}