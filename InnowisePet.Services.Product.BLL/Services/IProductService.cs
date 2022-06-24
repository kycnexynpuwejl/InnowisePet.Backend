using InnowisePet.Services.Product.BLL.DTO;

namespace InnowisePet.Services.Product.BLL.Services;

public interface IProductService
{
    Task<IEnumerable<DAL.Product>> GetProducts();
    Task AddProduct(ProductCreateDto productCreateDto);
}