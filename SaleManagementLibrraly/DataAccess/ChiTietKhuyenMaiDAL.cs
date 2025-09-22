using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class ChiTietKhuyenMaiDAL
    {
        private static ChiTietKhuyenMaiDAL instance = null;
        private static readonly object instanceLock = new object();

        private ChiTietKhuyenMaiDAL() { }

        public static ChiTietKhuyenMaiDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ChiTietKhuyenMaiDAL();
                    }
                    return instance;
                }
            }
        }

        private IEnumerable<ChiTietKhuyenMai> GetFromDataReader(IDataReader reader)
        {
            var chiTietList = new List<ChiTietKhuyenMai>();
            while (reader.Read())
            {
                chiTietList.Add(new ChiTietKhuyenMai
                {
                    MaKM = reader.GetInt32(reader.GetOrdinal("MaKM")),
                    MaSP = reader.GetInt32(reader.GetOrdinal("MaSP")),
                    GiaTriGiam = reader.GetDecimal(reader.GetOrdinal("GiaTriGiam"))
                });
            }
            return chiTietList;
        }

        public IEnumerable<ChiTietKhuyenMai> GetAll()
        {
            string SQL = "SELECT MaKM, MaSP, GiaTriGiam FROM ChiTietKhuyenMai";
            try
            {
                var provider = new StockDataProvider();
                var reader = provider.GetDataReader(SQL, CommandType.Text, null);
                return GetFromDataReader(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết khuyến mãi: " + ex.Message, ex);
            }
        }

        public ChiTietKhuyenMai GetByMaKM_MaSP(int maKM, int maSP)
        {
            string SQL = "SELECT MaKM, MaSP, GiaTriGiam FROM ChiTietKhuyenMai WHERE MaKM = @MaKM AND MaSP = @MaSP";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@MaKM", 4, maKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32)
                };
                var reader = provider.GetDataReader(SQL, CommandType.Text, parameters);
                var result = GetFromDataReader(reader);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết khuyến mãi: " + ex.Message, ex);
            }
        }

        public void AddNew(ChiTietKhuyenMai cthd)
        {
            string SQL = "INSERT INTO ChiTietKhuyenMai (MaKM, MaSP, GiaTriGiam) VALUES (@MaKM, @MaSP, @GiaTriGiam)";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@MaKM", 4, cthd.MaKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 4, cthd.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@GiaTriGiam", 15, cthd.GiaTriGiam, DbType.Decimal)
                };
                provider.Insert(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết khuyến mãi: " + ex.Message, ex);
            }
        }

        public void Update(ChiTietKhuyenMai cthd)
        {
            string SQL = "UPDATE ChiTietKhuyenMai SET GiaTriGiam = @GiaTriGiam WHERE MaKM = @MaKM AND MaSP = @MaSP";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@GiaTriGiam", 15, cthd.GiaTriGiam, DbType.Decimal),
                    StockDataProvider.CreateParameter("@MaKM", 4, cthd.MaKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 4, cthd.MaSP, DbType.Int32)
                };
                provider.Update(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chi tiết khuyến mãi: " + ex.Message, ex);
            }
        }

        public void Delete(int maKM, int maSP)
        {
            string SQL = "DELETE FROM ChiTietKhuyenMai WHERE MaKM = @MaKM AND MaSP = @MaSP";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@MaKM", 4, maKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32)
                };
                provider.Delete(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết khuyến mãi: " + ex.Message, ex);
            }
        }
    }
}