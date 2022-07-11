using InnowisePet.Models.DTO.Product;

namespace InnowisePet.Services.Product.BLL.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    
    Task<ProductGetDto> GetProductByIdAsync(Guid id);
    
    Task<Guid> CreateProductAsync(ProductCreateDto productCreateDto);
    
    Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
    
    Task DeleteProductAsync(Guid id);
}