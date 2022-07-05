using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.DTO.Product;

namespace InnowisePet.Services.Product.BLL.Services;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    Task<ProductGetDto> GetProductByIdAsync(Guid id);
    Task<IEnumerable<CategoryGetDto>> GetCategoriesAsync();
    Task CreateProductAsync(ProductCreateDto productCreateDto);
    Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
    Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
    Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
    Task DeleteProductAsync(Guid id);
    Task DeleteCategoryAsync(Guid id);
}