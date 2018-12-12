using SWStarships.DataRepository.Entities;
using System.Collections.Generic;

namespace SWStarships.Interfaces.Repository
{
    public interface IStarshipRepository
    {
        List<Starship> GetAllStarships();
        Starship GetStarship(string code);
    }
}
