using InnowisePet.Services.Storage.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : Controller
{
    private readonly IStorageService _storageService;
    
    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStoragesAsync()
    {
        return Ok(await _storageService.GetStoragesAsync());
    }

    [HttpGet("{storageID}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid storageID)
    {
        return Ok(await _storageService.GetStorageByIdAsync(storageID));
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _storageService.GetProductStoragesAsync());
    }

    [HttpGet("{storageId}/product")]
    public async Task<IActionResult> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        return Ok(await _storageService.GetProductStoragesByStorageIdAsync(storageId));
    }
}