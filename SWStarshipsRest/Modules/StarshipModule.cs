using Microsoft.Extensions.DependencyInjection;
using Nancy;
using Newtonsoft.Json;
using SWStarships.Interfaces.Services;
using SWStarshipsRest.Models.DTO;
using System;
using System.Linq;

namespace SWStarshipsRest.Modules
{
    public class StarshipModule : NancyModule
    {
        private readonly IStarshipService _starshipService;

        public StarshipModule(IServiceProvider serviceProvider)
        {
            _starshipService = serviceProvider.GetService<IStarshipService>();

            Get("starships", r => {
                try
                {
                    var starships = _starshipService.GetAllStarships().OrderBy(o => o.Name).Select(s =>
                    {
                        return new StarshipDTO(s.Name, s.Consumables, s.MGLT);
                    });
                    return JsonConvert.SerializeObject(starships);
                }
                catch (Exception ex)
                {
                    return Response.AsJson(JsonConvert.SerializeObject(ex.Message + ex.StackTrace), HttpStatusCode.BadRequest);
                }
            });

            Get("starship/{code}", r => {
                try
                {
                    var starship = _starshipService.GetStarship(r.code);
                    var starshipDto = new StarshipDTO(starship?.Name, starship?.Consumables, starship?.MGLT);
                    return JsonConvert.SerializeObject(starshipDto);
                }
                catch (Exception ex)
                {
                    return Response.AsJson(JsonConvert.SerializeObject(ex.Message + ex.StackTrace), HttpStatusCode.BadRequest);
                }
            });

            Get("starships/stopsUntil/{mglt}", r => {
                try
                {
                    var mgltDistance = 0d;
                    double.TryParse(r.mglt, out mgltDistance);
                    var starships = _starshipService.GetAllStarships().OrderBy(o => o.Name).Select(s =>
                    {
                        try
                        {
                            var totalStops = _starshipService.GetAmountOfStopsRequired(s, mgltDistance);
                            return new StarshipStopsDTO(s.Name, totalStops, string.Empty);
                        }
                        catch (Exception ex)
                        {
                            return new StarshipStopsDTO(s.Name, 0, ex.Message);
                        }                      
                    });
                    return JsonConvert.SerializeObject(starships);
                }
                catch (Exception ex)
                {
                    return Response.AsJson(JsonConvert.SerializeObject(ex.Message + ex.StackTrace), HttpStatusCode.BadRequest);
                }
            });

        }
    }
}
