using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface IProductStorageRepository
{
    Task<IEnumerable<ProductStorage>> GetProductStoragesAsync();
    Task<ProductStorage> GetProductStorageByIdAsync(Guid id);
    Task<bool> CreateProductStorageAsync(ProductStorage productStorage);
    Task<bool> UpdateProductStorageAsync(Guid id, ProductStorage productStorage);
    Task<bool> DeleteProductStorageAsync(Guid id);
}