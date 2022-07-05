using AutoMapper;
using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.DAL.Repository;

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
    
    public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
    {
        return _mapper.Map<IEnumerable<ProductGetDto>>(await _productRepository.GetProductsAsync());
    }
    
    public async Task<ProductGetDto> GetProductByIdAsync(Guid id)
    {
        return _mapper.Map<ProductGetDto>(await _productRepository.GetProductByIdAsync(id));
    }

    public async Task<IEnumerable<CategoryGetDto>> GetCategoriesAsync()
    {
        return _mapper.Map<IEnumerable<CategoryGetDto>>(await _productRepository.GetCategoriesAsync());
    }

    public async Task CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _productRepository.CreateProductAsync(_mapper.Map<ProductModel>(productCreateDto));
    }

    public async Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        await _productRepository.CreateCategoryAsync(_mapper.Map<CategoryModel>(categoryCreateDto));
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