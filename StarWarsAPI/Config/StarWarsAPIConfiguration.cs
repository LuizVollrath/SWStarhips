using StarWarsAPI.Interfaces.Config;
using System.Configuration;

namespace StarWarsAPI.Config
{
    public class StarWarsAPIConfiguration : IStarWarsAPIConfiguration
    {
        public string UrlBase { get; private set; }
        public string UrlFilms { get; private set; }
        public string UrlPeople { get; private set; }
        public string UrlPlanets { get; private set; }
        public string UrlSpecies { get; private set; }
        public string UrlStarships { get; private set; }
        public string UrlVehicles { get; private set; }

        public StarWarsAPIConfiguration()
        {
            UrlBase = ConfigurationManager.AppSettings.Get("urlSWBase");
            UrlFilms = ConfigurationManager.AppSettings.Get("urlSWFilms");
            UrlPeople = ConfigurationManager.AppSettings.Get("urlSWPeople");
            UrlPlanets = ConfigurationManager.AppSettings.Get("urlSWPlanets");
            UrlSpecies = ConfigurationManager.AppSettings.Get("urlSWSpecies");
            UrlStarships = ConfigurationManager.AppSettings.Get("urlSWStarships");
            UrlVehicles = ConfigurationManager.AppSettings.Get("urlSWVehicles");
        }

        public StarWarsAPIConfiguration(string urlBase, string urlFilms, string urlPeople, string urlPlanets, 
            string urlSpecies, string urlStarships, string urlVehicles)
        {
            UrlBase = urlBase;
            UrlFilms = urlFilms;
            UrlPeople = urlPeople;
            UrlPlanets = urlPlanets;
            UrlSpecies = urlSpecies;
            UrlStarships = urlStarships;
            UrlVehicles = urlVehicles;
        }
    }
}
