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
    public class KhachHangDBContext : BaseDAL
    {
        private static KhachHangDBContext instance = null;
        private static readonly object instanceLock = new object();
        private KhachHangDBContext() { }
        public static KhachHangDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new KhachHangDBContext();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<KhachHang> GetKhachHangByKeyword(string tuKhoa)
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select * From KhachHang Where TenKhach like @TenKhach or DiaChi like @DiaChi";
            var parameter = new List<SqlParameter>();
            var khachHangs = new List<KhachHang>();
            try
            {
                parameter.Add(dataProvider.CreateParameter("@TenKhach", 200, "%" + tuKhoa + "%", DbType.String));
                parameter.Add(dataProvider.CreateParameter("@DiaChi", 200, "%" + tuKhoa + "%", DbType.String));
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameter.ToArray());
                while (dataReader.Read())
                {
                    khachHangs.Add(new KhachHang
                    {
                        MaKhach = dataReader.GetInt32(0),
                        TenKhach = dataReader.GetString(1),
                        DiaChi = dataReader.GetString(2),
                        DienThoai = dataReader.GetString(3)
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
            return khachHangs;
        }
        public IEnumerable<KhachHang> GetKhachHangList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select MaKhach, TenKhach, DiaChi, DienThoai From KhachHang";
            var khachHangs = new List<KhachHang>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    khachHangs.Add(new KhachHang
                    {
                        MaKhach = dataReader.GetInt32(0),
                        TenKhach = dataReader.GetString(1),
                        DiaChi = dataReader.GetString(2),
                        DienThoai = dataReader.GetString(3)
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
            return khachHangs;
        }
        //
        public KhachHang GetKhachHangByID(int MaKhach)
        {
            KhachHang kh = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select MaKhach, TenKhach, DiaChi, DienThoai" + " From KhachHang Where MaKhach = @MaKhach";
            try
            {
                var param = dataProvider.CreateParameter("@MaKhach", 4, MaKhach, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    kh = new KhachHang
                    {
                        MaKhach = dataReader.GetInt32(0),
                        TenKhach = dataReader.GetString(1),
                        DiaChi = dataReader.GetString(2),
                        DienThoai = dataReader.GetString(3)
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
            return kh;
        }
        public void AddNew(KhachHang kh)
        {
            try
            {
                KhachHang k = GetKhachHangByID(kh.MaKhach);
                if (k == null)
                {
                    string SQLInsert = "Insert KhachHang values(@TenKhach, @DiaChi, @DienThoai)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@TenKhach", 200, kh.TenKhach, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DiaChi", 200, kh.DiaChi, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DienThoai", 50, kh.DienThoai, DbType.String));
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
        public void Update(KhachHang kh)
        {
            try
            {
                KhachHang k = GetKhachHangByID(kh.MaKhach);
                if (k != null)
                {
                    string SQLUpdate = "Update KhachHang set TenKhach = @TenKhach, DiaChi = @DiaChi," + "DienThoai = @DienThoai Where MaKhach = @MaKhach";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MaKhach", 4, kh.MaKhach, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@TenKhach", 50, kh.TenKhach, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DiaChi", 50, kh.DiaChi, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DienThoai", 50, kh.DienThoai, DbType.String));
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
        public void Delete(int MaKhach)
        {
            try
            {
                KhachHang k = GetKhachHangByID(MaKhach);
                if (k != null)
                {
                    string SQLDelete = "Delete KhachHang where MaKhach = @MaKhach";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MaKhach", 4, MaKhach, DbType.Int32));
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
