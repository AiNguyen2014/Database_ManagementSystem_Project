using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;

namespace SaleManagementLibrraly.DataAccess
{
    public class NhaCungCapDAL : BaseDAL
    {
        #region Singleton
        private static NhaCungCapDAL instance = null;
        private static readonly object instanceLock = new object();
        private NhaCungCapDAL() { }
        public static NhaCungCapDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NhaCungCapDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public void Them(int maNCC, string tenNCC, string diaChi, string sdt, string email)
        {
            try
            {
                string sql = "sp_NhaCungCap_Them";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@MaNCC", 4, maNCC, DbType.Int32),
                    StockDataProvider.CreateParameter("@TenNCC", 100, tenNCC, DbType.String),
                    StockDataProvider.CreateParameter("@DiaChi", 200, diaChi, DbType.String),
                    StockDataProvider.CreateParameter("@SoDienThoai", 20, sdt, DbType.String),
                    StockDataProvider.CreateParameter("@Email", 100, email, DbType.String)
                };
                dataProvider.Insert(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_NhaCungCap_GetAll";
                using (IDataReader reader = dataProvider.GetDataReader(sql, CommandType.StoredProcedure))
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public void CapNhat(int maNCC, string tenNCC, string diaChi, string sdt, string email)
        {
            try
            {
                string sql = "sp_NhaCungCap_CapNhat";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@MaNCC", 4, maNCC, DbType.Int32),
                    StockDataProvider.CreateParameter("@TenNCC", 100, tenNCC, DbType.String),
                    StockDataProvider.CreateParameter("@DiaChi", 200, diaChi, DbType.String),
                    StockDataProvider.CreateParameter("@SoDienThoai", 20, sdt, DbType.String),
                    StockDataProvider.CreateParameter("@Email", 100, email, DbType.String)
                };
                dataProvider.Update(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Xoa(int maNCC)
        {
            try
            {
                string sql = "sp_NhaCungCap_Xoa";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@MaNCC", 4, maNCC, DbType.Int32)
                };
                dataProvider.Delete(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}