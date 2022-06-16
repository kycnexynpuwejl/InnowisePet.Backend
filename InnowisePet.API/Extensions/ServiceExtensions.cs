using InnowisePet.BLL.Services.Implementations;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Implementations;
using InnowisePet.DAL.Repo.Interfaces;

namespace InnowisePet.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ILocationService, LocationService>();
        
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<IStorageService, StorageService>();
        
        services.AddScoped<IProductStorageRepository, ProductStorageRepository>();
        services.AddScoped<IProductStorageService, ProductStorageService>();
    }
}