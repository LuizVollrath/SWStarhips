using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsAPI.Services.ValueOfObjects
{
    public class StarshipAPI
    {
        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Manufacturer { get; private set; }
        public string Cost_in_credits { get; private set; }
        public string Length { get; private set; }
        public string Max_atmosphering_speed { get; private set; }
        public string Crew { get; private set; }
        public string Passengers { get; private set; }
        public string Cargo_capacity { get; private set; }
        public string Consumables { get; private set; }
        public string Hyperdrive_rating { get; private set; }
        public string MGLT { get; private set; }
        public string Starship_class { get; private set; }
        public string Created { get; private set; }
        public string Edited { get; private set; }
        public string Url { get; private set; }
        public List<string> Pilots { get; private set; }
        public List<string> Films { get; private set; }

        [JsonConstructor]
        public StarshipAPI(string name, string model, string manufacturer, string cost_in_credits, 
            string length, string max_atmosphering_speed, string crew, string passengers,
            string cargo_capacity, string consumables, string hyperdrive_rating, string mglt,
            string starship_class, string created, string edited, string url, List<string> pilots, List<string> films)
        {
            Name = name;
            Model = model;
            Manufacturer = manufacturer;
            Cost_in_credits = cost_in_credits;
            Length = length;
            Max_atmosphering_speed = max_atmosphering_speed;
            Crew = crew;
            Passengers = passengers;
            Cargo_capacity = cargo_capacity;
            Consumables = consumables;
            Hyperdrive_rating = hyperdrive_rating;
            MGLT = mglt;
            Starship_class = starship_class;
            Created = created;
            Edited = edited;
            Url = url;
            Pilots = pilots;
            Films = films;
        }
    }
}
