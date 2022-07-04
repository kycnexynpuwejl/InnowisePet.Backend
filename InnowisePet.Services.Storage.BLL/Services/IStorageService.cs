using InnowisePet.DTO.DTO.ProductStorage;
using InnowisePet.DTO.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Services;

public interface IStorageService
{
    Task<IEnumerable<Models.Entities.Storage>> GetStoragesAsync();
    Task<Models.Entities.Storage> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(StorageCreateDto storageCreateDto);
    Task AddProductToStorageAsync(ProductStorageCreateDto productStorageCreateDto);
    Task<IEnumerable<ProductStorage>> GetProductsAsync();
    Task<IEnumerable<ProductStorage>> GetProductsByStorageIdAsync(Guid storageId);
    Task DeleteProductSorageAsync(Guid storageId, Guid productId);
    Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto);
}