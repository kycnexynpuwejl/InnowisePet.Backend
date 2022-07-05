using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.DAL.Repo;

public interface IStorageRepository
{
    Task<IEnumerable<InnowisePet.Models.Entities.StorageModel>> GetStoragesAsync();
    Task<InnowisePet.Models.Entities.StorageModel> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(InnowisePet.Models.Entities.StorageModel storageModel);
    Task AddProductToStorageAsync(ProductStorageModel productStorageModel);

    Task<IEnumerable<ProductStorageModel>> GetProductsAsync();

    Task<IEnumerable<ProductStorageModel>> GetProductsByStorageIdAsync(Guid storageId);

    Task DeleteProductSorageAsync(Guid storageId, Guid productId);

    Task UpdateProductStorageAsync(ProductStorageModel productStorageModel);
}