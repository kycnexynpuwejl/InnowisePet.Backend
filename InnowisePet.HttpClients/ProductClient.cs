using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.DTO.Product;
using MassTransit;

namespace InnowisePet.HttpClients;

public class ProductClient
{
    private const string Url = "api/product/";

    private readonly IPublishEndpoint _publishEndpoint;
    private readonly HttpClient _httpClient;

    public ProductClient(HttpClient httpClient, IPublishEndpoint publishEndpoint)
    {
        _httpClient = httpClient;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<ProductGetDto>>(result);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + id);

        return await CommonHttpClientExtensions.Deserialize<ProductGetDto>(result);
    }

    public async Task<IEnumerable<CategoryGetDto>> GetCategoriesAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + "category");

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<CategoryGetDto>>(result);
    }

    public async Task CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _publishEndpoint.Publish(productCreateDto);
    }
    
    public async Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        await _publishEndpoint.Publish(categoryCreateDto);
    }
    
    public async Task UpdateProductAsync(ProductUpdateDto productUpdateDto)
    {
        await _publishEndpoint.Publish(productUpdateDto);
    }

    public async Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
    {
        await _publishEndpoint.Publish(categoryUpdateDto);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        ProductDeleteDto productDeleteDto = new() { Id = id };
        await _publishEndpoint.Publish(productDeleteDto);
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        CategoryDeleteDto categoryDeleteDto = new() { Id = id };
        await _publishEndpoint.Publish(categoryDeleteDto);
    }
}