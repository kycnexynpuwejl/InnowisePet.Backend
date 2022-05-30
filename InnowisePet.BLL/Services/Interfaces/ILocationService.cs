using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Interfaces;

public interface ILocationService
{
    Task<IEnumerable<Location>> GetLocationsAsync();
    Task<Location> GetLocatioByIdAsync(Guid id);
    Task<bool> CreateLocationAsync(LocationCreateDto locationCreateDto);
    Task<bool> UpdateLocationAsync(Guid id, LocationUpdateDto locationUpdateDto);
    Task<bool> DeleteLocationAsync(Guid id);
}