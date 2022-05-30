using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface IStorageRepository
{
    Task<IEnumerable<Storage>> GetStoragesAsync();
    Task<Storage> GetStorageByIdAsync(Guid id);
    Task<bool> CreateStorageAsync(Storage storage);
    Task<bool> UpdateStorageAsync(Guid id, Storage storage);
    Task<bool> DeleteStorageAsync(Guid id);
}