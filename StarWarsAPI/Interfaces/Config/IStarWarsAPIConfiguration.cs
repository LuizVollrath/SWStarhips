namespace StarWarsAPI.Interfaces.Config
{
    public interface IStarWarsAPIConfiguration
    {
        string UrlBase { get; }
        string UrlFilms { get; }
        string UrlPeople { get; }
        string UrlPlanets { get; }
        string UrlSpecies { get; }
        string UrlStarships { get; }
        string UrlVehicles { get; }
    }
}
