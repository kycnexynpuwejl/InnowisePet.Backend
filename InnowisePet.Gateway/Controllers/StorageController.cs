/*using InnowisePet.DTO.DTO.Storage;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : Controller
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetStoragesAsync()
    {
        return Ok(await _storageService.GetStoragesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _storageService.GetStorageByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        return Ok(await _storageService.CreateStorageAsync(storageCreateDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStorageAsync([FromRoute] Guid id,
        [FromBody] StorageUpdateDto storageUpdateDto)
    {
        return Ok(await _storageService.UpdateStorageAsync(id, storageUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStorageAsync([FromRoute] Guid id)
    {
        return Ok(await _storageService.DeleteStorageAsync(id));
    }
}*/