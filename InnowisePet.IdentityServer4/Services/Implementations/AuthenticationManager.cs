using IdentityModel.Client;
using IdentityServer4;
using Microsoft.AspNetCore.Identity;
using InnowisePet.IdentityServer4.Models;
using InnowisePet.IdentityServer4.Models.DTO;
using InnowisePet.IdentityServer4.Services.Interfaces;

namespace InnowisePet.IdentityServer4.Services.Implementations;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthenticationManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<AppUser> ReturnUserIfValid(UserForAuthenticationDto userForAuth)
    {
        var user = await _userManager.FindByNameAsync(userForAuth.UserName);

        var res = await _signInManager.PasswordSignInAsync(userForAuth.UserName, userForAuth.Password, false, false);

        if (res.Succeeded)
        {
            return user;
        }
        return null;
    }

    public async Task<(string accessToken, string refreshToken)> GetTokens(UserForAuthenticationDto user)
    {
        var client = _httpClientFactory.CreateClient();
        PasswordTokenRequest tokenRequest = new PasswordTokenRequest()
        {
            Address = "https://localhost:7000/connect/token",
            ClientId = "APIClient",
            Scope = IdentityServerConstants.StandardScopes.OfflineAccess,
            UserName = user.UserName,
            Password = user.Password,
        };
        var tokenResponse = await client.RequestPasswordTokenAsync(tokenRequest);

        return (tokenResponse.AccessToken, tokenResponse.RefreshToken);
    }
}

