using AutoMapper;
using InnowisePet.Services.Storage.BLL.DTO;
using InnowisePet.Services.Storage.DAL.Models;
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

    public async Task<IEnumerable<DAL.Models.Storage>> GetStoragesAsync()
    {
        return await _storageRepository.GetStoragesAsync();
    }

    public async Task<DAL.Models.Storage> GetStorageByIdAsync(Guid id)
    {
        return await _storageRepository.GetStorageByIdAsync(id);
    }

    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        var storage = _mapper.Map<DAL.Models.Storage>(storageCreateDto);
        await _storageRepository.CreateStorageAsync(storage);
    }

    public async Task AddProductToStorageAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        var productStorage = _mapper.Map<ProductStorage>(productStorageCreateDto);
        await _storageRepository.AddProductToStorageAsync(productStorage);
    }

    public async Task<IEnumerable<ProductStorage>> GetProductsAsync()
    {
        return await _storageRepository.GetProductsAsync();
    }
}