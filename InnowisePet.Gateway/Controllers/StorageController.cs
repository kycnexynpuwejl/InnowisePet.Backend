using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Storage;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : Controller
{
    private readonly StorageClient _storageClient;

    public StorageController(StorageClient storageClient)
    {
        _storageClient = storageClient;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetStoragesAsync()
    {
        return Ok(await _storageClient.GetStoragesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _storageClient.GetStorageByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStorageAsync([FromBody]StorageCreateDto storageCreateDto)
    {
        await _storageClient.CreateStorageAsync(storageCreateDto);
        
        return Ok();
    }

    /*[HttpPut("{id}")]
    public async Task<IActionResult> UpdateStorageAsync([FromRoute] Guid id,
        [FromBody] StorageUpdateDto storageUpdateDto)
    {
        return Ok(await _storageService.UpdateStorageAsync(id, storageUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStorageAsync([FromRoute] Guid id)
    {
        return Ok(await _storageService.DeleteStorageAsync(id));
    }*/
}