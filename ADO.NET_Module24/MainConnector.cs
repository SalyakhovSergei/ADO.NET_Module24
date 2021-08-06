﻿using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADO.NET_Module24
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
        
        
        
        
    }
}