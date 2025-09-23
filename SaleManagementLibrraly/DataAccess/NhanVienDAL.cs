using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class NhanVienDAL
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
                    if (instance == null) instance = new NhanVienDAL();
                    return instance;
                }
            }
        }
        #endregion

        public IEnumerable<NhanVien> GetAll()
        {
            var listNhanVien = new List<NhanVien>();
            string SQLSelect = @"SELECT nv.MaNV, nv.HoTen, nv.NgaySinh, nv.DiaChi, nv.GioiTinh, 
                                        nv.NgayVaoLam, nv.SoDienThoai, nv.CCCD, vt.TenVaiTro
                                 FROM NhanVien nv
                                 LEFT JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV
                                 LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro";
            try
            {
                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text);
                while (reader.Read())
                {
                    listNhanVien.Add(new NhanVien
                    {
                        // SỬA LẠI CÁCH ĐỌC DỮ LIỆU
                        MaNV = Convert.ToInt32(reader["MaNV"]),
                        HoTen = Convert.ToString(reader["HoTen"]),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        DiaChi = Convert.ToString(reader["DiaChi"]),
                        GioiTinh = Convert.ToString(reader["GioiTinh"]),
                        NgayVaoLam = Convert.ToDateTime(reader["NgayVaoLam"]),
                        SoDienThoai = Convert.ToString(reader["SoDienThoai"]),
                        CCCD = Convert.ToString(reader["CCCD"]),
                        TenVaiTro = reader["TenVaiTro"] == DBNull.Value ? string.Empty : Convert.ToString(reader["TenVaiTro"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
            return listNhanVien;
        }

        public void AddNew(NhanVien nv)
        {
            try
            {
                string sqlInsert = @"INSERT INTO NhanVien (HoTen, NgaySinh, DiaChi, GioiTinh, NgayVaoLam, SoDienThoai, CCCD) 
                                     VALUES (@HoTen, @NgaySinh, @DiaChi, @GioiTinh, @NgayVaoLam, @SoDienThoai, @CCCD)";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@HoTen", 100, nv.HoTen, DbType.String),
                    StockDataProvider.CreateParameter("@NgaySinh", 0, nv.NgaySinh, DbType.Date),
                    StockDataProvider.CreateParameter("@DiaChi", 300, nv.DiaChi, DbType.String),
                    StockDataProvider.CreateParameter("@GioiTinh", 5, nv.GioiTinh, DbType.String),
                    StockDataProvider.CreateParameter("@NgayVaoLam", 0, nv.NgayVaoLam, DbType.Date),
                    StockDataProvider.CreateParameter("@SoDienThoai", 15, nv.SoDienThoai, DbType.String),
                    StockDataProvider.CreateParameter("@CCCD", 20, nv.CCCD, DbType.String)
                };
                new StockDataProvider().Insert(sqlInsert, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        public void Update(NhanVien nv)
        {
            try
            {
                string sqlUpdate = @"UPDATE NhanVien 
                                     SET HoTen=@HoTen, NgaySinh=@NgaySinh, DiaChi=@DiaChi, 
                                         GioiTinh=@GioiTinh, NgayVaoLam=@NgayVaoLam, 
                                         SoDienThoai=@SoDienThoai, CCCD=@CCCD 
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
                    StockDataProvider.CreateParameter("@CCCD", 20, nv.CCCD, DbType.String)
                };
                new StockDataProvider().Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
        }

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
        
    }
}