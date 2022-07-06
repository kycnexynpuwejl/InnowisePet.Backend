using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Services;

public interface IStorageService
{
    Task<IEnumerable<StorageGetDtoList>> GetStoragesAsync();
    
    Task<StorageGetDto> GetStorageByIdAsync(Guid id);
    
    Task CreateStorageAsync(StorageCreateDto storageCreateDto);
    
    Task UpdateStorageAsync(StorageUpdateDto storageUpdateDto);
    
    Task DeleteStorageAsync(Guid id);

    Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesAsync();
    
    Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesByStorageIdAsync(Guid storageId);
    
    Task CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto);
    
    Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto);
    
    Task DeleteProductStorageAsync(Guid storageId, Guid productId);
}