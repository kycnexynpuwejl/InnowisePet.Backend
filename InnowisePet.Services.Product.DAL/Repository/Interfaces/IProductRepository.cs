using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.DAL.Repository.Interfaces;

public interface IProductRepository
{
    Task<PaginatedProductsDto> GetProductsAsync(ProductFilter productFilter);
    
    Task<ProductModel> GetProductByIdAsync(Guid productId);

    Task<PaginatedProductsDto> GetProductsByCategoryIdAsync(Guid categoryId, ProductFilter productFilter);
    
    Task<Guid> CreateProductAsync(ProductModel productModel);
    
    Task UpdateProductAsync(ProductModel productModel);
    
    Task DeleteProductAsync(Guid id);
    Task<PaginatedProductsDto> GetProductsByFilterAsync(FilterModel filter);
}