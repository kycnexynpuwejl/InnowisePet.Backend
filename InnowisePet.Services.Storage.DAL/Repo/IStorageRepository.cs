using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.DAL.Repo;

public interface IStorageRepository
{
    Task<IEnumerable<StorageModel>> GetStoragesAsync();
    
    Task<StorageModel> GetStorageByIdAsync(Guid id);
    
    Task CreateStorageAsync(StorageModel storageModel);
    
    Task UpdateStorageAsync(StorageModel storageModel);
    
    Task DeleteStorageAsync(Guid id);
    
    Task AddProductToStorageAsync(ProductStorageModel productStorageModel);

    Task<IEnumerable<ProductStorageModel>> GetProductStoragesAsync();

    Task<IEnumerable<ProductStorageModel>> GetProductStoragesByStorageIdAsync(Guid storageId);

    Task DeleteProductStorageAsync(Guid storageId, Guid productId);

    Task UpdateProductStorageAsync(ProductStorageModel productStorageModel);
}