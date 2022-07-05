using InnowisePet.Models.DTO.Category;
using InnowisePet.Services.Product.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class CategoryCreateConsumer : IConsumer<CategoryCreateDto>
{
    private readonly IProductService _productService;

    public CategoryCreateConsumer(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Consume(ConsumeContext<CategoryCreateDto> context)
    {
        await _productService.CreateCategoryAsync(context.Message);
    }
}