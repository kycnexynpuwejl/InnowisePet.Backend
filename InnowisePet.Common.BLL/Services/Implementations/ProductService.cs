using AutoMapper;
using InnowisePet.Common.BLL.Services.Interfaces;
using InnowisePet.Common.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Common.BLL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
    {
        IEnumerable<Product> result = await _productRepository.GetProductsAsync();

        return _mapper.Map<IEnumerable<ProductGetDto>>(result);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(Guid id)
    {
        Product result = await _productRepository.GetProductByIdAsync(id);

        return _mapper.Map<ProductGetDto>(result);
    }

    public async Task<bool> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        Product product = _mapper.Map<Product>(productCreateDto);

        return await _productRepository.CreateProductAsync(product);
    }

    public async Task<bool> UpdateProductAsync(Guid id, ProductUpdateDto productUpdateDto)
    {
        Product product = _mapper.Map<Product>(productUpdateDto);

        return await _productRepository.UpdateProductAsync(id, product);
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        return await _productRepository.DeleteProductAsync(id);
    }
}