using InnowisePet.Services.Storage.DAL.Models;

namespace InnowisePet.Services.Storage.DAL.Repo;

public interface IStorageRepository
{
    Task<IEnumerable<Models.Storage>> GetStoragesAsync();
    Task<Models.Storage> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(Models.Storage storage);
    Task AddProductToStorageAsync(ProductStorage productStorage);

    Task<IEnumerable<ProductStorage>> GetProductsAsync();

    Task<IEnumerable<ProductStorage>> GetProductsByStorageIdAsync(Guid storageId);

    Task DeleteProductSorageAsync(Guid storageId, Guid productId);

    Task UpdateProductStorageAsync(ProductStorage productStorage);
}