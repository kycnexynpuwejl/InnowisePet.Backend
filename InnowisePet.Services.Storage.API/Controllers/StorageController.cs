using InnowisePet.Services.Storage.BLL.DTO;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _storageService.GetStorageByIdAsync(id));
    }

    [HttpPost]
    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        await _storageService.CreateStorageAsync(storageCreateDto);
    }

    [HttpPost("{id}")]
    public async Task AddProductToStorageAsync([FromRoute]Guid id, [FromBody]ProductStorageCreateDto productStorageCreateDto)
    {
        productStorageCreateDto.StorageId = id;
        await _storageService.AddProductToStorageAsync(productStorageCreateDto);
    }
    
}