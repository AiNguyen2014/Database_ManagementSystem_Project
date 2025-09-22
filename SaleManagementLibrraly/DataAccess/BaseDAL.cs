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
        protected StockDataProvider dataProvider { get; set; }

        public BaseDAL()
        {
            dataProvider = new StockDataProvider();
        }

        public void CloseConnection() 
        {
                StockDataProvider.CloseConnection();
            
        }
    }
}
