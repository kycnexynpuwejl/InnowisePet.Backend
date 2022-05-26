using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models;

namespace InnowisePet.BLL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<IEnumerable<Product>> GetProductsAsync()
    {
        return _productRepository.GetProductsAsync();
    }
}