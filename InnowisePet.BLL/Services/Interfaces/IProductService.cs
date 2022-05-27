using InnowisePet.DTO.DTO;
using InnowisePet.Models;

namespace InnowisePet.BLL.Services.Implementations;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    Task<ProductGetDto> GetProductByIdAsync(Guid id);
    Task<bool> CreateProductAsync(ProductCreateDto productCreateDto);
}