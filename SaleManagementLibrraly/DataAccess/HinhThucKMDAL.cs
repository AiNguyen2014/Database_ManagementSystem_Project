using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SaleManagementLibrraly.DataAccess
{
    public class HinhThucKMDAL
    {
        private static HinhThucKMDAL instance = null;
        private static readonly object instanceLock = new object();

        private HinhThucKMDAL() { }

        public static HinhThucKMDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HinhThucKMDAL();
                    }
                    return instance;
                }
            }
        }

        private IEnumerable<HinhThucKM> GetFromDataReader(IDataReader reader)
        {
            var hinhThucList = new List<HinhThucKM>();
            while (reader.Read())
            {
                hinhThucList.Add(new HinhThucKM
                {
                    MaHT = reader.GetInt32(reader.GetOrdinal("MaHT")),
                    TenHT = reader.GetString(reader.GetOrdinal("TenHT"))
                });
            }
            return hinhThucList;
        }

        public IEnumerable<HinhThucKM> GetAll()
        {
            string SQL = "SELECT MaHT, TenHT FROM HinhThucKM";
            try
            {
                var provider = new StockDataProvider();
                var reader = provider.GetDataReader(SQL, CommandType.Text, null);
                return GetFromDataReader(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hình thức khuyến mãi: " + ex.Message, ex);
            }
        }

        public HinhThucKM GetByMaHT(int maHT)
        {
            string SQL = "SELECT MaHT, TenHT FROM HinhThucKM WHERE MaHT = @MaHT";
            try
            {
                var provider = new StockDataProvider();
                var parameter = StockDataProvider.CreateParameter("@MaHT", 4, maHT, DbType.Int32);
                var reader = provider.GetDataReader(SQL, CommandType.Text, parameter);
                var result = GetFromDataReader(reader);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hình thức khuyến mãi theo mã: " + ex.Message, ex);
            }
        }

        public void AddNew(HinhThucKM hinhThuc)
        {
            string SQL = "INSERT INTO HinhThucKM (MaHT, TenHT) VALUES (@MaHT, @TenHT)";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@MaHT", 4, hinhThuc.MaHT, DbType.Int32),
                    StockDataProvider.CreateParameter("@TenHT", 200, hinhThuc.TenHT, DbType.String)
                };
                provider.Insert(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm hình thức khuyến mãi mới: " + ex.Message, ex);
            }
        }

        public void Update(HinhThucKM hinhThuc)
        {
            string SQL = "UPDATE HinhThucKM SET TenHT = @TenHT WHERE MaHT = @MaHT";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@TenHT", 200, hinhThuc.TenHT, DbType.String),
                    StockDataProvider.CreateParameter("@MaHT", 4, hinhThuc.MaHT, DbType.Int32)
                };
                provider.Update(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật hình thức khuyến mãi: " + ex.Message, ex);
            }
        }

        public void Delete(int maHT)
        {
            string SQL = "DELETE FROM HinhThucKM WHERE MaHT = @MaHT";
            try
            {
                var provider = new StockDataProvider();
                var parameter = StockDataProvider.CreateParameter("@MaHT", 4, maHT, DbType.Int32);
                provider.Delete(SQL, CommandType.Text, parameter);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa hình thức khuyến mãi: " + ex.Message, ex);
            }
        }
    }
}