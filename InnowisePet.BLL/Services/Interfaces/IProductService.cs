using InnowisePet.DTO.DTO;
using InnowisePet.Models;

namespace InnowisePet.BLL.Services.Implementations;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
}