using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;

namespace SaleManagementLibrraly.DataAccess
{
    public class PhieuNhapDAL : BaseDAL
    {
        #region Singleton
        private static PhieuNhapDAL instance = null;
        private static readonly object instanceLock = new object();
        private PhieuNhapDAL() { }
        public static PhieuNhapDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PhieuNhapDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        /// <summary>Tạo phiếu nhập hàng mới và trả về MaPN</summary>
        public int TaoMoi(int maNCC, int maNV, DateTime? ngayNhap, out int maPN)
        {
            try
            {
                string sql = "sp_PhieuNhap_TaoMoi";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@MaNCC", 4, maNCC, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaNV", 4, maNV, DbType.Int32),
                    StockDataProvider.CreateParameter("@NgayNhap", 8, ngayNhap ?? (object)DBNull.Value, DbType.Date)
                };
                maPN = Convert.ToInt32(dataProvider.ExecuteScalar(sql, CommandType.StoredProcedure, parameters));
                return maPN;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo phiếu nhập: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>Cập nhật trạng thái phiếu nhập</summary>
        public void CapNhatTrangThai(int maPN, string trangThai)
        {
            try
            {
                string sql = "sp_PhieuNhap_CapNhatTrangThai";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@MaPN", 4, maPN, DbType.Int32),
                    StockDataProvider.CreateParameter("@TrangThai", 50, trangThai, DbType.String)
                };
                dataProvider.Update(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái phiếu nhập: " + ex.Message);
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
                string sql = "sp_PhieuNhap_GetAll";
                using (IDataReader reader = dataProvider.GetDataReader(sql, CommandType.StoredProcedure))
                {
                    dt.Load(reader); // Điền dữ liệu từ DataReader vào DataTable
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phiếu nhập: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public void ThemChiTiet(int maPN, int maSP, int soLuong, decimal giaNhap)
        {
            try
            {
                string sql = "sp_ChiTietPhieuNhap_Them";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@MaPN", 4, maPN, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@SoLuong", 4, soLuong, DbType.Int32),
                    StockDataProvider.CreateParameter("@GiaNhap", 15, giaNhap, DbType.Decimal)
                };
                dataProvider.Insert(sql, CommandType.StoredProcedure, parameters); // Sử dụng Insert thay vì ExecuteNonQuery
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết phiếu nhập: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetChiTietByMaPN(int maPN)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_ChiTietPhieuNhap_GetByMaPN";
                var parameters = new[]
                {
            StockDataProvider.CreateParameter("@MaPN", 4, maPN, DbType.Int32)
        };
                using (IDataReader reader = dataProvider.GetDataReader(sql, CommandType.StoredProcedure, parameters))
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết phiếu nhập: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public void CapNhatTonKho(int maPN)
        {
            try
            {
                string sql = "sp_TonKho_CapNhatTuPhieuNhap";
                var parameters = new[]
                {
            StockDataProvider.CreateParameter("@MaPN", 4, maPN, DbType.Int32)
        };
                dataProvider.Update(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tồn kho: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void XacNhan(int maPN, string trangThai, string ghiChu)
        {
            try
            {
                string sql = "sp_PhieuNhap_XacNhan";
                var parameters = new[]
                {
            StockDataProvider.CreateParameter("@MaPN", 4, maPN, DbType.Int32),
            StockDataProvider.CreateParameter("@TrangThai", 50, trangThai, DbType.String),
            StockDataProvider.CreateParameter("@GhiChu", 500, (object)ghiChu ?? DBNull.Value, DbType.String)
        };
                dataProvider.Update(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xác nhận phiếu nhập: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void CapNhatTrangThaiSanPham(int maSP, string trangThai)
        {
            try
            {
                string sql = "sp_SanPham_CapNhatTrangThai";
                var parameters = new[]
                {
            StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32),
            StockDataProvider.CreateParameter("@TrangThai", 50, trangThai, DbType.String)
        };
                dataProvider.Update(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái sản phẩm: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}