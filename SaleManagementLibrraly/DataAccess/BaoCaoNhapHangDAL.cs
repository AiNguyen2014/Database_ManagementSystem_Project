using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;

namespace SaleManagementLibrraly.DataAccess
{
    public class BaoCaoNhapHangDAL
    {
        private static BaoCaoNhapHangDAL instance;
        public static BaoCaoNhapHangDAL Instance
        {
            get { if (instance == null) instance = new BaoCaoNhapHangDAL(); return instance; }
            private set { instance = value; }
        }

        // Thống kê số lượng sản phẩm nhập
        public DataTable ThongKeSoLuongNhap(DateTime ngayBatDau, DateTime ngayKetThuc, string loaiThoiGian = "Ngay")
        {
            try
            {
                string sql = "sp_BaoCao_SoLuongNhap";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@NgayBatDau", 0, ngayBatDau, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKetThuc", 0, ngayKetThuc, DbType.Date),
                    StockDataProvider.CreateParameter("@LoaiThoiGian", 10, loaiThoiGian, DbType.String)
                };
                DataTable dt = new DataTable();
                using (var reader = new StockDataProvider().GetDataReader(sql, CommandType.StoredProcedure, parameters))
                {
                    dt.Load(reader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thống kê số lượng nhập: " + ex.Message);
            }
        }

        // Thống kê tổng chi phí nhập hàng
        public decimal ThongKeTongChiPhiNhap(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            try
            {
                string sql = "sp_BaoCao_TongChiPhiNhap";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@NgayBatDau", 0, ngayBatDau, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKetThuc", 0, ngayKetThuc, DbType.Date)
                };
                object result = new StockDataProvider().ExecuteScalar(sql, CommandType.StoredProcedure, parameters);
                return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thống kê tổng chi phí: " + ex.Message);
            }
        }

        // Sản phẩm nhập nhiều nhất
        public DataTable SanPhamNhapNhieuNhat(DateTime ngayBatDau, DateTime ngayKetThuc, int top = 5)
        {
            try
            {
                string sql = "sp_BaoCao_SanPhamNhapNhieuNhat";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@NgayBatDau", 0, ngayBatDau, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKetThuc", 0, ngayKetThuc, DbType.Date),
                    StockDataProvider.CreateParameter("@Top", 0, top, DbType.Int32)
                };
                DataTable dt = new DataTable();
                using (var reader = new StockDataProvider().GetDataReader(sql, CommandType.StoredProcedure, parameters))
                {
                    dt.Load(reader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy sản phẩm nhập nhiều nhất: " + ex.Message);
            }
        }

        // Nhà cung cấp cung cấp nhiều nhất
        public DataTable NhaCungCapNhieuNhat(DateTime ngayBatDau, DateTime ngayKetThuc, int top = 5)
        {
            try
            {
                string sql = "sp_BaoCao_NhaCungCapNhieuNhat";
                var parameters = new[]
                {
                    StockDataProvider.CreateParameter("@NgayBatDau", 0, ngayBatDau, DbType.Date),
                    StockDataProvider.CreateParameter("@NgayKetThuc", 0, ngayKetThuc, DbType.Date),
                    StockDataProvider.CreateParameter("@Top", 0, top, DbType.Int32)
                };
                DataTable dt = new DataTable();
                using (var reader = new StockDataProvider().GetDataReader(sql, CommandType.StoredProcedure, parameters))
                {
                    dt.Load(reader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy nhà cung cấp nhiều nhất: " + ex.Message);
            }
        }
    }
}