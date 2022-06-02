using InnowisePet.Identity.Data;
using InnowisePet.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace InnowisePet.Identity.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 1;

            }).AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddAspNetIdentity<AppUser>()
            .AddInMemoryApiResources(IdentityConfiguration.BuildApiResources())
            .AddInMemoryClients(IdentityConfiguration.BuildClients(configuration))
            .AddInMemoryIdentityResources(IdentityConfiguration.BuildIdentityResources())
            .AddInMemoryApiScopes(IdentityConfiguration.BuildApiScopes())
            .AddDeveloperSigningCredential();

        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = "InnowisePet.Identity.Cookie";
            config.LoginPath = "/Account/Login";
        });
    }
}