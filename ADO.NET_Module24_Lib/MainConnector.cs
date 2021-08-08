using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADO.NET_Module24_Lib
{
    public class MainConnector
    {
        private SqlConnection _connection;
        public async Task<bool> ConnectAsync()
        {
            bool result;
            try
            {
                _connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await _connection.OpenAsync();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public async void DisconnectAsync()
        {
            if (_connection.State == ConnectionState.Open)
            {
                await _connection.CloseAsync();
            }
        }

        public SqlConnection GetConnection()
        {
            if (_connection.State == ConnectionState.Open)
                return _connection;
            else
            {
                throw new Exception("Connection is already closed");
            }
        }
        
        
    }
}