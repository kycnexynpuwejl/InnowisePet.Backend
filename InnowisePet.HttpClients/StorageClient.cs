using InnowisePet.DTO.Storage;

namespace InnowisePet.HttpClients;

public class StorageClient
{
    private const string Url = "api/storage/";

    private readonly HttpClient _httpClient;

    public StorageClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<StorageGetDto>> GetStoragesAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<StorageGetDto>>(result);
    }

    public async Task<StorageGetDto> GetStorageByIdAsync(Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + $"{id}");

        return await CommonHttpClientExtensions.Deserialize<StorageGetDto>(result);
    }
}