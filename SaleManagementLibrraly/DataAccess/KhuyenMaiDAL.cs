using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SaleManagementLibrraly.DataAccess
{
    public class KhuyenMaiDAL : BaseDAL
    {
        private static KhuyenMaiDAL instance = null;
        private static readonly object instanceLock = new object();

        private KhuyenMaiDAL() { }

        public static KhuyenMaiDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new KhuyenMaiDAL();
                    }
                    return instance;
                }
            }
        }

        private IEnumerable<KhuyenMai> GetKhuyenMaiListFromDataReader(IDataReader reader)
        {
            var khuyenMaiList = new List<KhuyenMai>();
            while (reader.Read())
            {
                khuyenMaiList.Add(new KhuyenMai
                {
                    MaKM = reader.GetInt32(reader.GetOrdinal("MaKM")),
                    TenKM = reader.GetString(reader.GetOrdinal("TenKM")),
                    MaHT = reader.GetInt32(reader.GetOrdinal("MaHT")),
                    NgayBD = reader.GetDateTime(reader.GetOrdinal("NgayBD")),
                    NgayKT = reader.GetDateTime(reader.GetOrdinal("NgayKT")),
                    DieuKien = reader.IsDBNull(reader.GetOrdinal("DieuKien")) ? null : reader.GetString(reader.GetOrdinal("DieuKien"))
                });
            }
            return khuyenMaiList;
        }

        public IEnumerable<KhuyenMai> GetAll()
        {
            string SQL = "SELECT MaKM, TenKM, MaHT, NgayBD, NgayKT, DieuKien FROM KhuyenMai";
            try
            {
                var provider = new StockDataProvider();
                var reader = provider.GetDataReader(SQL, CommandType.Text, null);
                return GetKhuyenMaiListFromDataReader(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khuyến mãi: " + ex.Message, ex);
            }
        }

        public KhuyenMai GetByMaKM(int maKM)
        {
            string SQL = "SELECT MaKM, TenKM, MaHT, NgayBD, NgayKT, DieuKien FROM KhuyenMai WHERE MaKM = @MaKM";
            try
            {
                var provider = new StockDataProvider();
                var parameter = StockDataProvider.CreateParameter("@MaKM", 4, maKM, DbType.Int32);
                var reader = provider.GetDataReader(SQL, CommandType.Text, parameter);
                var result = GetKhuyenMaiListFromDataReader(reader);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy khuyến mãi theo mã: " + ex.Message, ex);
            }
        }
        public List<KhuyenMai> GetApDungKhuyenMai(int maSP, int soLuong, DateTime ngayLap)
        {
            try
            {
                string sql = @"
            SELECT
                km.MaKM,
                km.TenKM,
                km.LoaiKhuyenMai,
                km.NgayBD,
                km.NgayKT,
                km.DK_SoLuong,
                km.UD_SoLuong,
                km.UD_PhanTramGiam,
                km.UD_GiaTriGiam
            FROM KhuyenMai km
            INNER JOIN ChiTietKhuyenMai ctkm ON km.MaKM = ctkm.MaKM
            WHERE
                km.NgayBD <= @NgayLap AND km.NgayKT >= @NgayLap
                AND ctkm.MaSP = @MaSP
                -- This is the crucial fix: include promotions with no quantity condition (DK_SoLuong IS NULL)
                AND (km.DK_SoLuong IS NULL OR km.DK_SoLuong <= @SoLuong)";

                var parameters = new List<SqlParameter>
        {
            StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32),
            StockDataProvider.CreateParameter("@SoLuong", 4, soLuong, DbType.Int32),
            StockDataProvider.CreateParameter("@NgayLap", 0, ngayLap, DbType.DateTime)
        };

                var khuyenMaiList = new List<KhuyenMai>();
                using (var reader = dataProvider.GetDataReader(sql, CommandType.Text, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        khuyenMaiList.Add(new KhuyenMai
                        {
                            MaKM = reader.GetInt32(reader.GetOrdinal("MaKM")),
                            TenKM = reader["TenKM"].ToString(),
                            LoaiKhuyenMai = reader["LoaiKhuyenMai"].ToString(),
                            NgayBD = reader.GetDateTime(reader.GetOrdinal("NgayBD")),
                            NgayKT = reader.GetDateTime(reader.GetOrdinal("NgayKT")),
                            DK_SoLuong = reader.IsDBNull(reader.GetOrdinal("DK_SoLuong")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DK_SoLuong")),
                            UD_SoLuong = reader.IsDBNull(reader.GetOrdinal("UD_SoLuong")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("UD_SoLuong")),
                            UD_PhanTramGiam = reader.IsDBNull(reader.GetOrdinal("UD_PhanTramGiam")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("UD_PhanTramGiam")),
                            UD_GiaTriGiam = reader.IsDBNull(reader.GetOrdinal("UD_GiaTriGiam")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("UD_GiaTriGiam"))
                        });
                    }
                }
                return khuyenMaiList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy khuyến mãi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void AddNew(KhuyenMai km)
        {
            string SQL = "INSERT INTO KhuyenMai (MaKM, TenKM, MaHT, NgayBD, NgayKT, DieuKien) VALUES (@MaKM, @TenKM, @MaHT, @NgayBD, @NgayKT, @DieuKien)";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@MaKM", 4, km.MaKM, DbType.Int32),
                    StockDataProvider.CreateParameter("@TenKM", 50, km.TenKM, DbType.String),
                    StockDataProvider.CreateParameter("@MaHT", 4, km.MaHT, DbType.Int32),
                    StockDataProvider.CreateParameter("@NgayBD", 8, km.NgayBD, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKT", 8, km.NgayKT, DbType.Date),
                    StockDataProvider.CreateParameter("@DieuKien", 200, km.DieuKien, DbType.String)
                };
                provider.Insert(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khuyến mãi mới: " + ex.Message, ex);
            }
        }

        public void Update(KhuyenMai km)
        {
            string SQL = "UPDATE KhuyenMai SET TenKM = @TenKM, MaHT = @MaHT, NgayBD = @NgayBD, NgayKT = @NgayKT, DieuKien = @DieuKien WHERE MaKM = @MaKM";
            try
            {
                var provider = new StockDataProvider();
                var parameters = new SqlParameter[]
                {
                    StockDataProvider.CreateParameter("@TenKM", 50, km.TenKM, DbType.String),
                    StockDataProvider.CreateParameter("@MaHT", 4, km.MaHT, DbType.Int32),
                    StockDataProvider.CreateParameter("@NgayBD", 8, km.NgayBD, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKT", 8, km.NgayKT, DbType.Date),
                    StockDataProvider.CreateParameter("@DieuKien", 200, km.DieuKien, DbType.String),
                    StockDataProvider.CreateParameter("@MaKM", 4, km.MaKM, DbType.Int32)
                };
                provider.Update(SQL, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khuyến mãi: " + ex.Message, ex);
            }
        }

        public void Delete(int maKM)
        {
            string SQL = "DELETE FROM KhuyenMai WHERE MaKM = @MaKM";
            try
            {
                var provider = new StockDataProvider();
                var parameter = StockDataProvider.CreateParameter("@MaKM", 4, maKM, DbType.Int32);
                provider.Delete(SQL, CommandType.Text, parameter);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khuyến mãi: " + ex.Message, ex);
            }
        }
    }
}