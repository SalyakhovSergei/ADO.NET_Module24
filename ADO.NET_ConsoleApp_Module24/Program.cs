using System;
using System.Data;
using System.Threading.Channels;
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
            
            Console.WriteLine("Enter a Login to delete from database:");
            var count = manager.DeleteUserByLogin(Console.ReadLine());
            Console.WriteLine(count + " lines deleted");

            Console.WriteLine("Enter a login to add user in database");
            string login = Console.ReadLine();
            Console.WriteLine("Enter a name");
            string name = Console.ReadLine();
            manager.AddUser(login, name);

            manager.Disconnect();

            Console.ReadKey();

            

        }
    }
}
