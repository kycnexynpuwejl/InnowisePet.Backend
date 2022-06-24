using InnowisePet.Services.Product.BLL.DTO;

namespace InnowisePet.Services.Product.BLL.Services;

public interface IProductService
{
    Task<IEnumerable<DAL.Product>> GetProductsAsync();
    Task AddProductAsync(ProductCreateDto productCreateDto);
    Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
    Task DeleteProductAsync(string id);
}