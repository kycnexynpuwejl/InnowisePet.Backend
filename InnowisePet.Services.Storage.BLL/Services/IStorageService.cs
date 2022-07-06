using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Services;

public interface IStorageService
{
    Task<IEnumerable<StorageModel>> GetStoragesAsync();
    
    Task<StorageModel> GetStorageByIdAsync(Guid id);
    
    Task CreateStorageAsync(StorageCreateDto storageCreateDto);
    
    Task UpdateStorageAsync(StorageUpdateDto storageUpdateDto);
    
    Task DeleteStorageAsync(Guid id);
    
    Task AddProductToStorageAsync(ProductStorageCreateDto productStorageCreateDto);
    
    Task<IEnumerable<ProductStorageModel>> GetProductsAsync();
    
    Task<IEnumerable<ProductStorageModel>> GetProductsByStorageIdAsync(Guid storageId);
    
    Task DeleteProductStorageAsync(Guid storageId, Guid productId);
    
    Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto);
}