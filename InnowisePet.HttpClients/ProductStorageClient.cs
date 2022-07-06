using InnowisePet.Models.DTO.ProductStorage;
using MassTransit;

namespace InnowisePet.HttpClients;

public class ProductStorageClient
{
    private const string Url = "api/productstorage/";
    
    private readonly HttpClient _httpClient;
    private readonly IPublishEndpoint _publishEndpoint;

    public ProductStorageClient(IPublishEndpoint publishEndpoint, HttpClient httpClient)
    {
        _publishEndpoint = publishEndpoint;
        _httpClient = httpClient;
    }
    
    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + "product");

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<ProductStorageGetDto>>(result);
    }

    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + $"{storageId}" + "/product");

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<ProductStorageGetDto>>(result);
    }
    
    public async Task CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        await _publishEndpoint.Publish(productStorageCreateDto);
    }

    public async Task UpdateProductStorageAsync(Guid storageId, Guid productId, int quantity)
    {
        await _publishEndpoint.Publish(new ProductStorageUpdateDto()
        {
            StorageId = storageId,
            ProductId = productId,
            Quantity = quantity
        });
    }

    public async Task DeleteProductStorageAsync(Guid storageId, Guid productId)
    {
        await _publishEndpoint.Publish(new ProductStorageDeleteDto()
        {
            StorageId = storageId,
            ProductId = productId
        });
    }
}