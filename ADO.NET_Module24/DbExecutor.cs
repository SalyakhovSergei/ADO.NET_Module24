using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Module24
{
    public class DbExecutor
    {
        private MainConnector _connector;
        public DbExecutor(MainConnector mainConnector)
        {
            _connector = mainConnector;
        }
        
        public DataTable SelectAll(string table) 
        {
            string selectcommandtext = "select * from " + table;
            var adapter = new SqlDataAdapter(selectcommandtext, _connector.GetConnection());
            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet.Tables[0];
        }
        //from connection model. Module 24.3
        public SqlDataReader SelectAllCommandReader(string table) 
        {
            var command = new SqlCommand 
            {
                CommandType = CommandType.Text,
                CommandText = "select * from " + table,
                Connection = _connector.GetConnection(),
            };

            SqlDataReader reader = command.ExecuteReader();
            

            if (reader.HasRows) 
            {
                return reader;
            }

            return null;
        }
        
        public int DeleteByColumn(string table, string column, string value) 
        {
            var command = new SqlCommand 
            {
                CommandType = CommandType.Text,
                CommandText = "delete from " + table + " where " + column + " = '" + value + "';",
                Connection = _connector.GetConnection(),
            };

            return command.ExecuteNonQuery();

        }
        
    }
}