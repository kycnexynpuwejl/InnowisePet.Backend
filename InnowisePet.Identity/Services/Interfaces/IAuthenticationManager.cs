using InnowisePet.Identity.Models;
using InnowisePet.Identity.Models.DTO;

namespace InnowisePet.Identity.Services.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<AppUser> ReturnUserIfValid(UserForAuthenticationDto userForAuthentication);
        Task<(string accessToken, string refreshToken)> GetTokens(UserForAuthenticationDto user);
    }
}
