using Exercisediary.Shared;
using ExerciseDiary.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Exercisediary.Server.DataInterfaces.LocationDataInterfaces
{
    public class LocationData : ILocationData
    {
        private readonly ApplicationDbContext _context;

        public LocationData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }
        public async Task<Location?> GetLocationById(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _context.Locations.FindAsync(id);
            }
            else
            {
                throw new Exception("Paikkatietoa ei ole.");
            }
        }
        public async Task<Location> AddLocation(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return location;
        }
        public async Task<Location?> UpdateLocation(Guid id, Location location)
        {
            var dbLocation = await _context.Locations.FindAsync(id); 
            if (dbLocation != null) 
            {
                dbLocation.City = location.City;
                dbLocation.Place = location.Place;
                await _context.SaveChangesAsync();
            }
            return dbLocation;
        }
        public async Task<bool> DeleteLocation(Guid id)
        {
            var dbLocation = await GetLocationById(id);
            if (dbLocation == null) 
            {
                return false;
            }
            _context.Locations.Remove(dbLocation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
