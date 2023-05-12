using Exercisediary.Shared;

namespace Exercisediary.Client.ClientDataInterfaces.ClientLocationDataInterfaces
{
    public interface IClientLocationData
    {
        List<Location> Paikat { get; set; }
        Task  GetLocations();
        Task<Location?> GetLocationById(Guid id);
        Task CreateLocation(Location location);
        Task UpdateLocation(Guid id, Location location);        
        Task DeleteLocation(Guid id);
    }
}
