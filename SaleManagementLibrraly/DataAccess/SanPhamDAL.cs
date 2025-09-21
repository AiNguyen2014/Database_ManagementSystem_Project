using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class SanPhamDAL : BaseDAL
    {
        #region Singleton
        private static SanPhamDAL instance = null;
        private static readonly object instanceLock = new object();
        private SanPhamDAL() { }
        public static SanPhamDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SanPhamDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public IEnumerable<SanPham> GetAll()
        {
            IDataReader dataReader = null;
            var listSanPham = new List<SanPham>();
            string SQLSelect = "SELECT MaSP, TenSP, DonViTinh, GiaNhap, GiaBan, HanSuDung, SoLuongTon, MaLoaiSP, TrangThai, DonGia FROM SanPham";

            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    listSanPham.Add(new SanPham
                    {
                        MaSP = dataReader.GetInt32(0),
                        TenSP = dataReader.GetString(1),
                        DonViTinh = dataReader.GetString(2),
                        GiaNhap = dataReader.GetDecimal(3),
                        GiaBan = dataReader.GetDecimal(4),
                        HanSuDung = dataReader.IsDBNull(5) ? null : dataReader.GetDateTime(5),
                        SoLuongTon = dataReader.IsDBNull(6) ? null : dataReader.GetInt32(6),
                        MaLoaiSP = dataReader.IsDBNull(7) ? null : dataReader.GetInt32(7),
                        TrangThai = dataReader.IsDBNull(8) ? null : dataReader.GetString(8),
                        DonGia = dataReader.IsDBNull(9) ? null : dataReader.GetDecimal(9)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return listSanPham;
        }

        public void AddNew(SanPham sp)
        {
            try
            {
                // Giả định MaSP không phải là cột tự tăng (IDENTITY)
                string sqlInsert = "INSERT INTO SanPham (MaSP, TenSP, DonViTinh, GiaNhap, GiaBan, HanSuDung, SoLuongTon, MaLoaiSP, TrangThai, DonGia) VALUES (@MaSP, @TenSP, @DonViTinh, @GiaNhap, @GiaBan, @HanSuDung, @SoLuongTon, @MaLoaiSP, @TrangThai, @DonGia)";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaSP", 0, sp.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@TenSP", 100, sp.TenSP, DbType.String),
                    StockDataProvider.CreateParameter("@DonViTinh", 20, sp.DonViTinh, DbType.String),
                    StockDataProvider.CreateParameter("@GiaNhap", 0, sp.GiaNhap, DbType.Decimal),
                    StockDataProvider.CreateParameter("@GiaBan", 0, sp.GiaBan, DbType.Decimal),
                    StockDataProvider.CreateParameter("@HanSuDung", 0, sp.HanSuDung ?? (object)DBNull.Value, DbType.Date),
                    StockDataProvider.CreateParameter("@SoLuongTon", 0, sp.SoLuongTon ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaLoaiSP", 0, sp.MaLoaiSP ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@TrangThai", 20, sp.TrangThai ?? (object)DBNull.Value, DbType.String),
                    StockDataProvider.CreateParameter("@DonGia", 0, sp.DonGia ?? (object)DBNull.Value, DbType.Decimal),
                };
                dataProvider.Insert(sqlInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(SanPham sp)
        {
            try
            {
                string sqlUpdate = "UPDATE SanPham SET TenSP=@TenSP, DonViTinh=@DonViTinh, GiaNhap=@GiaNhap, GiaBan=@GiaBan, HanSuDung=@HanSuDung, SoLuongTon=@SoLuongTon, MaLoaiSP=@MaLoaiSP, TrangThai=@TrangThai, DonGia=@DonGia WHERE MaSP = @MaSP";
                var parameters = new List<SqlParameter>
        {
            StockDataProvider.CreateParameter("@MaSP", 0, sp.MaSP, DbType.Int32),
            StockDataProvider.CreateParameter("@TenSP", 100, sp.TenSP, DbType.String),
            StockDataProvider.CreateParameter("@DonViTinh", 20, sp.DonViTinh, DbType.String),
            StockDataProvider.CreateParameter("@GiaNhap", 0, sp.GiaNhap, DbType.Decimal),
            StockDataProvider.CreateParameter("@GiaBan", 0, sp.GiaBan, DbType.Decimal),
            StockDataProvider.CreateParameter("@HanSuDung", 0, sp.HanSuDung ?? (object)DBNull.Value, DbType.Date),
            StockDataProvider.CreateParameter("@SoLuongTon", 0, sp.SoLuongTon ?? (object)DBNull.Value, DbType.Int32),
            StockDataProvider.CreateParameter("@MaLoaiSP", 0, sp.MaLoaiSP ?? (object)DBNull.Value, DbType.Int32),
            StockDataProvider.CreateParameter("@TrangThai", 20, sp.TrangThai ?? (object)DBNull.Value, DbType.String),
            StockDataProvider.CreateParameter("@DonGia", 0, sp.DonGia ?? (object)DBNull.Value, DbType.Decimal),
        };
                dataProvider.Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int maSP)
        {
            try
            {
                string sqlDelete = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                var param = StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32);
                dataProvider.Delete(sqlDelete, CommandType.Text, param);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateSoLuongTon(int maSP, int soLuongBan)
        {
            try
            {
                string sql = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuongBan WHERE MaSP = @MaSP";
                var parameters = new List<SqlParameter>
        {
            StockDataProvider.CreateParameter("@SoLuongBan", 0, soLuongBan, DbType.Int32),
            StockDataProvider.CreateParameter("@MaSP", 0, maSP, DbType.Int32)
        };
                dataProvider.Update(sql, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex) { throw new Exception("Lỗi cập nhật số lượng tồn: " + ex.Message); }
            finally { CloseConnection(); }
        }
    }
}