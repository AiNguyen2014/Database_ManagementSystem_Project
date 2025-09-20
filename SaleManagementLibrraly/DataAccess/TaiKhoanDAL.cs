using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class TaiKhoanDAL : BaseDAL
    {
        private static TaiKhoanDAL instance = null;
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

        // Hàm kiểm tra đăng nhập
        public TaiKhoan CheckLogin(string tenDangNhap, string matKhau)
        {
            TaiKhoan taiKhoan = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, MaNV, MaKH FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@TenDangNhap", 50, tenDangNhap, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@MatKhau", 50, matKhau, DbType.String));

                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameters.ToArray());
                if (dataReader.Read())
                {
                    taiKhoan = new TaiKhoan
                    {
                        MaTaiKhoan = Convert.ToInt32(dataReader["MaTaiKhoan"]),
                        TenDangNhap = dataReader["TenDangNhap"].ToString(),
                        MatKhau = dataReader["MatKhau"].ToString(),
                        VaiTro = dataReader["VaiTro"].ToString(),
                        MaNV = dataReader["MaNV"] == DBNull.Value ? null : Convert.ToInt32(dataReader["MaNV"]),
                        MaKH = dataReader["MaKH"] == DBNull.Value ? null : Convert.ToInt32(dataReader["MaKH"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return taiKhoan;
        }

        /// <summary>
        /// Tìm một tài khoản dựa trên Tên đăng nhập. Trả về null nếu không tìm thấy.
        /// </summary>
        public TaiKhoan GetByTenDangNhap(string tenDangNhap)
        {
            TaiKhoan tk = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT MaTaiKhoan, TenDangNhap FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            try
            {
                var param = dataProvider.CreateParameter("@TenDangNhap", 50, tenDangNhap, DbType.String);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    tk = new TaiKhoan
                    {
                        MaTaiKhoan = dataReader.GetInt32(0),
                        TenDangNhap = dataReader.GetString(1)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm tài khoản bằng Tên đăng nhập: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return tk;
        }

        // Lấy danh sách tất cả tài khoản
        public IEnumerable<TaiKhoan> GetAll()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, MaNV, MaKH FROM TaiKhoan";
            var taiKhoanList = new List<TaiKhoan>();

            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    taiKhoanList.Add(new TaiKhoan
                    {
                        MaTaiKhoan = Convert.ToInt32(dataReader["MaTaiKhoan"]),
                        TenDangNhap = dataReader["TenDangNhap"].ToString(),
                        MatKhau = dataReader["MatKhau"].ToString(),
                        VaiTro = dataReader["VaiTro"].ToString(),
                        MaNV = dataReader["MaNV"] == DBNull.Value ? null : Convert.ToInt32(dataReader["MaNV"]),
                        MaKH = dataReader["MaKH"] == DBNull.Value ? null : Convert.ToInt32(dataReader["MaKH"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return taiKhoanList;
        }

        // Thêm một tài khoản mới
        public void AddNew(TaiKhoan taiKhoan)
        {
            try
            {
                // Giả định TenDangNhap là duy nhất và đã được kiểm tra trước khi gọi hàm này
                string sqlInsert = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, MaNV, MaKH) VALUES (@TenDangNhap, @MatKhau, @VaiTro, @MaNV, @MaKH)";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@TenDangNhap", 50, taiKhoan.TenDangNhap, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@MatKhau", 50, taiKhoan.MatKhau, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@VaiTro", 50, taiKhoan.VaiTro, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@MaNV", 4, taiKhoan.MaNV ?? (object)DBNull.Value, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@MaKH", 4, taiKhoan.MaKH ?? (object)DBNull.Value, DbType.Int32));

                dataProvider.Insert(sqlInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm tài khoản mới: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Cập nhật tài khoản
        public void Update(TaiKhoan taiKhoan)
        {
            try
            {
                string sqlUpdate = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, VaiTro = @VaiTro, MaNV = @MaNV, MaKH = @MaKH WHERE MaTaiKhoan = @MaTaiKhoan";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@MaTaiKhoan", 4, taiKhoan.MaTaiKhoan, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@TenDangNhap", 50, taiKhoan.TenDangNhap, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@MatKhau", 50, taiKhoan.MatKhau, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@VaiTro", 50, taiKhoan.VaiTro, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@MaNV", 4, taiKhoan.MaNV ?? (object)DBNull.Value, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@MaKH", 4, taiKhoan.MaKH ?? (object)DBNull.Value, DbType.Int32));

                dataProvider.Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Xóa tài khoản
        public void Delete(int maTaiKhoan)
        {
            try
            {
                string sqlDelete = "DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
                var param = dataProvider.CreateParameter("@MaTaiKhoan", 4, maTaiKhoan, DbType.Int32);
                dataProvider.Delete(sqlDelete, CommandType.Text, param);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa tài khoản: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}