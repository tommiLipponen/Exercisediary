using Exercisediary.Shared;

namespace Exercisediary.Server.DataInterfaces.LocationDataInterfaces
{
    public interface ILocationData
    {
        Task<List<Location>> GetLocations();
        Task<Location?> GetLocationById(Guid id);
        Task<Location?> UpdateLocation(Guid id, Location location);
        Task<Location> AddLocation(Location location);
        Task<bool> DeleteLocation(Guid id);
    }
}
