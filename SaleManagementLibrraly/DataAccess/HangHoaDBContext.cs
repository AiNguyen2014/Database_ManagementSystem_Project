using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace SaleManagementLibrraly.DataAccess
{
    public class HangHoaDBContext
    {
        private string connectionString;

        // Constructor để nhận chuỗi kết nối
        public HangHoaDBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // --- CÁC PHƯƠNG THỨC TRUY VẤN DATABASE ---

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm dưới dạng DataTable để hiển thị lên DataGridView.
        /// </summary>
        public DataTable GetSanPhamList()
        {
            var dataTable = new DataTable();
            // Sửa tên bảng thành dbo.SanPham
            string sql = "SELECT MaSP, TenSP, DonGia, SoLuongTon FROM dbo.SanPham";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var adapter = new SqlDataAdapter(sql, connection))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            return dataTable;
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo tên (keyword).
        /// </summary>
        public DataTable SearchSanPham(string keyword)
        {
            var dataTable = new DataTable();
            string sql = "SELECT MaSP, TenSP, DonGia, SoLuongTon FROM dbo.SanPham WHERE TenSP LIKE @Keyword";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        // Dùng SqlParameter để tránh lỗi SQL Injection
                        command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sản phẩm: " + ex.Message);
            }
            return dataTable;
        }

        // Các phương thức khác như AddNew, Update, Delete có thể được thêm vào đây
        // với cấu trúc tương tự, sử dụng using block và SqlParameter.

    }
}