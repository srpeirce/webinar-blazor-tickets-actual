using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P4.Tickets.WebApi.Contract;

namespace P4.Tickets.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/locations")]
    public class LocationsController : ControllerBase
    {
        private readonly ILogger<LocationsController> _logger;
        private readonly LocationsRepository _locationsRepository;

        private static bool ShouldErrorWhenFlakey = false;

        public LocationsController(ILogger<LocationsController> logger, LocationsRepository locationsRepository)
        {
            _logger = logger;
            _locationsRepository = locationsRepository;
        }

        [HttpGet("{locationId}")]
        public async Task<ActionResult<ShowDetailsModel>> GetAsync(string locationId, bool isFlakey = false)
        {
            
            if (isFlakey)
            {
                ShouldErrorWhenFlakey = !ShouldErrorWhenFlakey;

                if (ShouldErrorWhenFlakey)
                {
                    throw new Exception("BOOOMM we've blown up");
                }
            }
            return await _locationsRepository.GetAsync(locationId) is LocationDetailsModel location
                ? Ok(location)
                : NotFound();
        }
    }

    public class LocationsRepository
    {
        private readonly List<LocationDetailsModel> _locations = new()
        {
            new LocationDetailsModel("liverpool-kirby",
                "1 Musland Road, Kirby, Liverpool, L32 6QW",
                "Description to add"),
            new LocationDetailsModel("carlton-morecambe",
                "The Carleton, Marine Road, Morecambe, LA4 4EU",
                "Location To Addd"),
            new LocationDetailsModel("fusion-liverpool",
                "Fusion Nightclub, Liverpool",
                "Location details to add"),
            new LocationDetailsModel("lancashire",
                "Lancashire",
                "Location details to add"),
            new LocationDetailsModel("chicago",
                "Chicago",
                "Description to add"),
            new LocationDetailsModel("upholland-labour-club-skelmersdale",
                "Upholland Labour Club, Skelmersdale",
                "description to add"),
            new LocationDetailsModel("zaal-de-brug",
                "Zaal De Brug (Libertus), Mechelen",
                "dewcription to add"),
            new LocationDetailsModel("feestpaleis-boom",
                "Feestpaleis, Boom",
                "description to add")
        };
        
        public async Task<LocationDetailsModel?> GetAsync(string locationId) => 
            await Task.FromResult(_locations.SingleOrDefault(l => l.Id.Equals(locationId, StringComparison.InvariantCultureIgnoreCase)));
    }
}