using InnowisePet.Models.DTO.Category;
using InnowisePet.Services.Product.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class CategoryDeleteConsumer : IConsumer<CategoryDeleteDto>
{
    private readonly IProductService _productService;

    public CategoryDeleteConsumer(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Consume(ConsumeContext<CategoryDeleteDto> context)
    {
        await _productService.DeleteCategoryAsync(context.Message.Id);
    }
}