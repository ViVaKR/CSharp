using System.Net;

namespace Demo_Console
{
    public class Program
    {
        // WebServer
        private static SimpleWebServer? server;

        private static MySqlHelper? mySql;

        public static void Main(string[] args)
        {
            var arg = Convert.ToInt32(args[0]);
            switch (arg)
            {
                case 1: // $ dotnet run 1
                    {
                        mySql = new MySqlHelper();
                        mySql.Start();
                    }
                    break;

                case 2:// $ dotnet run 2
                    {
                        server = new SimpleWebServer();
                        server.Start();
                    }
                    break;
            }
        }

        public static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            Console.WriteLine("App Close");
        }
    }
}
