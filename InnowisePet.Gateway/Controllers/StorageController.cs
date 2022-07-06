using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Storage;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : Controller
{
    private readonly StorageClient _storageClient;

    public StorageController(StorageClient storageClient)
    {
        _storageClient = storageClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetStoragesAsync()
    {
        return Ok(await _storageClient.GetStoragesAsync());
    }

    [HttpGet("{storageId}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid storageId)
    {
        return Ok(await _storageClient.GetStorageByIdAsync(storageId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStorageAsync([FromBody]StorageCreateDto storageCreateDto)
    {
        await _storageClient.CreateStorageAsync(storageCreateDto);
        
        return Ok();
    }

    [HttpPut("{storageId}")]
    public async Task<IActionResult> UpdateStorageAsync(
        [FromRoute] Guid storageId,
        [FromBody] StorageUpdateDto storageUpdateDto)
    {
        storageUpdateDto.Id = storageId;
        await _storageClient.UpdateStorageAsync(storageUpdateDto);
        
        return Ok();
    }

    [HttpDelete("{storageId}")]
    public async Task<IActionResult> DeleteStorageAsync([FromRoute] Guid storageId)
    {
        await _storageClient.DeleteStorageAsync(new StorageDeleteDto() { Id = storageId });
        
        return Ok();
    }
}