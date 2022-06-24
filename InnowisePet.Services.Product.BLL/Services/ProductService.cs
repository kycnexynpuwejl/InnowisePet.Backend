using AutoMapper;
using InnowisePet.Services.Product.BLL.DTO;
using InnowisePet.Services.Product.DAL;

namespace InnowisePet.Services.Product.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DAL.Product>> GetProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }

    public async Task AddProductAsync(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<DAL.Product>(productCreateDto);
        
        await _productRepository.AddProductAsync(product);
    }

    public async Task UpdateProductAsync(ProductUpdateDto productUpdateDto)
    {
        var product = _mapper.Map<DAL.Product>(productUpdateDto);
        
        await _productRepository.UpdateProductAsync(product);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productRepository.DeleteProductAsync(id);
    }
}