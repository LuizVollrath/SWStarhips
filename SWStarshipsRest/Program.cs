using System;
using System.IO;

namespace SWStarshipsRest
{
    static class Program
    {
        static void Main()
        {
            if (!Directory.Exists("C:\\nancy"))
            {
                Directory.CreateDirectory("C:\\nancy");
            }
            RunAsConsole();
        }

        private static void RunAsConsole()
        {
            Console.WriteLine("Starting application...");
            var host = @"http://localhost:62300";
            using (var application = new RestFranquia(host))
            {
                application.StartServer();
                try
                {
                    Console.Clear();
                    Console.WriteLine($"{host}\r\n");
                    Console.WriteLine("==========================================");
                    Console.WriteLine("              SW STAR SHIPS REST");
                    Console.WriteLine("==========================================");
                    Console.Read();
                }
                finally
                {
                    application.StopServer();
                }
            }
        }
    }
}
