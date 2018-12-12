using Microsoft.Extensions.DependencyInjection;
using StarWarsAPI.Config;
using StarWarsAPI.Interfaces.Config;
using SWStarships.DataRepository.Repository.OnlineAPI;
using SWStarships.Interfaces.Repository;
using SWStarships.Interfaces.Services;
using SWStarships.Services;

namespace UnitTestStarship
{
    public static class Startup
    {
        public static ServiceProvider CreateTestDepedencyInjection()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStarWarsAPIConfiguration, StarWarsAPIConfiguration>(serviceProvider =>
            {
                return new StarWarsAPIConfiguration(@"https://swapi.co/api/", @"https://swapi.co/api/films/", @"https://swapi.co/api/people/",
                    @"https://swapi.co/api/planets/", @"https://swapi.co/api/species/", @"https://swapi.co/api/starships/", @"https://swapi.co/api/vehicles/");
            });
            serviceCollection.AddSingleton<IStarshipRepository, StarshipOnlineAPIRepository>();
            serviceCollection.AddSingleton<IStarshipService, StarshipService>();
        }
     }
}
