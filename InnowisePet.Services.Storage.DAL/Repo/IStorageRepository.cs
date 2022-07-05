using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.DAL.Repo;

public interface IStorageRepository
{
    Task<IEnumerable<StorageModel>> GetStoragesAsync();
    Task<StorageModel> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(StorageModel storageModel);
    Task AddProductToStorageAsync(ProductStorageModel productStorageModel);

    Task<IEnumerable<ProductStorageModel>> GetProductsAsync();

    Task<IEnumerable<ProductStorageModel>> GetProductsByStorageIdAsync(Guid storageId);

    Task DeleteProductSorageAsync(Guid storageId, Guid productId);

    Task UpdateProductStorageAsync(ProductStorageModel productStorageModel);
}