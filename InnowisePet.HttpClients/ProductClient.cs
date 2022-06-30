using InnowisePet.DTO.DTO.Product;

namespace InnowisePet.HttpClients;

public class ProductClient
{
    private const string Url = "api/product/";
    
    private readonly HttpClient _httpClient;

    public ProductClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
}