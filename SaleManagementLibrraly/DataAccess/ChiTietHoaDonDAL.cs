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

        /// <summary>
        /// Thêm một dòng chi tiết vào hóa đơn. Phương thức này đã đúng và không cần sửa.
        /// </summary>
        public void AddNew(ChiTietHoaDon cthd)
        {
            try
            {
                string procedureName = "sp_ThemChiTietHoaDon";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaHD", 0, cthd.MaHD, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 0, cthd.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@SoLuong", 0, cthd.SoLuong, DbType.Int32),
                };
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

        /// <summary>
        /// Lấy danh sách chi tiết hóa đơn từ view.
        /// </summary>
        public List<ChiTietHoaDon> GetChiTietHoaDonByMaHD(int maHD)
        {
            try
            {
                // SỬA LỖI Ở ĐÂY: Chỉ SELECT các cột có trong lớp ChiTietHoaDon.cs
                string sql = "SELECT MaCTHD, MaHD, MaSP, SoLuong, DonGia, ThanhTien, TenSanPham FROM vw_ChiTietHoaDonDayDu WHERE MaHD = @MaHD";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaHD", 4, maHD, DbType.Int32)
                };

                var chiTietList = new List<ChiTietHoaDon>();
                using (var reader = dataProvider.GetDataReader(sql, CommandType.Text, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        // SỬA LỖI Ở ĐÂY: Chỉ gán các thuộc tính tồn tại trong lớp ChiTietHoaDon
                        chiTietList.Add(new ChiTietHoaDon
                        {
                            MaCTHD = reader.GetInt32(reader.GetOrdinal("MaCTHD")),
                            MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                            MaSP = reader.GetInt32(reader.GetOrdinal("MaSP")),
                            SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                            DonGia = reader.GetDecimal(reader.GetOrdinal("DonGia")),
                            ThanhTien = reader.GetDecimal(reader.GetOrdinal("ThanhTien")),
                            TenSanPham = reader["TenSanPham"].ToString()
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
    }
}