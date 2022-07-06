using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Services.Storage.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class ProductStorageDeleteConsumer : IConsumer<ProductStorageDeleteDto>
{
    private readonly IStorageService _storageService;

    public ProductStorageDeleteConsumer(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task Consume(ConsumeContext<ProductStorageDeleteDto> context)
    {
        await _storageService.DeleteProductStorageAsync(context.Message.StorageId, context.Message.ProductId);
    }
}