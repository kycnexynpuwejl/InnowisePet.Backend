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

    public async Task<IEnumerable<Models.Entities.StorageModel>> GetStoragesAsync()
    {
        return await _storageRepository.GetStoragesAsync();
    }

    public async Task<Models.Entities.StorageModel> GetStorageByIdAsync(Guid id)
    {
        return await _storageRepository.GetStorageByIdAsync(id);
    }

    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        var storage = _mapper.Map<Models.Entities.StorageModel>(storageCreateDto);
        await _storageRepository.CreateStorageAsync(storage);
    }

    public async Task AddProductToStorageAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        var productStorage = _mapper.Map<ProductStorageModel>(productStorageCreateDto);
        await _storageRepository.AddProductToStorageAsync(productStorage);
    }

    public async Task<IEnumerable<ProductStorageModel>> GetProductsAsync()
    {
        return await _storageRepository.GetProductsAsync();
    }

    public async Task<IEnumerable<ProductStorageModel>> GetProductsByStorageIdAsync(Guid storageId)
    {
        return await _storageRepository.GetProductsByStorageIdAsync(storageId);
    }

    public async Task DeleteProductSorageAsync(Guid storageId, Guid productId)
    {
        await _storageRepository.DeleteProductSorageAsync(storageId, productId);
    }

    public async Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto)
    {
        var productStorage = _mapper.Map<ProductStorageModel>(productStorageUpdateDto);
        await _storageRepository.UpdateProductStorageAsync(productStorage);
    }
}