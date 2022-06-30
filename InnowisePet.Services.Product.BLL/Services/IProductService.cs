using InnowisePet.Services.Product.BLL.DTO;

namespace InnowisePet.Services.Product.BLL.Services;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    Task<ProductGetDto> GetProductByIdAsync(Guid id);
    Task CreateProductAsync(ProductCreateDto productCreateDto);
    Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
    Task DeleteProductAsync(Guid id);
}