using InnowisePet.DTO.DTO.Order;

namespace InnowisePet.HttpClients;

public class OrderClient
{
    private const string Url = "api/order";

    private readonly HttpClient _httpClient;

    public OrderClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<OrderGetDto>> GetOrdersAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<OrderGetDto>>(result);
    }

    public async Task<OrderGetDto> GetOrderByIdAsync(Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + "{id}");

        return await CommonHttpClientExtensions.Deserialize<OrderGetDto>(result);
    }
}