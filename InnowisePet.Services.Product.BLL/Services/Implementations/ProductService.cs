using AutoMapper;
using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using InnowisePet.Services.Product.DAL.Repository.Interfaces;

namespace InnowisePet.Services.Product.BLL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<PaginatedProductsDto> GetProductsAsync(ProductFilter productFilter)
    {
        return await _productRepository.GetProductsAsync(productFilter);
    }
    
    public async Task<ProductGetDto> GetProductByIdAsync(Guid productId)
    {
        return _mapper.Map<ProductGetDto>(await _productRepository.GetProductByIdAsync(productId));
    }

    public async Task<PaginatedProductsDto> GetProductsByCategoryIdAsync(Guid categoryId, ProductFilter productFilter)
    {
        return await _productRepository.GetProductsByCategoryIdAsync(categoryId, productFilter);
    }
    
    public async Task<Guid> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        ProductModel mappedProduct = _mapper.Map<ProductModel>(productCreateDto);
        
        return await _productRepository.CreateProductAsync(mappedProduct);
    }

    public async Task UpdateProductAsync(ProductUpdateDto productUpdateDto)
    {
        await _productRepository.UpdateProductAsync(_mapper.Map<ProductModel>(productUpdateDto));
    }
    
    public async Task DeleteProductAsync(Guid id)
    {
        await _productRepository.DeleteProductAsync(id);
    }
}