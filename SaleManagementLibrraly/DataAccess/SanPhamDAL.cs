using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class SanPhamDAL : BaseDAL
    {
        #region Singleton
        private static SanPhamDAL? instance = null;
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

        // =============================================================
        // LẤY TẤT CẢ SẢN PHẨM
        // =============================================================
        public IEnumerable<SanPham> GetAll()
        {
            var listSanPham = new List<SanPham>();
            string SQLSelect = @"SELECT MaSP, TenSP, DonViTinh, GiaNhap, HanSuDung, 
                                        SoLuongTon, MaLoaiSP, TrangThai, DonGia 
                                 FROM SanPham";
            try
            {
                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text);
                while (reader.Read())
                {
                    listSanPham.Add(new SanPham
                    {
                        MaSP = reader.GetInt32(0),
                        TenSP = reader.GetString(1),
                        DonViTinh = reader.GetString(2),
                        GiaNhap = reader.GetDecimal(3),
                        
                        HanSuDung = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                        SoLuongTon = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                        MaLoaiSP = reader.IsDBNull(7) ? null : reader.GetInt32(7),
                        TrangThai = reader.IsDBNull(8) ? null : reader.GetString(8),
                        DonGia = reader.IsDBNull(9) ? null : reader.GetDecimal(9)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            return listSanPham;
        }

        // =============================================================
        // THÊM SẢN PHẨM
        // =============================================================
        public void AddNew(SanPham sp)
        {
            try
            {
                string sqlInsert = @"INSERT INTO SanPham 
                                    (MaSP, TenSP, DonViTinh, GiaNhap, GiaBan, HanSuDung, SoLuongTon, MaLoaiSP, TrangThai, DonGia) 
                                     VALUES (@MaSP, @TenSP, @DonViTinh, @GiaNhap, @GiaBan, @HanSuDung, @SoLuongTon, @MaLoaiSP, @TrangThai, @DonGia)";
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
                new StockDataProvider().Insert(sqlInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        // =============================================================
        // CẬP NHẬT SẢN PHẨM
        // =============================================================
        public void Update(SanPham sp)
        {
            try
            {
                string sqlUpdate = @"UPDATE SanPham 
                                     SET TenSP=@TenSP, DonViTinh=@DonViTinh, GiaNhap=@GiaNhap, GiaBan=@GiaBan, 
                                         HanSuDung=@HanSuDung, SoLuongTon=@SoLuongTon, MaLoaiSP=@MaLoaiSP, 
                                         TrangThai=@TrangThai, DonGia=@DonGia 
                                     WHERE MaSP = @MaSP";
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
                new StockDataProvider().Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }
        }

        // =============================================================
        // XÓA SẢN PHẨM
        // =============================================================
        public void Delete(int maSP)
        {
            try
            {
                string sqlDelete = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                var param = StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32);
                new StockDataProvider().Delete(sqlDelete, CommandType.Text, param);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        // PHƯƠNG THỨC 1: Lấy danh sách sản phẩm cho khách hàng xem
        public IEnumerable<SanPham> GetAllProducts()
        {
            var products = new List<SanPham>();
            IDataReader dataReader = null;
            try
            {
                // Lấy dữ liệu từ cột DonGia nhưng đặt tên tạm là GiaBan để khớp với đối tượng SanPham
                string sql = @"SELECT sp.MaSP, sp.TenSP, sp.DonViTinh, sp.DonGia AS GiaBan, sp.SoLuongTon, sp.TrangThai, lsp.TenLoaiSP
                       FROM SanPham AS sp
                       JOIN LoaiSanPham AS lsp ON sp.MaLoaiSP = lsp.MaLoaiSP
                       WHERE sp.TrangThai <> N'Ngừng kinh doanh'";

                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, null);
                while (dataReader.Read())
                {
                    products.Add(new SanPham
                    {
                        MaSP = dataReader.GetInt32(0),
                        TenSP = dataReader.GetString(1),
                        DonViTinh = dataReader.GetString(2),
                        GiaBan = dataReader.GetDecimal(3),
                        SoLuongTon = dataReader.GetInt32(4),
                        TrangThai = dataReader.GetString(5),
                        TenLoaiSP = dataReader.GetString(6)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm cho khách hàng: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return products;
        }

        // PHƯƠNG THỨC 2: Lấy thông tin 1 sản phẩm theo ID (dùng cho giỏ hàng)
        public SanPham GetSanPhamByID(int maSP)
        {
            SanPham sanPham = null;
            IDataReader dataReader = null;
            try
            {
                string sql = "SELECT MaSP, TenSP, DonViTinh, DonGia AS GiaBan FROM SanPham WHERE MaSP = @MaSP";
                var parameter = StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32);
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, parameter);
                if (dataReader.Read())
                {
                    sanPham = new SanPham
                    {
                        MaSP = dataReader.GetInt32(dataReader.GetOrdinal("MaSP")),
                        TenSP = dataReader.GetString(dataReader.GetOrdinal("TenSP")),
                        DonViTinh = dataReader.GetString(dataReader.GetOrdinal("DonViTinh")),
                        GiaBan = dataReader.GetDecimal(dataReader.GetOrdinal("GiaBan"))
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm theo ID. Lỗi gốc: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return sanPham;
        }

        // PHƯƠ-NG THỨC 3: Cập nhật số lượng tồn kho (dùng cho thanh toán)
        // Đây là hàm của bạn bạn, nhưng mình đã sửa lại cho nhất quán để code của bạn không bị lỗi.
        public void UpdateSoLuongTon(int maSP, int soLuongBan)
        {
            try
            {
                string sql = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuongBan WHERE MaSP = @MaSP";
                var parameters = new[]
                {
            StockDataProvider.CreateParameter("@SoLuongBan", 0, soLuongBan, DbType.Int32),
            StockDataProvider.CreateParameter("@MaSP", 0, maSP, DbType.Int32)
        };
                // Dùng dataProvider có sẵn thay vì tạo mới
                dataProvider.ExecuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật số lượng tồn: " + ex.Message);
            }
        }
    }
}