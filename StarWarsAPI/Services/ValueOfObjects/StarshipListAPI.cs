using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsAPI.Services.ValueOfObjects
{
    internal class StarshipListAPI
    {
        public int Count { get; private set; }
        public string Next { get; private set; }
        public string Previous { get; private set; }
        public List<StarshipAPI> Results { get; private set; }

        [JsonConstructor]
        public StarshipListAPI(int count, string next, string previous, List<StarshipAPI> results)
        {
            Count = count;
            Next = next;
            Previous = previous;
            Results = results;
        }
    }
}
