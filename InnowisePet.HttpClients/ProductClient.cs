using InnowisePet.DTO.Product;
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
        HttpResponseMessage result = await _httpClient.GetAsync(Url + $"{id}");

        return await CommonHttpClientExtensions.Deserialize<ProductGetDto>(result);
    }

    public async Task CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _publishEndpoint.Publish(productCreateDto);
    }
}