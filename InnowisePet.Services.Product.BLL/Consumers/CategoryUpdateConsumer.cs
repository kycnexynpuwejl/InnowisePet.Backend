using InnowisePet.Models.DTO.Category;
using InnowisePet.Services.Product.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class CategoryUpdateConsumer : IConsumer<CategoryUpdateDto>
{
    private readonly IProductService _productService;

    public CategoryUpdateConsumer(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Consume(ConsumeContext<CategoryUpdateDto> context)
    {
        await _productService.UpdateCategoryAsync(context.Message);
    }
}