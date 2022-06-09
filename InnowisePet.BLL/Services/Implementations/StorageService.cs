using AutoMapper;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.DTO.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Implementations;

public class StorageService : IStorageService
{
    private readonly IStorageRepository _storageRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public StorageService(IStorageRepository storageRepository, IMapper mapper, ILocationRepository locationRepository)
    {
        _storageRepository = storageRepository;
        _locationRepository = locationRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<StorageGetDto>> GetStoragesAsync()
    {
        IEnumerable<Storage> result =  await _storageRepository.GetStoragesAsync();

        return _mapper.Map<IEnumerable<StorageGetDto>>(result);
    }
    
    public async Task<StorageGetDto> GetStorageByIdAsync(Guid id)
    {
        Storage result = await _storageRepository.GetStorageByIdAsync(id);
        Location location = await _locationRepository.GetLocationByIdAsync(result.location_id);
        StorageGetDto mappedResult = _mapper.Map<StorageGetDto>(result);
        mappedResult.LocationName = location.city;
        
        return mappedResult;
    }
    
    public async Task<bool> CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        Storage storage = _mapper.Map<Storage>(storageCreateDto);

        return await _storageRepository.CreateStorageAsync(storage);
    }
    
    public async Task<bool> UpdateStorageAsync(Guid id, StorageUpdateDto storageUpdateDto)
    {
        Storage storage = _mapper.Map<Storage>(storageUpdateDto);

        return await _storageRepository.UpdateStorageAsync(id, storage);
    }
    
    public async Task<bool> DeleteStorageAsync(Guid id)
    {
        return await _storageRepository.DeleteStorageAsync(id);
    }
}