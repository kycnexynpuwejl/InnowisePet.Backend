using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace InnowisePet.IdentityServer4.Configurations;

public static class IdentityConfiguration
{
    public static string ScopeAPI => "APIScope";
    public static string ScopeRoles => "roles";

    public static IEnumerable<Client> Clients()
    {
        return new List<Client>
        {
            new()
            {
                ClientId = "APIClient",
                RequireClientSecret = false,

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OpenId,
                    ScopeAPI
                },

                AllowOfflineAccess = true
            }
        };
    }

    public static IEnumerable<ApiResource> ApiResources()
    {
        return new List<ApiResource>
        {
            new(ScopeAPI, new[] { JwtClaimTypes.Name, JwtClaimTypes.Role })
            {
                Scopes =
                {
                    ScopeAPI,
                    ScopeRoles,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };
    }

    public static IEnumerable<IdentityResource> IdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new() { Name = ScopeRoles, UserClaims = { JwtClaimTypes.Role } }
        };
    }

    public static IEnumerable<ApiScope> ApiScopes()
    {
        return new List<ApiScope>
        {
            new(ScopeAPI)
        };
    }
}