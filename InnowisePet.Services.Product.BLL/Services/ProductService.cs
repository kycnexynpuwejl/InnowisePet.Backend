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

    public async Task<IEnumerable<DAL.Product>> GetProducts()
    {
        return await _productRepository.GetProducts();
    }

    public async Task AddProduct(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<DAL.Product>(productCreateDto);
        
        await _productRepository.AddProduct(product);
    }
}