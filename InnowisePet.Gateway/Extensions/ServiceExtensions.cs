using InnowisePet.HttpClients;

namespace InnowisePet.Common.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<OrderClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["OrderServiceUri"]);
        });
        services.AddHttpClient<ProductClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["ProductServiceUri"]);
        });

        services.AddHttpClient<StorageClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["StorageServiceUri"]);
        });
    }
}