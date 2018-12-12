using System;
using Microsoft.Extensions.DependencyInjection;
using SWStarships.Interfaces.Services;
using System.Linq;
using SWStarships;

namespace SWStarshipsConsole
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        private static IStarshipService _starshipService;

        private const string COMMAND_SHOW_ALL_STARSHIPS = "S";
        private const string COMMAND_CALCULATE_STOPS = "C";

        public static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;
            Console.WriteLine("==========================================");
            Console.WriteLine("              SW STAR SHIPS ");
            Console.WriteLine("==========================================");

            _serviceProvider = Startup.CreateDefaultDepedencyInjection();
            _starshipService = _serviceProvider.GetService<IStarshipService>();

            Run();
        }

        static void Run()
        {
            while (true)
            {
                Console.WriteLine("OPTIONS");
                Console.WriteLine("S: show all star ships.");
                Console.WriteLine("C: calculate how many stops for resupply.");

                var consoleInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(consoleInput))
                {
                    return;
                }
                
                switch(consoleInput.ToUpper())
                {
                    case COMMAND_SHOW_ALL_STARSHIPS:
                        ShowAllStarships();
                        break;
                    case COMMAND_CALCULATE_STOPS:
                        var mgltInput = 0d;
                        while (mgltInput == 0d)
                        {
                            Console.Write("Inform the distance in mega light:");
                            double.TryParse(Console.ReadLine(), out mgltInput);
                        }
                        ShowAmountOfStopsRequired(mgltInput);
                        break;
                    default:
                        Console.WriteLine("INVALID OPTION.");
                        break;
                }
            }
        }

        static void ShowAllStarships() { 
            Console.Clear();
            try
            {
                var starships = _starshipService.GetAllStarships();
                starships.OrderBy(o => o.Name).ToList().ForEach(s =>
                {
                    Console.WriteLine($"Name:{s.Name} - Consumables:{s.Consumables} - MGLT:{s.MGLT}");
                });
            } catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void ShowAmountOfStopsRequired(double distanceInMGLT)
        {
            Console.Clear();
            var starships = _starshipService.GetAllStarships();
            starships.OrderBy(o => o.Name).ToList().ForEach(s =>
            {
                try
                {
                    var amountStops = _starshipService.GetAmountOfStopsRequired(s, distanceInMGLT);
                    Console.WriteLine($"Name:{s.Name}: {amountStops}");
                } catch (Exception exception)
                {
                    Console.WriteLine($"Name:{s.Name}: {exception.Message}");
                }
            });
        }
    }
}
