using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class ChiTietKhuyenMaiDAL : BaseDAL
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

        public void AddNew(ChiTietKhuyenMai ctkm)
        {
            try
            {
                string procedureName = "sp_ThemChiTietKhuyenMai";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaKM", 4, ctkm.MaKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 4, ctkm.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@GiaTriGiam", 15, ctkm.GiaTriGiam, DbType.Decimal)
                };

                dataProvider.Insert(procedureName, CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết khuyến mãi: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(ChiTietKhuyenMai ctkm)
        {
            try
            {
                string procedureName = "sp_SuaChiTietKhuyenMai";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaKM", 4, ctkm.MaKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 4, ctkm.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@GiaTriGiam", 15, ctkm.GiaTriGiam, DbType.Decimal)
                };

                dataProvider.Update(procedureName, CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chi tiết khuyến mãi: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
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