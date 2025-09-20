using Microsoft.Data.SqlClient;
using System.Data;

namespace SaleManagementLibrraly.DataAccess
{
    public class StockDataProvider
    {
        private string ConnectionString { get; set; }

        // Constructors
        public StockDataProvider() { }
        public StockDataProvider(string connectionString) => ConnectionString = connectionString;

        public void CloseConnection(SqlConnection connection) => connection.Close();

        /// <summary>
        /// Tạo một đối tượng SqlParameter để sử dụng trong các câu lệnh SQL.
        /// </summary>
        public SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value
            };
        }

        /// <summary>
        /// Thực thi một câu lệnh SELECT và trả về một IDataReader.
        /// Lưu ý: Connection sẽ được giữ mở và cần được đóng thủ công sau khi đọc xong.
        /// </summary>
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
                    command.Parameters.AddRange(parameters);
                }
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reader;
        }

        /// <summary>
        /// Thực thi một câu lệnh INSERT, UPDATE, hoặc DELETE.
        /// </summary>
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
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Thực thi một câu lệnh và trả về một giá trị duy nhất (ví dụ: lấy ID mới).
        /// </summary>
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
                    command.Parameters.AddRange(parameters);
                }
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        // --- CÁC HÀM TIỆN ÍCH CHO INSERT, UPDATE, DELETE ---

        public void Insert(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);

        public void Update(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);

        public void Delete(string commandText, CommandType commandType, params SqlParameter[] parameters)
            => ExecuteNonQuery(commandText, commandType, parameters);
    }
}