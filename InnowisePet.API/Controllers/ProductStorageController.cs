using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.DTO.DTO.ProductStorage;
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
    public async Task<IActionResult> CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        return Ok(await _productStorageService.CreateProductStorageAsync(productStorageCreateDto));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductStorageAsync([FromRoute] Guid id, [FromBody] ProductStorageUpdateDto productUpdateDto)
    {
        return Ok(await _productStorageService.UpdateProductStorageAsync(id, productUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductStorageAsync([FromRoute] Guid id)
    {
        return Ok(await _productStorageService.DeleteProductStorageAsync(id));
    }
}