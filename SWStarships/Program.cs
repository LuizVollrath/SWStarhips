using StarWarsAPI.Config;
using StarWarsAPI.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using SWStarships.Interfaces.Services;
using SWStarships.Services;
using SWStarships.Interfaces.Repository;
using SWStarships.DataRepository.Repository.OnlineAPI;

namespace SWStarships
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = Startup.CreateDefaultDepedencyInjection();

            var starshipService = serviceProvider.GetService<IStarshipService>();
            try
            {
                var starships = starshipService.GetAllStarships();
                starships.ForEach(s =>
                {
                    Console.WriteLine($"Name:{s.Name} - Consumables:{s.Consumables} - MGLT:{s.MGLT}");
                });
            } catch(Exception exception)
            {
                Console.WriteLine(exception.InnerException.Message);
            }
            Console.ReadLine();
        }
    }
}
