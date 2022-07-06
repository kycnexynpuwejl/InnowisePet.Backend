using InnowisePet.Services.Storage.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Storage.API.Controllers;

public class ProductStorageController : Controller
{
    private readonly IStorageService _storageService;

    public ProductStorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _storageService.GetProductStoragesAsync());
    }

    [HttpGet("{storageId}")]
    public async Task<IActionResult> GetProductStoragesByStorageIdAsync([FromRoute]Guid storageId)
    {
        return Ok(await _storageService.GetProductStoragesByStorageIdAsync(storageId));
    }
}