using InnowisePet.Identity.Models.DTO;

namespace InnowisePet.Identity.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<AuthenticatedUserInfo> AuthenticateUser(UserForAuthenticationDto user);
        public Task CreateUser(UserForCreationDto userForCreation);
        public Task AddRoleToUser(string login, string role);
    }
}
