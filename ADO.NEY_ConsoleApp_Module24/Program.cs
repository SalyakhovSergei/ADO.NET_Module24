using System;
using ADO.NET_Module24;

namespace ADO.NEY_ConsoleApp_Module24
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new MainConnector();

            var result = connector.ConnectAsync();
            if (result.Result)
            {
                Console.WriteLine("Connection succeeded");
            }
            else
            {
                Console.WriteLine("Connection failed");
            }
        }
    }
}
