using AutoMapper;
using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.DTO.Storage;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Storage.DAL.Repo;

namespace InnowisePet.Services.Storage.BLL.Services;

public class StorageService : IStorageService
{
    private readonly IStorageRepository _storageRepository;
    private readonly IMapper _mapper;

    public StorageService(IStorageRepository storageRepository, IMapper mapper)
    {
        _storageRepository = storageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StorageGetDtoList>> GetStoragesAsync()
    {
        return _mapper.Map<IEnumerable<StorageGetDtoList>>(await _storageRepository.GetStoragesAsync());
    }

    public async Task<StorageGetDto> GetStorageByIdAsync(Guid id)
    {
        return _mapper.Map<StorageGetDto>(await _storageRepository.GetStorageByIdAsync(id));
    }

    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        await _storageRepository.CreateStorageAsync(_mapper.Map<StorageModel>(storageCreateDto));
    }

    public async Task UpdateStorageAsync(StorageUpdateDto storageUpdateDto)
    {
        await _storageRepository.UpdateStorageAsync(_mapper.Map<StorageModel>(storageUpdateDto));
    }

    public async Task DeleteStorageAsync(Guid id)
    {
        await _storageRepository.DeleteStorageAsync(id);
    }

    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesAsync()
    {
        return _mapper.Map<IEnumerable<ProductStorageGetDto>>(await _storageRepository.GetProductStoragesAsync());
    }

    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        return _mapper.Map<IEnumerable<ProductStorageGetDto>>(await _storageRepository.GetProductStoragesByStorageIdAsync(storageId));
    }
    
    public async Task CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        var productStorage = _mapper.Map<ProductStorageModel>(productStorageCreateDto);
        await _storageRepository.CreateProductStorageAsync(productStorage);
    }
    
    public async Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto)
    {
        var productStorage = _mapper.Map<ProductStorageModel>(productStorageUpdateDto);
        await _storageRepository.UpdateProductStorageAsync(productStorage);
    }

    public async Task DeleteProductStorageAsync(Guid storageId, Guid productId)
    {
        await _storageRepository.DeleteProductStorageAsync(storageId, productId);
    }
}