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

    public async Task<PaginatedProductsDto> GetProductsAsync(int pageSize, int pageNumber,string search)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + $"?pagesize={pageSize}&pagenumber={pageNumber}&search={search}");

        return await CommonHttpClientExtensions.Deserialize<PaginatedProductsDto>(result);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(Guid productId)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + productId);

        return await CommonHttpClientExtensions.Deserialize<ProductGetDto>(result);
    }

    public async Task<PaginatedProductsDto> GetProductsByCategoryIdAsync(Guid categoryId, int pageSize, int pageNumber, string search)
    {
        HttpResponseMessage result = await _httpClient
            .GetAsync(Url + $"category/{categoryId}?pagesize={pageSize}&pagenumber={pageNumber}&search={search}");

        return await CommonHttpClientExtensions.Deserialize<PaginatedProductsDto>(result);
    }

    public async Task CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _publishEndpoint.Publish(productCreateDto);
    }

    public async Task UpdateProductAsync(ProductUpdateDto productUpdateDto)
    {
        await _publishEndpoint.Publish(productUpdateDto);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        ProductDeleteDto productDeleteDto = new() { Id = id };
        await _publishEndpoint.Publish(productDeleteDto);
    }
}