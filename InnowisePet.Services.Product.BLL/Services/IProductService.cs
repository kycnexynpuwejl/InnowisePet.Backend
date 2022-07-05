using InnowisePet.DTO.Product;

namespace InnowisePet.Services.Product.BLL.Services;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    Task<ProductGetDto> GetProductByIdAsync(Guid id);
    Task CreateProductAsync(ProductCreateDto productCreateDto);
    Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
    Task DeleteProductAsync(Guid id);
}