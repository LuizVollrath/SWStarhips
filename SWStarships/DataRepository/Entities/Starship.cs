namespace SWStarships.DataRepository.Entities
{
    public class Starship
    {
        public string Name { get; private set; }
        public string Consumables { get; private set; }
        public double MGLT { get; private set; }

        public Starship(string name, string consumables, double mglt)
        {
            Name = name;
            Consumables = consumables;
            MGLT = mglt;
        }
    }
}
