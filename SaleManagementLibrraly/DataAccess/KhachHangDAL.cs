using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class KhachHangDAL : BaseDAL
    {
        private static KhachHangDAL instance = null;
        private static readonly object instanceLock = new object();
        private KhachHangDAL() { }
        public static KhachHangDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new KhachHangDAL();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả khách hàng
        /// </summary>
        public IEnumerable<KhachHang> GetAll()
        {
            IDataReader dataReader = null;
            var listKhachHang = new List<KhachHang>();
            string SQLSelect = "SELECT MaKH, Hoten, DiaChi, GioiTinh, SoDienThoai FROM KhachHang";

            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    listKhachHang.Add(new KhachHang
                    {
                        MaKH = dataReader.GetInt32(0),
                        Hoten = dataReader.GetString(1),
                        DiaChi = dataReader.GetString(2),
                        GioiTinh = dataReader.GetString(3),
                        SoDienThoai = dataReader.GetString(4)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return listKhachHang;
        }

        /// <summary>
        /// Tìm một khách hàng dựa trên số điện thoại
        /// </summary>
        public KhachHang GetBySoDienThoai(string soDienThoai)
        {
            KhachHang kh = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT MaKH, Hoten, DiaChi, GioiTinh, SoDienThoai FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
            try
            {
                var param = dataProvider.CreateParameter("@SoDienThoai", 20, soDienThoai, DbType.String);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    kh = new KhachHang
                    {
                        MaKH = dataReader.GetInt32(0),
                        Hoten = dataReader.GetString(1),
                        DiaChi = dataReader.GetString(2),
                        GioiTinh = dataReader.GetString(3),
                        SoDienThoai = dataReader.GetString(4)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm khách hàng bằng SĐT: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return kh;
        }

        /// <summary>
        /// Thêm mới khách hàng và trả về MaKH
        /// </summary>
        public int AddNew(KhachHang kh)
        {
            try
            {
                string sqlInsert = "INSERT INTO KhachHang (Hoten, DiaChi, GioiTinh, SoDienThoai) VALUES (@Hoten, @DiaChi, @GioiTinh, @SoDienThoai); SELECT SCOPE_IDENTITY();";
                var parameters = new List<SqlParameter>
                {
                    dataProvider.CreateParameter("@Hoten", 100, kh.Hoten, DbType.String),
                    dataProvider.CreateParameter("@DiaChi", 255, kh.DiaChi, DbType.String),
                    dataProvider.CreateParameter("@GioiTinh", 10, kh.GioiTinh, DbType.String),
                    dataProvider.CreateParameter("@SoDienThoai", 20, kh.SoDienThoai, DbType.String)
                };

                object newId = dataProvider.ExecuteScalar(sqlInsert, CommandType.Text, parameters.ToArray());
                return Convert.ToInt32(newId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        public void Update(KhachHang kh)
        {
            try
            {
                string sqlUpdate = "UPDATE KhachHang SET Hoten = @Hoten, DiaChi = @DiaChi, GioiTinh = @GioiTinh, SoDienThoai = @SoDienThoai WHERE MaKH = @MaKH";
                var parameters = new List<SqlParameter>
                {
                    dataProvider.CreateParameter("@MaKH", 4, kh.MaKH, DbType.Int32),
                    dataProvider.CreateParameter("@Hoten", 100, kh.Hoten, DbType.String),
                    dataProvider.CreateParameter("@DiaChi", 255, kh.DiaChi, DbType.String),
                    dataProvider.CreateParameter("@GioiTinh", 10, kh.GioiTinh, DbType.String),
                    dataProvider.CreateParameter("@SoDienThoai", 20, kh.SoDienThoai, DbType.String)
                };

                dataProvider.Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        public void Delete(int maKH)
        {
            try
            {
                string sqlDelete = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                var param = dataProvider.CreateParameter("@MaKH", 4, maKH, DbType.Int32);
                dataProvider.Delete(sqlDelete, CommandType.Text, param);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


    }
}