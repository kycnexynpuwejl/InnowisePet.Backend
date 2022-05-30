using InnowisePet.DTO.DTO.User;

namespace InnowisePet.BLL.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserGetDto>> GetUsersAsync();
    Task<UserGetDto> GetUserByIdAsync(Guid id);
    Task<bool> CreateUserAsync(UserCreateDto userCreateDto);
    Task<bool> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
    Task<bool> DeleteUserAsync(Guid id);
}