﻿using Microsoft.Extensions.DependencyInjection;
using StarWarsAPI.Config;
using StarWarsAPI.Interfaces.Config;
using SWStarships.DataRepository.Repository.OnlineAPI;
using SWStarships.Interfaces.Repository;
using SWStarships.Interfaces.Services;
using SWStarships.Services;

namespace SWStarships
{
    public static class Startup
    {
        public static ServiceProvider CreateDefaultDepedencyInjection()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStarWarsAPIConfiguration, StarWarsAPIConfiguration>();
            serviceCollection.AddSingleton<IStarshipRepository, StarshipOnlineAPIRepository>();
            serviceCollection.AddSingleton<IStarshipService, StarshipService>();
        }
     }
}
