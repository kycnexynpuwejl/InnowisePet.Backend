using IdentityServer4.Models;

namespace InnowisePet.IdentityServerTest;

public class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string>{"role"}
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[] { new ApiScope("InnowisePet.API.read"), new ApiScope("InnowisePet.API.write") };

    public static IEnumerable<ApiResource> ApiResources =>
        new[]
        {
            new ApiResource("InnowisePet.API")
            {
                Scopes = new List<string> { "InnowisePet.API.read", "InnowisePet.API.write" },
                ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                UserClaims = new List<string> { "role" }
            }
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                AllowedScopes = { "InnowisePet.API.read", "InnowisePet.API.write" }
            },
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = {new Secret("ClientSecret1".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"https://localhost:1111/signin-oidc"},
                FrontChannelLogoutUri = "https://localhost:1111/signout-oidc",
                PostLogoutRedirectUris = {"https://localhost:1111/signout-callback-oidc"},
                AllowOfflineAccess = true,
                AllowedScopes = {"openid", "profile", "InnowisePet.API.read"},
                RequirePkce = true,
                RequireConsent = true,
                AllowPlainTextPkce = false
            }
        };
}