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
    public class HangHoaDBContext : BaseDAL
    {
        private static HangHoaDBContext instance = null;
        private static readonly object instanceLock = new object();
        private HangHoaDBContext() { }
        public static HangHoaDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HangHoaDBContext();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<HangHoa> GetHangHoaByKeyword(string tuKhoa)
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select * From HangHoa Where TenHangHoa like @TenHangHoa";
            var parameter = new List<SqlParameter>();
            var hangHoas = new List<HangHoa>();
            try
            {
                parameter.Add(dataProvider.CreateParameter("@TenHangHoa", 200, "%" + tuKhoa + "%", DbType.String));
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameter.ToArray());
                while (dataReader.Read())
                {
                    hangHoas.Add(new HangHoa
                    {
                        MaHangHoa = dataReader.GetInt32(0),
                        TenHangHoa = dataReader.GetString(1),
                        SoLuong = dataReader.GetInt32(2),
                        DonGiaNhap = dataReader.GetDecimal(3),
                        DonGiaBan = dataReader.GetDecimal(4),
                        Anh = dataReader.GetString(5),
                        GhiChu = dataReader.GetString(6),
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
            return hangHoas;
        }
        public IEnumerable<HangHoa> GetHangHoaList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select * From HangHoa";
            var hangHoas = new List<HangHoa>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    hangHoas.Add(new HangHoa
                    {
                        MaHangHoa = dataReader.GetInt32(0),
                        TenHangHoa = dataReader.GetString(1),
                        SoLuong = dataReader.GetInt32(2),
                        DonGiaNhap = dataReader.GetDecimal(3),
                        DonGiaBan = dataReader.GetDecimal(4),
                        Anh = dataReader.GetString(5),
                        GhiChu = dataReader.GetString(6),
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
            return hangHoas;
        }
        //
        public HangHoa GetHangHoaByID(int hangHoaID)
        {
            HangHoa hh = null;
            IDataReader reader = null;
            string sql = "Select * from HangHoa where MaHangHoa= @MaHangHoa";
            try
            {
                var param = dataProvider.CreateParameter("@MaHangHoa", 4, hangHoaID, DbType.Int32);
                reader = dataProvider.GetDataReader(sql, CommandType.Text, out connection, param);
                if (reader.Read())
                {
                    hh = new HangHoa
                    {
                        MaHangHoa = reader.GetInt32(0),
                        TenHangHoa = reader.GetString(1),
                        SoLuong = reader.GetInt32(2),
                        DonGiaNhap = reader.GetDecimal(3),
                        DonGiaBan = reader.GetDecimal(4),
                        Anh = reader.GetString(5),
                        GhiChu = reader.GetString(6),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                CloseConnection();
            }
            return hh;
        }
        public void AddNew(HangHoa hh)
        {
            try
            {
                HangHoa h = GetHangHoaByID(hh.MaHangHoa);
                if (h == null)
                {
                    string SQLInsert = "Insert HangHoa values(@TenHangHoa, @SoLuong, @DonGiaNhap, @DonGiaBan, @Anh, @GhiChu)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@TenHangHoa", 200, hh.TenHangHoa, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@SoLuong", 4, hh.SoLuong, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DonGiaNhap", 10, hh.DonGiaNhap, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@DonGiaBan", 10, hh.DonGiaBan, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@Anh", 50, hh.Anh, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@GhiChu", 500, hh.GhiChu, DbType.String));
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
        public void Update(HangHoa hh)
        {
            try
            {
                HangHoa h = GetHangHoaByID(hh.MaHangHoa);
                if (h != null)
                {
                    string SQLUpdate = "UPDATE HangHoa set TenHangHoa=@TenHangHoa, SoLuong=@SoLuong, DonGiaNhap=@DonGiaNhap, DonGiaBan=@DonGiaBan, Anh=@Anh, GhiChu=@GhiChu where MaHangHoa=@MaHangHoa"; var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MaHangHoa", 4, hh.MaHangHoa, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@TenHangHoa", 200, hh.TenHangHoa, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@SoLuong", 4, hh.SoLuong, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DonGiaNhap", 10, hh.DonGiaNhap, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@DonGiaBan", 10, hh.DonGiaBan, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@Anh", 50, hh.Anh, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@GhiChu", 500, hh.GhiChu, DbType.String));
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
        public void Delete(int hangHoaID)
        {
            try
            {
                HangHoa h = GetHangHoaByID(hangHoaID);
                if (h != null)
                {
                    string SQLDelete = "Delete HangHoa where MaHangHoa = @MaHangHoa";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MaHangHoa", 4, hangHoaID, DbType.Int32));
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
