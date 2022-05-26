using AutoMapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.Models;

namespace InnowisePet.BLL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var result =  await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }
}