using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.DAL.Repo;

public interface IStorageRepository
{
    Task<IEnumerable<InnowisePet.Models.Entities.Storage>> GetStoragesAsync();
    Task<InnowisePet.Models.Entities.Storage> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(InnowisePet.Models.Entities.Storage storage);
    Task AddProductToStorageAsync(ProductStorage productStorage);

    Task<IEnumerable<ProductStorage>> GetProductsAsync();

    Task<IEnumerable<ProductStorage>> GetProductsByStorageIdAsync(Guid storageId);

    Task DeleteProductSorageAsync(Guid storageId, Guid productId);

    Task UpdateProductStorageAsync(ProductStorage productStorage);
}