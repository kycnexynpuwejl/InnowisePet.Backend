using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.DAL.Repository.Interfaces;

public interface IProductRepository
{
    Task<PaginatedProductsDto> GetProductsAsync(ProductFilter productFilter);
    
    Task<ProductModel> GetProductByIdAsync(Guid productId);

    Task<IEnumerable<ProductModel>> GetProductsByCategoryIdAsync(Guid categoryId);
    
    Task<Guid> CreateProductAsync(ProductModel productModel);
    
    Task UpdateProductAsync(ProductModel productModel);
    
    Task DeleteProductAsync(Guid id);
}