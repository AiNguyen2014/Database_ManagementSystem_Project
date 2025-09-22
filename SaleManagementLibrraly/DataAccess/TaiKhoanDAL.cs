using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class TaiKhoanDAL : BaseDAL
    {
        #region Singleton
        private static TaiKhoanDAL? instance = null;
        private static readonly object instanceLock = new object();
        private TaiKhoanDAL() { }
        public static TaiKhoanDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TaiKhoanDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        // =============================================================
        // HÀM KIỂM TRA ĐĂNG NHẬP
        // =============================================================
        // Sửa lại phương thức CheckLogin trong TaiKhoanDAL.cs
        public TaiKhoan CheckLogin(string tenDangNhap, string matKhau, int maVaiTro)
        {
            TaiKhoan taiKhoan = null;
            string SQLSelect = @"SELECT tk.*, vt.TenVaiTro 
                         FROM TaiKhoan tk 
                         JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                         WHERE TenDangNhap = @TenDangNhap 
                           AND MatKhau = @MatKhau 
                           AND tk.MaVaiTro = @MaVaiTro"; // Thêm điều kiện kiểm tra vai trò
            try
            {
                var parameters = new[]
                {
            StockDataProvider.CreateParameter("@TenDangNhap", 50, tenDangNhap, DbType.String),
            StockDataProvider.CreateParameter("@MatKhau", 50, matKhau, DbType.String),
            StockDataProvider.CreateParameter("@MaVaiTro", 4, maVaiTro, DbType.Int32) // Thêm parameter mới
        };

                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text, parameters);
                if (reader.Read())
                {
                    // Code map dữ liệu giữ nguyên
                    taiKhoan = new TaiKhoan
                    {
                        MaTaiKhoan = Convert.ToInt32(reader["MaTaiKhoan"]),
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        MaVaiTro = Convert.ToInt32(reader["MaVaiTro"]),
                        TenVaiTro = reader["TenVaiTro"].ToString(),
                        MaNV = reader["MaNV"] == DBNull.Value ? null : Convert.ToInt32(reader["MaNV"]),
                        MaKH = reader["MaKH"] == DBNull.Value ? null : Convert.ToInt32(reader["MaKH"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
            return taiKhoan;
        }

        // =============================================================
        // LẤY TÀI KHOẢN THEO TÊN ĐĂNG NHẬP
        // =============================================================
        public TaiKhoan? GetByTenDangNhap(string tenDangNhap)
        {
            TaiKhoan? tk = null;
            string SQLSelect = @"SELECT MaTaiKhoan, TenDangNhap 
                                 FROM TaiKhoan 
                                 WHERE TenDangNhap = @TenDangNhap";
            try
            {
                var param = StockDataProvider.CreateParameter("@TenDangNhap", 50, tenDangNhap, DbType.String);

                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text, param);
                if (reader.Read())
                {
                    tk = new TaiKhoan
                    {
                        MaTaiKhoan = reader.GetInt32(0),
                        TenDangNhap = reader.GetString(1)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm tài khoản: " + ex.Message);
            }
            return tk;
        }

        // =============================================================
        // LẤY DANH SÁCH TÀI KHOẢN
        // =============================================================
        public IEnumerable<TaiKhoan> GetAll()
        {
            var taiKhoanList = new List<TaiKhoan>();
            string SQLSelect = @"SELECT tk.*, vt.TenVaiTro 
                                 FROM TaiKhoan tk 
                                 LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro";
            try
            {
                using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text);
                while (reader.Read())
                {
                    taiKhoanList.Add(new TaiKhoan
                    {
                        MaTaiKhoan = Convert.ToInt32(reader["MaTaiKhoan"]),
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        MaVaiTro = reader["MaVaiTro"] == DBNull.Value ? null : Convert.ToInt32(reader["MaVaiTro"]),
                        TenVaiTro = reader["TenVaiTro"].ToString(),
                        MaNV = reader["MaNV"] == DBNull.Value ? null : Convert.ToInt32(reader["MaNV"]),
                        MaKH = reader["MaKH"] == DBNull.Value ? null : Convert.ToInt32(reader["MaKH"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }
            return taiKhoanList;
        }

        // =============================================================
        // THÊM MỚI
        // =============================================================
        public void AddNew(TaiKhoan taiKhoan)
        {
            try
            {
                string sqlInsert = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaVaiTro, MaNV, MaKH) 
                                     VALUES (@TenDangNhap, @MatKhau, @MaVaiTro, @MaNV, @MaKH)";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@TenDangNhap", 50, taiKhoan.TenDangNhap, DbType.String),
                    StockDataProvider.CreateParameter("@MatKhau", 50, taiKhoan.MatKhau, DbType.String),
                    StockDataProvider.CreateParameter("@MaVaiTro", 4, taiKhoan.MaVaiTro ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaNV", 4, taiKhoan.MaNV ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaKH", 4, taiKhoan.MaKH ?? (object)DBNull.Value, DbType.Int32)
                };

                dataProvider.ExecuteNonQuery(sqlInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm tài khoản mới: " + ex.Message);
            }
        }


        // =============================================================
        // CẬP NHẬT
        // =============================================================
        public void Update(TaiKhoan taiKhoan)
        {
            try
            {
                string sqlUpdate = @"UPDATE TaiKhoan 
                                     SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, MaVaiTro = @MaVaiTro, MaNV = @MaNV, MaKH = @MaKH 
                                     WHERE MaTaiKhoan = @MaTaiKhoan";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaTaiKhoan", 4, taiKhoan.MaTaiKhoan, DbType.Int32),
                    StockDataProvider.CreateParameter("@TenDangNhap", 50, taiKhoan.TenDangNhap, DbType.String),
                    StockDataProvider.CreateParameter("@MatKhau", 50, taiKhoan.MatKhau, DbType.String),
                    StockDataProvider.CreateParameter("@MaVaiTro", 4, taiKhoan.MaVaiTro ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaNV", 4, taiKhoan.MaNV ?? (object)DBNull.Value, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaKH", 4, taiKhoan.MaKH ?? (object)DBNull.Value, DbType.Int32)
                };

                new StockDataProvider().Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }

        // =============================================================
        // XÓA
        // =============================================================
        public void Delete(int maTaiKhoan)
        {
            try
            {
                string sqlDelete = "DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
                var param = StockDataProvider.CreateParameter("@MaTaiKhoan", 4, maTaiKhoan, DbType.Int32);
                new StockDataProvider().Delete(sqlDelete, CommandType.Text, param);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        // =============================================================
        // ĐỔI MẬT KHẨU
        // =============================================================
        public void ChangePassword(string tenDangNhap, string matKhauMoi)
        {
            try
            {
                string sqlCommand = "sp_TaiKhoan_ChangePassword"; // Stored procedure
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@TenDangNhap", 50, tenDangNhap, DbType.String),
                    StockDataProvider.CreateParameter("@MatKhauMoi", 50, matKhauMoi, DbType.String)
                };

                new StockDataProvider().Update(sqlCommand, CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }
    }
}