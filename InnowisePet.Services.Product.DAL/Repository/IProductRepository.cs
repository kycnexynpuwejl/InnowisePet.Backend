using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.DAL.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    Task<ProductModel> GetProductByIdAsync(Guid id);
    Task CreateProductAsync(ProductModel productModel);
    Task UpdateProductAsync(ProductModel productModel);
    Task DeleteProductAsync(Guid id);
}