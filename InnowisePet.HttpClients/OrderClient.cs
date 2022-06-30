using InnowisePet.DTO.DTO.Order;

namespace InnowisePet.HttpClients;

public class OrderClient : IOrderClient
{
    private const string Url = "api/order/";

    private readonly HttpClient _httpClient;
    private readonly IPublishEndpoint _publishEndpoint;
    public OrderClient(HttpClient httpClient, IPublishEndpoint publishEndpoint)
    {
        _httpClient = httpClient;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<IEnumerable<OrderGetDto>> GetOrdersAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<OrderGetDto>>(result);
    }

    public async Task<OrderGetDto> GetOrderByIdAsync(Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + $"{id}");

        return await CommonHttpClientExtensions.Deserialize<OrderGetDto>(result);
    }

    public async Task CreateOrderAsync()
    {
        
    }
}