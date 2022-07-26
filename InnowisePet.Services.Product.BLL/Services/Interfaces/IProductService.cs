using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Services.Interfaces;

public interface IProductService
{
    Task<PaginatedProductsDto> GetProductsAsync(ProductFilter productFilter);
    
    Task<ProductGetDto> GetProductByIdAsync(Guid productId);

    Task<PaginatedProductsDto> GetProductsByCategoryIdAsync(Guid categoryId, ProductFilter productFilter);
    
    Task<Guid> CreateProductAsync(ProductCreateDto productCreateDto);
    
    Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
    
    Task DeleteProductAsync(Guid id);
    Task<PaginatedProductsDto> GetProductsByFilterAsync(FilterModel filter);
}