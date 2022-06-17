using InnowisePet.Models.Entities;

namespace InnowisePet.Common.DAL.Repo.Interfaces;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetLocationsAsync();
    Task<Location> GetLocationByIdAsync(Guid id);
    Task<bool> CreateLocationAsync(Location location);
    Task<bool> UpdateLocationAsync(Guid id, Location location);
    Task<bool> DeleteLocationAsync(Guid id);
}