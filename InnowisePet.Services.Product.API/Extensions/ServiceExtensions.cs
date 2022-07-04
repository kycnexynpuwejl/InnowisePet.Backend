using InnowisePet.Services.Product.BLL.Consumers;
using MassTransit;

namespace InnowisePet.Services.Product.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ProductCreateConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("ProductCreateQueue", e => { e.ConfigureConsumer<ProductCreateConsumer>(context); });
            });
        });
    }
}