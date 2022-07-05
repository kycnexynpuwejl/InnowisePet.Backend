using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Services;

public interface IStorageService
{
    Task<IEnumerable<Models.Entities.StorageModel>> GetStoragesAsync();
    Task<Models.Entities.StorageModel> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(StorageCreateDto storageCreateDto);
    Task AddProductToStorageAsync(ProductStorageCreateDto productStorageCreateDto);
    Task<IEnumerable<ProductStorageModel>> GetProductsAsync();
    Task<IEnumerable<ProductStorageModel>> GetProductsByStorageIdAsync(Guid storageId);
    Task DeleteProductSorageAsync(Guid storageId, Guid productId);
    Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto);
}