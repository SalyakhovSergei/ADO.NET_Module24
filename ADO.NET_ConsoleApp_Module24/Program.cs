using System;
using System.Data;
using ADO.NET_Module24_Lib;

namespace ADO.NET_ConsoleApp_Module24
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();

            manager.Connect();

            manager.ShowData();

            manager.Disconnect();

            Console.ReadKey();

        }
    }
}
