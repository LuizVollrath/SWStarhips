using Newtonsoft.Json;
using StarWarsAPI.Config;
using StarWarsAPI.Interfaces.Config;
using StarWarsAPI.Services.ValueOfObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Services
{
    public class StarWarsAPIService
    {
        private static HttpClient _client { get; } = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };
        private IStarWarsAPIConfiguration _config;

        public StarWarsAPIService(IStarWarsAPIConfiguration config)
        {
            _config = config;
        }

        public StarshipAPI GetStarshipByCode(string code)
        {
            try
            {
                var starshipTask = GetAsync<StarshipAPI>($"{_config.UrlStarships}{code}/");
                return starshipTask.Result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<StarshipAPI> GetStarships()
        {
            try
            {
                var starships = new List<StarshipAPI>();
                var urlStarships = _config.UrlStarships;
                bool shouldContinue = true;
                while (shouldContinue) {
                    var starshipsTask = GetAsync<StarshipListAPI>(urlStarships);
                    starships.AddRange(starshipsTask.Result.Results);
                    if (string.IsNullOrEmpty(starshipsTask.Result.Next))
                    {
                        shouldContinue = false;
                    }
                    urlStarships = starshipsTask.Result.Next;
                }
                return starships;
            } catch(Exception exception)
            {
                throw exception;
            }
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var uri = new Uri(url);
            var response = await _client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"HTTP Error: {response.StatusCode} - {response.RequestMessage}.");
            }

            var contentResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(contentResult);
            return result;
        }
    }
}
