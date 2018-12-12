namespace SWStarshipsRest.Models.DTO
{
    class StarshipStopsDTO
    {
        public string Name { get; private set; }
        public int NumberStops { get; private set; }
        public string Alert { get; private set; }

        public StarshipStopsDTO(string name, int numberStops, string alert)
        {
            Name = name;
            NumberStops = numberStops;
            Alert = alert;
        }
    }
}
