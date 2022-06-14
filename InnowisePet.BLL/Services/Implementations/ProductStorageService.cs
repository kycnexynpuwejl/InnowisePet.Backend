using AutoMapper;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Implementations;

public class ProductStorageService : IProductStorageService
{
    private readonly IMapper _mapper;
    private readonly IProductStorageRepository _productStorageRepository;

    public ProductStorageService(IProductStorageRepository productStorageRepository, IMapper mapper)
    {
        _productStorageRepository = productStorageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesAsync()
    {
        IEnumerable<ProductStorage> result = await _productStorageRepository.GetProductStoragesAsync();

        return _mapper.Map<IEnumerable<ProductStorageGetDto>>(result);
    }

    public async Task<ProductStorageGetDto> GetProductStorageByIdAsync(Guid id)
    {
        ProductStorage result = await _productStorageRepository.GetProductStorageByIdAsync(id);
        ProductStorageGetDto mappedResult = _mapper.Map<ProductStorageGetDto>(result);

        return mappedResult;
    }

    public async Task<bool> CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        ProductStorage productStorage = _mapper.Map<ProductStorage>(productStorageCreateDto);

        return await _productStorageRepository.CreateProductStorageAsync(productStorage);
    }

    public async Task<bool> UpdateProductStorageAsync(Guid id, ProductStorageUpdateDto productStorageUpdateDto)
    {
        ProductStorage product = _mapper.Map<ProductStorage>(productStorageUpdateDto);

        return await _productStorageRepository.UpdateProductStorageAsync(id, product);
    }

    public async Task<bool> DeleteProductStorageAsync(Guid id)
    {
        return await _productStorageRepository.DeleteProductStorageAsync(id);
    }
}