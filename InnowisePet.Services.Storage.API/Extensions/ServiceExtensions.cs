using InnowisePet.Services.Storage.BLL.Consumers;
using MassTransit;

namespace InnowisePet.Services.Storage.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<StorageCreateConsumer>();
            x.AddConsumer<StorageUpdateConsumer>();
            x.AddConsumer<StorageDeleteConsumer>();
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("StorageCreateQueue", e =>  e.ConfigureConsumer<StorageCreateConsumer>(context));
                cfg.ReceiveEndpoint("StorageUpdateQueue", c => c.ConfigureConsumer<StorageUpdateConsumer>(context));
                cfg.ReceiveEndpoint("StorageDeleteQueue", c => c.ConfigureConsumer<StorageDeleteConsumer>(context));
            });
        });
    }
}