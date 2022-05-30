using AutoMapper;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO.User;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserGetDto>> GetUsersAsync()
    {
        IEnumerable<User> result =  await _userRepository.GetUsersAsync();

        return _mapper.Map<IEnumerable<UserGetDto>>(result);
    }
    
    public async Task<UserGetDto> GetUserByIdAsync(Guid id)
    {
        User result = await _userRepository.GetUserByIdAsync(id);

        return _mapper.Map<UserGetDto>(result);
    }
    
    public async Task<bool> CreateUserAsync(UserCreateDto userCreateDto)
    {
        User user = _mapper.Map<User>(userCreateDto);

        return await _userRepository.CreateUserAsync(user);
    }
    
    public async Task<bool> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
    {
        User user = _mapper.Map<User>(userUpdateDto);

        return await _userRepository.UpdateUserAsync(id, user);
    }
    
    public async Task<bool> DeleteUserAsync(Guid id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
}