namespace SWStarshipsRest.Models.DTO
{
    class StarshipDTO
    {
        public string Name { get; private set; }
        public string Consumables { get; private set; }
        public double MGLT { get; private set; }

        public StarshipDTO(string name, string consumables, double mglt)
        {
            Name = name;
            Consumables = consumables;
            MGLT = mglt;
        }
    }
}
