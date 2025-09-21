using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.DataAccess
{
    public class NhanVienDAL : BaseDAL
    {
        #region Singleton
        private static NhanVienDAL instance = null;
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

        public IEnumerable<NhanVien> GetAll()
        {
            IDataReader dataReader = null;
            var listNhanVien = new List<NhanVien>();
            string SQLSelect = "SELECT MaNV, HoTen, NgaySinh, DiaChi, GioiTinh, NgayVaoLam, SoDienThoai, ChucVu, CCCD FROM NhanVien";

            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    listNhanVien.Add(new NhanVien
                    {
                        MaNV = dataReader.GetInt32(0),
                        HoTen = dataReader.GetString(1),
                        NgaySinh = dataReader.GetDateTime(2),
                        DiaChi = dataReader.GetString(3),
                        GioiTinh = dataReader.GetString(4),
                        NgayVaoLam = dataReader.GetDateTime(5),
                        SoDienThoai = dataReader.GetString(6),
                        ChucVu = dataReader.GetString(7),
                        CCCD = dataReader.GetString(8)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return listNhanVien;
        }

        public void AddNew(NhanVien nv)
        {
            try
            {
                // Câu lệnh INSERT phải liệt kê rõ các cột để tránh lỗi khi cấu trúc bảng thay đổi
                string sqlInsert = "INSERT INTO NhanVien (HoTen, NgaySinh, DiaChi, GioiTinh, NgayVaoLam, SoDienThoai, ChucVu, CCCD) VALUES (@HoTen, @NgaySinh, @DiaChi, @GioiTinh, @NgayVaoLam, @SoDienThoai, @ChucVu, @CCCD)";
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
                dataProvider.Insert(sqlInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(NhanVien nv)
        {
            try
            {
                string sqlUpdate = "UPDATE NhanVien SET HoTen=@HoTen, NgaySinh=@NgaySinh, DiaChi=@DiaChi, GioiTinh=@GioiTinh, NgayVaoLam=@NgayVaoLam, SoDienThoai=@SoDienThoai, ChucVu=@ChucVu, CCCD=@CCCD WHERE MaNV = @MaNV";
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
                dataProvider.Update(sqlUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int maNV)
        {
            try
            {
                string sqlDelete = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                var param = StockDataProvider.CreateParameter("@MaNV", 4, maNV, DbType.Int32);
                dataProvider.Delete(sqlDelete, CommandType.Text, param);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
