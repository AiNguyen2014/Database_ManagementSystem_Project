using Microsoft.Data.SqlClient;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class StockDataProvider
    {
        private string ConnectionString { get; set; }

        public StockDataProvider() { }
        public StockDataProvider(string connectionString) => ConnectionString = connectionString;

        public void CloseConnection(SqlConnection connection) => connection.Close();

        // =============================================================
        // HÀM ĐÃ ĐƯỢC NÂNG CẤP
        // =============================================================
        public static SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                // SỬA: Tự động chuyển C# null thành DBNull để đảm bảo an toàn
                Value = value ?? DBNull.Value
            };
        }

        public IDataReader GetDataReader(string commandText, CommandType commandType, out SqlConnection connection, params SqlParameter[] parameters)
        {
            IDataReader reader = null;
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                // SỬA: Khi có lỗi, phải ném (throw) lỗi ra ngoài để chúng ta biết
                // thay vì im lặng và trả về null.
                throw new Exception("Lỗi từ DataProvider: " + ex.Message);
            }
            // Dòng "return reader;" sẽ không được chạy nếu có lỗi.
            return reader;
        }

        private void ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            object result = null;
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public void Insert(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);

        public void Update(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);

        public void Delete(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);
    }
}