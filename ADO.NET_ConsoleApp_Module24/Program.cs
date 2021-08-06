using System;
using System.Data;
using ADO.NET_Module24;

namespace ADO.NET_ConsoleApp_Module24
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new MainConnector();
            var data = new DataTable();

            var result = connector.ConnectAsync();
            if (result.Result)
            {
                Console.WriteLine("Connection succeeded");
                var db = new DbExecutor(connector);
                string tableName = "NetworkUser";
                Console.WriteLine("Get data from " + tableName);
                data = db.SelectAll(tableName);
                Console.WriteLine("Количество строк в " + tableName + ": " + data.Rows.Count);

                foreach (DataColumn column in data.Columns)
                {
                    Console.Write($"{column.ColumnName}\t");
                }
                
                Console.WriteLine();

                foreach (DataRow row in data.Rows)
                {
                    var cels = row.ItemArray;
                    foreach (var cell in cels)
                    {
                        Console.Write($"{cell}\t");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Disconnect from DataBase");
                connector.DisconnectAsync();
            }
            else
            {
                Console.WriteLine("Connection failed");
            }
        }
    }
}
