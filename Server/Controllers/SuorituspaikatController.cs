using Exercisediary.Server.DataInterfaces.LocationDataInterfaces;
using Exercisediary.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercisediary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuorituspaikatController : ControllerBase
    {
        private readonly ILocationData _locationData;
        public SuorituspaikatController(ILocationData locationData)
        {
            _locationData = locationData;
        }
        [HttpGet]
        public async Task<List<Location>> GetLocations()
        {
            return await _locationData.GetLocations();
        }
        [HttpGet("{id}")]
        public async Task<Location?> GetLocationById(Guid id)
        {
            return await _locationData.GetLocationById(id);
        }
        [HttpPost]
        public async Task<Location?> CreateLocation(Location location)
        {
            return await _locationData.AddLocation(location);
        }
        [HttpPut("{id}")]
        public async Task<Location?> UpdateLocation(Guid id, Location location)
        {
            return await _locationData.UpdateLocation(id, location);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteLocation(Guid id)
        {
            return await _locationData.DeleteLocation(id);
        }
    }
}
