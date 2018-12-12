using SWStarships.DataRepository.Entities;
using System.Collections.Generic;

namespace SWStarships.Interfaces.Services
{
    public interface IStarshipService
    {
        List<Starship> GetAllStarships();
        Starship GetStarship(string code);
        int GetAmountOfStopsRequired(Starship starship, double distanceInMGLT);
    }
}
