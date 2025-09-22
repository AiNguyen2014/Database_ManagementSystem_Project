using Microsoft.Data.SqlClient;
using SaleManagementLibrraly.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;


namespace SaleManagementLibrraly.DataAccess
{
    public class BienLaiDAL : BaseDAL
    {
        private static BienLaiDAL instance = null;
        private static readonly object instanceLock = new object();
        private BienLaiDAL() { }
        public static BienLaiDAL Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new BienLaiDAL();
                    return instance;
                }
            }
        }

        // Lấy tất cả biên lai
        public List<BienLai> GetAll()
        {
            List<BienLai> list = new List<BienLai>();
            string SQLSelect = "SELECT MaBL, MaHD, NgayTT, SoTien, PhuongThuc, TrangThai FROM BienLai";
            using var reader = new StockDataProvider().GetDataReader(SQLSelect, CommandType.Text); while (reader.Read())
            {
                list.Add(new BienLai
                {
                    MaBL = Convert.ToInt32(reader["MaBL"]),
                    MaHD = Convert.ToInt32(reader["MaHD"]),
                    NgayTT = Convert.ToDateTime(reader["NgayTT"]),
                    SoTien = Convert.ToDecimal(reader["SoTien"]),
                    PhuongThuc = reader["PhuongThuc"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                });
            }
            reader.Close();
            return list;
        }

    }
}
