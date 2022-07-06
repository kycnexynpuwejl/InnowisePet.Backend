using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Services.Storage.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class ProductStorageUpdateConsumer : IConsumer<ProductStorageUpdateDto>
{
    private readonly IStorageService _storageService;

    public ProductStorageUpdateConsumer(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task Consume(ConsumeContext<ProductStorageUpdateDto> context)
    {
        await _storageService.UpdateProductStorageAsync(context.Message);
    }
}