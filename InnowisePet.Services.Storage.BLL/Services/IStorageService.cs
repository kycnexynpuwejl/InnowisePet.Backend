using InnowisePet.Services.Storage.BLL.DTO;

namespace InnowisePet.Services.Storage.BLL.Services;

public interface IStorageService
{
    Task<IEnumerable<DAL.Models.Storage>> GetStoragesAsync();
    Task<DAL.Models.Storage> GetStorageByIdAsync(Guid id);
    Task CreateStorageAsync(StorageCreateDto storageCreateDto);
    Task AddProductToStorageAsync(ProductStorageCreateDto productStorageCreateDto);
}