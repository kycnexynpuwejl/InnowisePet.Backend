using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductStorageController : Controller
{
    private readonly IProductStorageService _productStorageService;
    
    public ProductStorageController(IProductStorageService productStorageService)
    {
        _productStorageService = productStorageService;
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _productStorageService.GetProductStoragesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductStorageByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _productStorageService.GetProductStorageByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        return Ok(await _productStorageService.CreateProductStorageAsync(productStorageCreateDto));
    }
}