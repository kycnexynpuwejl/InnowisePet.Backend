using InnowisePet.Services.Storage.BLL.DTO;
using InnowisePet.Services.Storage.DAL.Models;

namespace InnowisePet.Services.Storage.BLL.Services;

public interface IStorageService
{
    Task<IEnumerable<DAL.Models.Storage>> GetStoragesAsync();
    Task<DAL.Models.Storage> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(StorageCreateDto storageCreateDto);
    Task AddProductToStorageAsync(ProductStorageCreateDto productStorageCreateDto);
    Task<IEnumerable<ProductStorage>> GetProductsAsync();
    Task<IEnumerable<ProductStorage>> GetProductsByStorageIdAsync(Guid storageId);
    Task DeleteProductSorageAsync(Guid storageId, Guid productId);
}