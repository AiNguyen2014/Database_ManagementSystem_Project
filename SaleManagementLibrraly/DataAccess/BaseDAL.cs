using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.DataAccess
{
    public class BaseDAL
    {
        public StockDataProvider dataProvider { get; set; } = null;
        public SqlConnection connection = null;

        public BaseDAL()
        {
            var connectionString = GetConnectionString();
            dataProvider = new StockDataProvider(connectionString);
        }
        //
        public string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
            connectionString = config["ConnectionStrings:DefaultConnection"];
            return connectionString;
        }
        //
        public void CloseConnection() 
        {
            // Chỉ đóng kết nối nếu nó thực sự đang tồn tại và đang mở
            if (connection != null && connection.State == ConnectionState.Open)
            {
                dataProvider.CloseConnection(connection);
            }
        }
    }
}
