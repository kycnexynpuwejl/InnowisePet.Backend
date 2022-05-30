using IdentityModel;
using IdentityServer4.Models;

namespace InnowisePet.Identity;

public static class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("InnowisePetAPI", "Web API")
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("InnowisePetAPI", "Web API", new []{JwtClaimTypes.Name})
            {
                Scopes = {"InnowisePetAPI"}
            }
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "innowise-pet-api",
                ClientName = "InnowisePet Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-oidc"
                },
                AllowedCorsOrigins =
                {
                    "http://..."
                },
                PostLogoutRedirectUris =
                {
                    "http://.../signout-oidc"
                },
                AllowedScopes =
                {
                    OidcConstants.StandardScopes.OpenId,
                    OidcConstants.StandardScopes.Profile,
                    "InnowisePetAPI"
                },
                AllowAccessTokensViaBrowser = true
            }
        };
}