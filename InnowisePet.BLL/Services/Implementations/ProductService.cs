using AutoMapper;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
    {
        var result =  await _productRepository.GetProductsAsync();

        return _mapper.Map<IEnumerable<ProductGetDto>>(result);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(Guid id)
    {
        var result = await _productRepository.GetProductByIdAsync(id);
        var category = await _categoryRepository.GetCategoryById(result.category_id);
        var mappedResult = _mapper.Map<ProductGetDto>(result);
        mappedResult.CategoryName = category.title;
        
        return mappedResult;
    }

    public async Task<bool> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<Product>(productCreateDto);

        return await _productRepository.CreateProductAsync(product);
    }

    public async Task<bool> UpdateProductAsync(Guid id, ProductUpdateDto productUpdateDto)
    {
        var product = _mapper.Map<Product>(productUpdateDto);

        return await _productRepository.UpdateProductAsync(id, product);
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        return await _productRepository.DeleteProductAsync(id);
    }
}