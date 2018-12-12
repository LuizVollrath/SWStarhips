using System.Collections.Generic;
using System.Linq;
using StarWarsAPI.Config;
using StarWarsAPI.Interfaces.Config;
using StarWarsAPI.Services;
using StarWarsAPI.Services.ValueOfObjects;
using SWStarships.DataRepository.Entities;
using SWStarships.Interfaces.Repository;

namespace SWStarships.DataRepository.Repository.OnlineAPI
{
    public class StarshipOnlineAPIRepository : IStarshipRepository
    {
        private readonly StarWarsAPIService _starWarsAPI;

        public StarshipOnlineAPIRepository(IStarWarsAPIConfiguration starWarsAPIConfig)
        {
            _starWarsAPI = new StarWarsAPIService(starWarsAPIConfig);
        }

        public List<Starship> GetAllStarships()
        {
            return _starWarsAPI.GetStarships().Select(starship =>
            {
                return ConvertToEntity(starship);
            }).ToList();
        }

        public Starship GetStarship(string code)
        {
            return ConvertToEntity(_starWarsAPI.GetStarshipByCode(code));
        }

        private Starship ConvertToEntity(StarshipAPI starshipAPI)
        {
            if(starshipAPI == null)
            {
                return null;
            }
            var mglt = 0d;
            double.TryParse(starshipAPI?.MGLT, out mglt);
            return new Starship(starshipAPI?.Name, starshipAPI?.Consumables, mglt);
        }
    }
}
