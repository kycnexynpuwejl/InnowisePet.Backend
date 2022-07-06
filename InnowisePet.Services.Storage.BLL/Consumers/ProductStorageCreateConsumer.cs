using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Services.Storage.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class ProductStorageCreateConsumer : IConsumer<ProductStorageCreateDto>
{
    private readonly IStorageService _storageService;

    public ProductStorageCreateConsumer(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task Consume(ConsumeContext<ProductStorageCreateDto> context)
    {
        await _storageService.CreateProductStorageAsync(context.Message);
    }
}