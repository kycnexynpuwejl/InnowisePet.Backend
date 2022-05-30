using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task<bool> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(Guid id, User user);
    Task<bool> DeleteUserAsync(Guid id);
}