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
            string SQLSelect = @"SELECT MaSP, TenSP, DonViTinh, GiaNhap, GiaBan, HanSuDung, 
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
                        GiaBan = reader.GetDecimal(4),
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

        // =============================================================
        // CẬP NHẬT SỐ LƯỢNG TỒN
        // =============================================================
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
                new StockDataProvider().Update(sql, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật số lượng tồn: " + ex.Message);
            }
        }
    }
}