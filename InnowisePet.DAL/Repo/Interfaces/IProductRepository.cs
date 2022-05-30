using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(Guid id);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Guid id, Product product);
    Task<bool> DeleteProductAsync(Guid id);
}