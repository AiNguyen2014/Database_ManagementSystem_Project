using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
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

        // Hàm để thêm một dòng chi tiết vào hóa đơn
        public void AddNew(ChiTietHoaDon cthd)
        {
            try
            {
                // Giả định MaCTHD không phải là tự tăng
                string sqlInsert = "INSERT INTO ChiTietHoaDon (MaCTHD, MaHD, MaSP, SoLuong, DonGia) VALUES (@MaCTHD, @MaHD, @MaSP, @SoLuong, @DonGia)";
                var parameters = new List<SqlParameter>
                {
                    StockDataProvider.CreateParameter("@MaCTHD", 0, cthd.MaCTHD, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaHD", 0, cthd.MaHD, DbType.Int32),
                    StockDataProvider.CreateParameter("@MaSP", 0, cthd.MaSP, DbType.Int32),
                    StockDataProvider.CreateParameter("@SoLuong", 0, cthd.SoLuong, DbType.Int32),
                    StockDataProvider.CreateParameter("@DonGia", 0, cthd.DonGia, DbType.Decimal)
                };
                dataProvider.Insert(sqlInsert, CommandType.Text, parameters.ToArray());
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
    }
}