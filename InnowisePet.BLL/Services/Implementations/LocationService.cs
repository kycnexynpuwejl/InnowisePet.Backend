using AutoMapper;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Implementations;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public LocationService(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Location>> GetLocationsAsync()
    {
        return await _locationRepository.GetLocationsAsync();
    }

    public async Task<Location> GetLocatioByIdAsync(Guid id)
    {
        return await _locationRepository.GetLocationByIdAsync(id);
    }

    public async Task<bool> CreateLocationAsync(LocationCreateDto locationCreateDto)
    {
        Location location = _mapper.Map<Location>(locationCreateDto);

        return await _locationRepository.CreateLocationAsync(location);
    }

    public async Task<bool> UpdateLocationAsync(Guid id, LocationUpdateDto locationUpdateDto)
    {
        Location location = _mapper.Map<Location>(locationUpdateDto);

        return await _locationRepository.UpdateLocationAsync(id, location);
    }

    public async Task<bool> DeleteLocationAsync(Guid id)
    {
        return await _locationRepository.DeleteLocationAsync(id);
    }
}