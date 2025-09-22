using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class ChiTietHoaDonDAL : BaseDAL
    {
        #region Singleton
        private static ChiTietHoaDonDAL instance = null;
        private static readonly object instanceLock = new object();
        private ChiTietHoaDonDAL() { }
        public static ChiTietHoaDonDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ChiTietHoaDonDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        // Hàm để thêm một dòng chi tiết vào hóa đơn bằng stored procedure
        public void AddNew(ChiTietHoaDon cthd)
        {
            try
            {
                string procedureName = "sp_ThemChiTietHoaDon";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaHD", 0, cthd.MaHD, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 0, cthd.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@SoLuong", 0, cthd.SoLuong, DbType.Int32)
                };
                // Gọi stored procedure thay vì INSERT trực tiếp
                dataProvider.Insert(procedureName, CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Hàm mới để lấy danh sách chi tiết hóa đơn từ view
        public List<ChiTietHoaDon> GetChiTietHoaDonByMaHD(int maHD)
        {
            try
            {
                string sql = "SELECT * FROM vw_ChiTietHoaDonDayDu WHERE MaHD = @MaHD";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaHD", 4, maHD, DbType.Int32)
                };

                var chiTietList = new List<ChiTietHoaDon>();
                using (var reader = dataProvider.GetDataReader(sql, CommandType.Text, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        chiTietList.Add(new ChiTietHoaDon
                        {
                            MaCTHD = reader.GetInt32(reader.GetOrdinal("MaCTHD")),
                            MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                            MaSP = reader.GetInt32(reader.GetOrdinal("MaSP")),
                            SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                            DonGia = reader.GetDecimal(reader.GetOrdinal("DonGia")),
                            ThanhTienSauGiam = reader.GetDecimal(reader.GetOrdinal("ThanhTienSauGiam")),
                            NgayLap = reader.GetDateTime(reader.GetOrdinal("NgayLap")),
                            TenKH = reader["TenKH"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            TenSanPham = reader["TenSanPham"].ToString(),
                            GiamGia = reader["GiamGia"] != DBNull.Value ? (decimal?)reader.GetDecimal(reader.GetOrdinal("GiamGia")) : 0,
                            TongTien = reader["TongTien"] != DBNull.Value ? (decimal?)reader.GetDecimal(reader.GetOrdinal("TongTien")) : 0
                        });
                    }
                }
                return chiTietList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public SanPhamKhuyenMai GetSanPhamKhuyenMai(int maSP)
        {
            try
            {
                string sql = "SELECT TenSP, GiaBan, GiaTriGiam, GiaSauGiam FROM vw_SanPhamKhuyenMai WHERE MaSP = @MaSP";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32)
                };

                using (var reader = dataProvider.GetDataReader(sql, CommandType.Text, parameters.ToArray()))
                {
                    if (reader.Read())
                    {
                        return new SanPhamKhuyenMai
                        {
                            MaSP = maSP,
                            TenSP = reader["TenSP"].ToString(),
                            GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                            GiaTriGiam = Convert.ToDecimal(reader["GiaTriGiam"]),
                            GiaSauGiam = Convert.ToDecimal(reader["GiaSauGiam"])
                        };
                    }
                    return null; // Trả về null nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin sản phẩm khuyến mãi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}