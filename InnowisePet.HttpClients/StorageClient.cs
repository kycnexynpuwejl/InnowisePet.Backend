using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.DTO.Storage;
using MassTransit;

namespace InnowisePet.HttpClients;

public class StorageClient
{
    private const string Url = "api/storage/";

    private readonly HttpClient _httpClient;
    private readonly IPublishEndpoint _publishEndpoint;

    public StorageClient(HttpClient httpClient, IPublishEndpoint publishEndpoint)
    {
        _httpClient = httpClient;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<IEnumerable<StorageGetDtoList>> GetStoragesAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<StorageGetDtoList>>(result);
    }

    public async Task<StorageGetDto> GetStorageByIdAsync(Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + id);

        return await CommonHttpClientExtensions.Deserialize<StorageGetDto>(result);
    }

    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        await _publishEndpoint.Publish(storageCreateDto);
    }

    public async Task UpdateStorageAsync(StorageUpdateDto storageUpdateDto)
    {
        await _publishEndpoint.Publish(storageUpdateDto);
    }

    public async Task DeleteStorageAsync(StorageDeleteDto storageDeleteDto)
    {
        await _publishEndpoint.Publish(storageDeleteDto);
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