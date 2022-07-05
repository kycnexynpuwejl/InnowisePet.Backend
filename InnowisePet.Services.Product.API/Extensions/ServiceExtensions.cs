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
            x.AddConsumer<ProductUpdateConsumer>();
            x.AddConsumer<ProductDeleteConsumer>();
            x.AddConsumer<CategoryCreateConsumer>();
            x.AddConsumer<CategoryUpdateConsumer>();
            x.AddConsumer<CategoryDeleteConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("ProductCreateQueue", e =>  e.ConfigureConsumer<ProductCreateConsumer>(context));
                cfg.ReceiveEndpoint("ProductUpdateQueue", e => e.ConfigureConsumer<ProductUpdateConsumer>(context));
                cfg.ReceiveEndpoint("ProductDeleteQueue", e => e.ConfigureConsumer<ProductDeleteConsumer>(context));
                cfg.ReceiveEndpoint("CategoryCreateQueue", e => e.ConfigureConsumer<CategoryCreateConsumer>(context));
                cfg.ReceiveEndpoint("CategoryUpdateQueue", e => e.ConfigureConsumer<CategoryUpdateConsumer>(context));
                cfg.ReceiveEndpoint("CategoryDeleteQueue", e => e.ConfigureConsumer<CategoryDeleteConsumer>(context));
            });
        });
    }
}