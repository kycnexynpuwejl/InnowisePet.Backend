using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.DAL.Repo;

public interface IStorageRepository
{
    Task<IEnumerable<StorageModel>> GetStoragesAsync();
    
    Task<StorageModel> GetStorageByIdAsync(Guid id);
    
    Task<bool> CreateStorageAsync(StorageModel storageModel);
    
    Task<bool> UpdateStorageAsync(StorageModel storageModel);
    
    Task<bool> DeleteStorageAsync(Guid id);

    Task<IEnumerable<ProductStorageModel>> GetProductStoragesAsync();

    Task<IEnumerable<ProductStorageModel>> GetProductStoragesByStorageIdAsync(Guid storageId);
    
    Task<bool> CreateProductStorageAsync(ProductStorageModel productStorageModel);

    Task<bool> UpdateProductStorageAsync(ProductStorageModel productStorageModel);
    
    Task<bool> DeleteProductStorageAsync(Guid storageId, Guid productId);
}