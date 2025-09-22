using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class NhanVienDAL : BaseDAL
    {
        #region Singleton
        private static NhanVienDAL? instance = null;
        private static readonly object instanceLock = new object();
        private NhanVienDAL() { }
        public static NhanVienDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NhanVienDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        // =============================================================
        // LẤY DANH SÁCH NHÂN VIÊN
        // =============================================================
        public IEnumerable<NhanVien> GetAll()
        {
            var listNhanVien = new List<NhanVien>();
            string SQLSelect = @"SELECT MaNV, HoTen, NgaySinh, DiaChi, GioiTinh, 
                                        NgayVaoLam, SoDienThoai, ChucVu, CCCD 
                                 FROM NhanVien";

            try
            {
                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text);
                while (reader.Read())
                {
                    listNhanVien.Add(new NhanVien
                    {
                        MaNV = reader.GetInt32(0),
                        HoTen = reader.GetString(1),
                        NgaySinh = reader.GetDateTime(2),
                        DiaChi = reader.GetString(3),
                        GioiTinh = reader.GetString(4),
                        NgayVaoLam = reader.GetDateTime(5),
                        SoDienThoai = reader.GetString(6),
                        ChucVu = reader.GetString(7),
                        CCCD = reader.GetString(8)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
            return listNhanVien;
        }

        // =============================================================
        // THÊM NHÂN VIÊN
        // =============================================================
        public void AddNew(NhanVien nv)
        {
            try
            {
                string sqlInsert = @"INSERT INTO NhanVien 
                                    (HoTen, NgaySinh, DiaChi, GioiTinh, NgayVaoLam, 
                                     SoDienThoai, ChucVu, CCCD) 
                                     VALUES (@HoTen, @NgaySinh, @DiaChi, @GioiTinh, 
                                             @NgayVaoLam, @SoDienThoai, @ChucVu, @CCCD)";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@HoTen", 100, nv.HoTen, DbType.String),
                    StockDataProvider.CreateParameter("@NgaySinh", 0, nv.NgaySinh, DbType.Date),
                    StockDataProvider.CreateParameter("@DiaChi", 300, nv.DiaChi, DbType.String),
                    StockDataProvider.CreateParameter("@GioiTinh", 5, nv.GioiTinh, DbType.String),
                    StockDataProvider.CreateParameter("@NgayVaoLam", 0, nv.NgayVaoLam, DbType.Date),
                    StockDataProvider.CreateParameter("@SoDienThoai", 15, nv.SoDienThoai, DbType.String),
                    StockDataProvider.CreateParameter("@ChucVu", 50, nv.ChucVu, DbType.String),
                    StockDataProvider.CreateParameter("@CCCD", 20, nv.CCCD, DbType.String)
                };
                new StockDataProvider().Insert(sqlInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        // =============================================================
        // CẬP NHẬT NHÂN VIÊN
        // =============================================================
        public void Update(NhanVien nv)
        {
            try
            {
                string sqlUpdate = @"UPDATE NhanVien 
                                     SET HoTen=@HoTen, NgaySinh=@NgaySinh, DiaChi=@DiaChi, 
                                         GioiTinh=@GioiTinh, NgayVaoLam=@NgayVaoLam, 
                                         SoDienThoai=@SoDienThoai, ChucVu=@ChucVu, CCCD=@CCCD 
                                     WHERE MaNV = @MaNV";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaNV", 0, nv.MaNV, DbType.Int32),
                    StockDataProvider.CreateParameter("@HoTen", 100, nv.HoTen, DbType.String),
                    StockDataProvider.CreateParameter("@NgaySinh", 0, nv.NgaySinh, DbType.Date),
                    StockDataProvider.CreateParameter("@DiaChi", 300, nv.DiaChi, DbType.String),
                    StockDataProvider.CreateParameter("@GioiTinh", 5, nv.GioiTinh, DbType.String),
                    StockDataProvider.CreateParameter("@NgayVaoLam", 0, nv.NgayVaoLam, DbType.Date),
                    StockDataProvider.CreateParameter("@SoDienThoai", 15, nv.SoDienThoai, DbType.String),
                    StockDataProvider.CreateParameter("@ChucVu", 50, nv.ChucVu, DbType.String),
                    StockDataProvider.CreateParameter("@CCCD", 20, nv.CCCD, DbType.String)
                };
                new StockDataProvider().Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
        }

        // =============================================================
        // XÓA NHÂN VIÊN
        // =============================================================
        public void Delete(int maNV)
        {
            try
            {
                string sqlDelete = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                var param = StockDataProvider.CreateParameter("@MaNV", 4, maNV, DbType.Int32);
                new StockDataProvider().Delete(sqlDelete, CommandType.Text, param);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }
        public NhanVien GetNhanVienByID(int maNV)
        {
            NhanVien nhanVien = null;
            string SQLSelect = @"SELECT MaNV, HoTen, NgaySinh, DiaChi, GioiTinh, 
                                NgayVaoLam, SoDienThoai, ChucVu, CCCD 
                         FROM NhanVien WHERE MaNV = @MaNV";
            var param = StockDataProvider.CreateParameter("@MaNV", 4, maNV, DbType.Int32);

            try
            {
                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text, param);
                if (reader.Read()) // Nếu tìm thấy dữ liệu
                {
                    nhanVien = new NhanVien
                    {
                        MaNV = reader.GetInt32(0),
                        HoTen = reader.GetString(1),
                        NgaySinh = reader.GetDateTime(2),
                        DiaChi = reader.GetString(3),
                        GioiTinh = reader.GetString(4),
                        NgayVaoLam = reader.GetDateTime(5),
                        SoDienThoai = reader.GetString(6),
                        ChucVu = reader.GetString(7),
                        CCCD = reader.GetString(8)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin nhân viên theo ID: " + ex.Message);
            }
            return nhanVien;
        }
    }
}