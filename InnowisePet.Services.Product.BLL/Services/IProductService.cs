using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.DTO.Product;

namespace InnowisePet.Services.Product.BLL.Services;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    
    Task<ProductGetDto> GetProductByIdAsync(Guid id);
    
    Task CreateProductAsync(ProductCreateDto productCreateDto);
    
    Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
    
    Task DeleteProductAsync(Guid id);
    
    Task<IEnumerable<CategoryGetDtoList>> GetCategoriesAsync();
    
    Task<CategoryGetDto> GetCategoryByIdAsync(Guid id);
    
    Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
    
    Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
    
    Task DeleteCategoryAsync(Guid id);
}