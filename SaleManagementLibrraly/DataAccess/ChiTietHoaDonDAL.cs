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
                // Tính ThanhTien gốc
                decimal thanhTienGoc = (decimal)cthd.SoLuong * (decimal)cthd.DonGia;
                cthd.ThanhTien = thanhTienGoc;

                // Lấy danh sách khuyến mãi áp dụng (giả sử có KhuyenMaiDAL)
                var khuyenMaiList = KhuyenMaiDAL.Instance.GetApDungKhuyenMai(cthd.MaSP ?? 0, cthd.SoLuong ?? 0, DateTime.Now);

                /// Khởi tạo mức giảm giá cao nhất
                decimal maxGiamGia = 0;

                // Vòng lặp để tìm mức giảm giá cao nhất
                foreach (var km in khuyenMaiList)
                {
                    decimal giamGiaTemp = TinhGiamGia(km, thanhTienGoc, cthd.SoLuong ?? 0, (decimal)cthd.DonGia);

                    // So sánh và cập nhật mức giảm giá cao nhất
                    if (giamGiaTemp > maxGiamGia)
                    {
                        maxGiamGia = giamGiaTemp;
                    }
                }

                // Áp dụng giảm giá
                cthd.GiamGia = maxGiamGia;
                cthd.ThanhTienSauGiam = thanhTienGoc - maxGiamGia;

                // Chuẩn bị tham số cho stored procedure
                string procedureName = "sp_ThemChiTietHoaDon";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaHD", 0, cthd.MaHD, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 0, cthd.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@SoLuong", 0, cthd.SoLuong, DbType.Int32),
                    
                };

                // Gọi stored procedure
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

        // Hàm tính giảm giá
        private decimal TinhGiamGia(KhuyenMai km, decimal thanhTienGoc, int soLuong, decimal donGia)
        {
            if (km == null || string.IsNullOrEmpty(km.LoaiKhuyenMai)) return 0;
            switch (km.LoaiKhuyenMai)
            {
                case "GIAM_TIEN_SP":
                    return km.UD_GiaTriGiam ?? 0;
                case "GIAM_PHAN_TRAM_SP":
                    return thanhTienGoc * (km.UD_PhanTramGiam ?? 0) / 100;
                case "MUA_X_TANG_Y":
                    // Lấy số lượng sản phẩm được tặng
                    int soLuongTang = (soLuong / (km.DK_SoLuong ?? 1)) * (km.UD_SoLuong ?? 0);
                    // Giá trị giảm là số lượng tặng nhân với đơn giá
                    return soLuongTang * donGia;
                default:
                    return 0;
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
                string sql = @"
            SELECT TenSP, GiaBan, GiaSauGiam, TenKhuyenMai, MoTaKhuyenMaiDacBiet
            FROM vw_SanPhamKhuyenMai WHERE MaSP = @MaSP";

                var parameters = new List<SqlParameter>
        {
            StockDataProvider.CreateParameter("@MaSP", 4, maSP, DbType.Int32)
        };

                using (var reader = dataProvider.GetDataReader(sql, CommandType.Text, parameters.ToArray()))
                {
                    if (reader.Read())
                    {
                        var tenKhuyenMai = reader.IsDBNull(reader.GetOrdinal("TenKhuyenMai")) ? "Không có" : reader["TenKhuyenMai"].ToString();
                        var moTaDacBiet = reader.IsDBNull(reader.GetOrdinal("MoTaKhuyenMaiDacBiet")) ? null : reader["MoTaKhuyenMaiDacBiet"].ToString();
                        var giaBan = reader.IsDBNull(reader.GetOrdinal("GiaBan")) ? 0 : reader.GetDecimal(reader.GetOrdinal("GiaBan"));
                        var giaSauGiam = reader.IsDBNull(reader.GetOrdinal("GiaSauGiam")) ? giaBan : reader.GetDecimal(reader.GetOrdinal("GiaSauGiam"));

                        return new SanPhamKhuyenMai
                        {
                            MaSP = maSP,
                            TenSP = reader["TenSP"].ToString(),
                            GiaBan = giaBan,
                            GiaSauGiam = giaSauGiam,
                            GiaTriGiam = giaBan - giaSauGiam, // Tính lại GiamGia để hiển thị
                            TenKhuyenMai = tenKhuyenMai,
                            MoTaKhuyenMaiDacBiet = moTaDacBiet
                        };
                    }
                    return null;
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