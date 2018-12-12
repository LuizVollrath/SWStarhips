using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWStarships;
using SWStarships.DataRepository.Entities;
using SWStarships.Interfaces.Services;
using System;

namespace UnitTestStarship
{
    [TestClass]
    public class StarshipServiceTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IStarshipService _starshipService;

        public StarshipServiceTest()
        {
            _serviceProvider = Startup.CreateDefaultDepedencyInjection();

            _starshipService = _serviceProvider.GetService<IStarshipService>();
        }

        [TestMethod]
        public void Test_GetAllStarshipsFromOnlineRepository()
        {
            var starships = _starshipService.GetAllStarships();
            Assert.IsNotNull(starships);
            Assert.AreNotEqual(0, starships?.Count ?? 0);
        }

        [TestMethod]
        public void Test_GetStarshipFromOnlineRepository()
        {
            var starship = _starshipService.GetStarship("9");
            Assert.IsNotNull(starship);
            Assert.AreEqual("Death Star", starship?.Name);
        }

        [TestMethod]
        public void Test_GetAmountOfStopsRequired()
        {
            var distance = 1000000;

            var starship = new Starship("Jedi starfighter", "7 days", 50);
            var totalStops = _starshipService.GetAmountOfStopsRequired(starship, distance);
            Assert.AreEqual(8, totalStops);

            starship = new Starship("Y-wing", "1 week", 80);
            totalStops = _starshipService.GetAmountOfStopsRequired(starship, distance);
            Assert.AreEqual(74, totalStops);

            starship = new Starship("Sentinel-class landing craft", "1 month", 70);
            totalStops = _starshipService.GetAmountOfStopsRequired(starship, distance);
            Assert.AreEqual(8, totalStops);

            starship = new Starship("Millennium Falcon", "2 months", 75);
            totalStops = _starshipService.GetAmountOfStopsRequired(starship, distance);
            Assert.AreEqual(9, totalStops);

            starship = new Starship("Death Star", "3 years", 10);
            totalStops = _starshipService.GetAmountOfStopsRequired(starship, distance);
            Assert.AreEqual(8, totalStops);
        }

        [TestMethod]
        public void Test_GetStarshipsWithoutConsumablesToCalculate()
        {
            var distance = 1000000;
            var starship = new Starship("Death Star", "unknown", 10);
            try
            {
                var totalStops = _starshipService.GetAmountOfStopsRequired(starship, distance);
            } catch(Exception exception)
            {
                Assert.AreEqual($"Starship { starship?.Name} does not have consumables information.", exception.Message);
            }
        }

        [TestMethod]
        public void Test_GetStarshipsWithoutMGLTToCalculate()
        {
            var distance = 1000000;
            var starship = new Starship("Death Star", "1 day", 0);
            try
            {
                var totalStops = _starshipService.GetAmountOfStopsRequired(starship, distance);
            }
            catch (Exception exception)
            {
                Assert.AreEqual($"Starship {starship?.Name} does not have information of MGLT.", exception.Message);
            }
        }
    }
}
