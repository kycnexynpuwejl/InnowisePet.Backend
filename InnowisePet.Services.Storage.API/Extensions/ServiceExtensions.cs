using MassTransit;

namespace InnowisePet.Services.Storage.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq();
        });
    }
}