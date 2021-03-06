using System;
using System.Data;
using System.Drawing;
using System.Net.Mime;
using ADO.NET_Module24;
using ADO.NET_Module24_Lib;

namespace ADO.NET_ConsoleApp_Module24
{
    public class Manager
    {
        private MainConnector _connector;
        private DbExecutor _dbExecutor;
        private Table _userTable;

        public Manager()
        {
            _connector = new MainConnector();

            _userTable = new Table();
            _userTable.Name = "NetworkUser";
            _userTable.ImportantField = "Login";
            _userTable.Fields.Add("Id");
            _userTable.Fields.Add("Name");
            _userTable.Fields.Add("Login");
        }

        public void Connect()
        {
            var result = _connector.ConnectAsync();
            if (result.Result)
            {
                Console.WriteLine("Connection succeeded");
                _dbExecutor = new DbExecutor(_connector);
            }
            else
            {
                Console.WriteLine("Connection failed");
            }
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnect from DataBase");
            _connector.DisconnectAsync();
        }

        public void ShowData()
        {
            string tableName = "NetworkUser";
            Console.WriteLine("Get data from " + tableName);
            var data = _dbExecutor.SelectAll(tableName);
            Console.WriteLine("Количество строк в " + tableName + ": " + data.Rows.Count);
            
            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }
                
            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }
        }

        public int DeleteUserByLogin(string value)
        {
            return _dbExecutor.DeleteByColumn(_userTable.Name, _userTable.ImportantField, value);
        }

        public void AddUser(string login, string name)
        {
            _dbExecutor.ExecProcedureAdding(name, login);
        }
        
        public int UpdateUserByLogin(string value, string newvalue) {
            return _dbExecutor.UpdateByColumn(_userTable.Name, _userTable.ImportantField, value, _userTable.Fields[2], newvalue);
        }
    }
}