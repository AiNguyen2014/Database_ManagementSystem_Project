using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;

namespace SaleManagementLibrraly.DataAccess
{
    public class NhanVienDBContext : BaseDAL
    {
        private static NhanVienDBContext instance = null;
        private static readonly object instanceLock = new object();
        private NhanVienDBContext() { }
        public static NhanVienDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NhanVienDBContext();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<NhanVien> GetNhanVienByKeyword(string tuKhoa)
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select * From NhanVien Where TenNhanVien like @TenNhanVien or DiaChi like @DiaChi or DienThoai like @DienThoai";
            var parameter = new List<SqlParameter>();
            var nhanViens = new List<NhanVien>();
            try
            {
                parameter.Add(dataProvider.CreateParameter("@TenNhanVien", 50, "%" + tuKhoa + "%", DbType.String));
                parameter.Add(dataProvider.CreateParameter("@DiaChi", 50, "%" + tuKhoa + "%", DbType.String));
                parameter.Add(dataProvider.CreateParameter("@DienThoai", 50, "%" + tuKhoa + "%", DbType.String));
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameter.ToArray());
                while (dataReader.Read())
                {
                    nhanViens.Add(new NhanVien
                    {
                        MaNhanVien = dataReader.GetInt32(0),
                        TenNhanVien = dataReader.GetString(1),
                        GioiTinh = dataReader.GetBoolean(2),
                        DiaChi = dataReader.GetString(3),
                        DienThoai = dataReader.GetString(4),
                        NgaySinh = dataReader.GetDateTime(5),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return nhanViens;
        }
        public IEnumerable<NhanVien> GetNhanVienList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select * From NhanVien";
            var nhanViens = new List<NhanVien>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    nhanViens.Add(new NhanVien
                    {
                        MaNhanVien = dataReader.GetInt32(0),
                        TenNhanVien = dataReader.GetString(1),
                        GioiTinh = dataReader.GetBoolean(2),
                        DiaChi = dataReader.GetString(3),
                        DienThoai = dataReader.GetString(4),
                        NgaySinh = dataReader.GetDateTime(5),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return nhanViens;
        }
        //
        public NhanVien GetNhanVienByID(int MaNhanVien)
        {
            NhanVien nv = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select * From NhanVien Where MaNhanVien = @MaNhanVien";
            try
            {
                var param = dataProvider.CreateParameter("@MaNhanVien", 4, MaNhanVien, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    nv = new NhanVien
                    {
                        MaNhanVien = dataReader.GetInt32(0),
                        TenNhanVien = dataReader.GetString(1),
                        GioiTinh = dataReader.GetBoolean(2),
                        DiaChi = dataReader.GetString(3),
                        DienThoai = dataReader.GetString(4),
                        NgaySinh = dataReader.GetDateTime(5),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return nv;
        }
        public void AddNew(NhanVien nv)
        {
            try
            {
                NhanVien n = GetNhanVienByID(nv.MaNhanVien);
                if (n == null)
                {
                    string SQLInsert = "Insert NhanVien values(@TenNhanVien, @GioiTinh, @DiaChi, @DienThoai, @NgaySinh)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@TenNhanVien", 200, nv.TenNhanVien, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@GioiTinh", 1, nv.GioiTinh, DbType.Boolean));
                    parameters.Add(dataProvider.CreateParameter("@DiaChi", 200, nv.DiaChi, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DienThoai", 50, nv.DienThoai, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@NgaySinh", 50, nv.NgaySinh, DbType.DateTime));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                NhanVien n = GetNhanVienByID(nv.MaNhanVien);
                if (n != null)
                {
                    string SQLUpdate = "Update NhanVien set TenNhanVien = @TenNhanVien, GioiTinh = @GioiTinh, DiaChi = @DiaChi," + "DienThoai = @DienThoai, NgaySinh = @NgaySinh Where MaNhanVien = @MaNhanVien";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MaNhanVien", 4, nv.MaNhanVien, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@TenNhanVien", 50, nv.TenNhanVien, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@GioiTinh", 50, nv.GioiTinh, DbType.Boolean));
                    parameters.Add(dataProvider.CreateParameter("@DiaChi", 50, nv.DiaChi, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DienThoai", 50, nv.DienThoai, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@NgaySinh", 50, nv.NgaySinh, DbType.String));
                    dataProvider.Update(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int MaNhanVien)
        {
            try
            {
                NhanVien n = GetNhanVienByID(MaNhanVien);
                if (n != null)
                {
                    string SQLDelete = "Delete NhanVien where MaNhanVien = @MaNhanVien";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MaNhanVien", 4, MaNhanVien, DbType.Int32));
                    dataProvider.Delete(SQLDelete, CommandType.Text, parameters.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
