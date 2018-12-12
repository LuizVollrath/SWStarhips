using System;
using System.Collections.Generic;
using System.Linq;
using SWStarships.DataRepository.Entities;
using SWStarships.Interfaces.Repository;
using SWStarships.Interfaces.Services;
using SWStarships.Services.ValueOfObjects.Enum;

namespace SWStarships.Services 
{
    public class StarshipService : IStarshipService
    {
        private readonly IStarshipRepository _starshipRepository;
        
        public StarshipService(IStarshipRepository starshipRepository)
        {
            _starshipRepository = starshipRepository;
        }

        public List<Starship> GetAllStarships()
        {
            return _starshipRepository.GetAllStarships();
        }

        public Starship GetStarship(string code)
        {
            return _starshipRepository.GetStarship(code);
        }

        public int GetAmountOfStopsRequired(Starship starship, double distanceInMGLT)
        {
            var mglt = starship?.MGLT ?? 0d;
            if(mglt == 0)
            {
                throw new Exception($"Starship {starship?.Name} does not have information of MGLT."); 
            }

            var consumables = starship?.Consumables.Split(" ");
            if(consumables?.Length < 2)
            {
                throw new Exception($"Starship {starship?.Name} does not have consumables information.");
            }

            var consumablesPeriodTime = 0d;
            double.TryParse(consumables[0], out consumablesPeriodTime);
            if(consumablesPeriodTime <= 0)
            {
                throw new Exception($"Starship {starship?.Name} does not have consumables information.");
            }

            var consumablesInHours = HoursInConsumablesEnum.ToList().FirstOrDefault(h => h.Value == consumables[1].ToLower());
            if(consumablesInHours == null)
            {
                throw new Exception($"Starship {starship?.Name} does not have consumables information.");
            }

            var totalHoursToDestiny = distanceInMGLT / mglt;
            var hoursPerResupply = consumablesPeriodTime * consumablesInHours;
            return Convert.ToInt32(Math.Floor(totalHoursToDestiny / hoursPerResupply));
        }
    }
}
