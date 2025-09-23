using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace SaleManagementLibrraly.DataAccess
{
    public class StockDataProvider
    {
        private static readonly string connectionString =
            @"Data Source=DESKTOP-9C01I62\SQLEXPRESS;
      Initial Catalog=QUANLYBACHHOA;
      Integrated Security=True;
      TrustServerCertificate=True";

        private static SqlConnection? connection;

        // Hàm lấy connection (mở nếu chưa mở)
        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }

        // Đóng kết nối nếu nó đang mở
        public static void CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        // Tạo parameter
        public static SqlParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = name,
                Size = size,
                Value = value ?? DBNull.Value,
                DbType = dbType
            };
            return parameter;
        }

        // Lấy DataReader (connection sẽ mở đến khi reader đóng)
        public IDataReader GetDataReader(string sql, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.CommandType = commandType;
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd.ExecuteReader(); // Khi DataReader đóng => connection sẽ tự giải phóng
        }

        private void ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            command.ExecuteNonQuery();
        }

        public object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            object result;
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            if (parameters != null && parameters.Length > 0)
                command.Parameters.AddRange(parameters);
            result = command.ExecuteScalar();
            return result ?? DBNull.Value;
        }

        public void Insert(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);

        public void Update(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);

        public void Delete(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);
    }
}