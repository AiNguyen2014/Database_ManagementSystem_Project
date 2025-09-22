// File: DataAccess/LoaiSanPhamDAL.cs
using SaleManagementLibrraly.BussinessObject;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class LoaiSanPhamDAL : BaseDAL
    {
        #region Singleton
        private static LoaiSanPhamDAL instance = null;
        private static readonly object instanceLock = new object();
        private LoaiSanPhamDAL() { }
        public static LoaiSanPhamDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LoaiSanPhamDAL();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public IEnumerable<LoaiSanPham> GetAll()
        {
            var list = new List<LoaiSanPham>();
            string SQLSelect = "SELECT MaLoaiSP, TenLoaiSP FROM LoaiSanPham";

            try
            {
                using var reader = dataProvider.GetDataReader(SQLSelect, CommandType.Text);
                while (reader.Read())
                {
                    list.Add(new LoaiSanPham
                    {
                        MaLoaiSP = reader.GetInt32(0),
                        TenLoaiSP = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách loại sản phẩm: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return list;
        }
    }
}