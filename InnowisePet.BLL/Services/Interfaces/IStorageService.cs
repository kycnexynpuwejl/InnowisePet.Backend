using InnowisePet.DTO.DTO;

namespace InnowisePet.BLL.Services.Interfaces;

public interface IStorageService
{
    Task<IEnumerable<StorageGetDto>> GetStoragesAsync();
    Task<StorageGetDto> GetStorageByIdAsync(Guid id);
    Task<bool> CreateStorageAsync(StorageCreateDto storageCreateDto);
    Task<bool> UpdateStorageAsync(Guid id, StorageUpdateDto storageUpdateDto);
    Task<bool> DeleteStorageAsync(Guid id);
}