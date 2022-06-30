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

    [HttpGet("{storageID}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid storageID)
    {
        return Ok(await _storageService.GetStorageByIdAsync(storageID));
    }

    [HttpPost]
    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        await _storageService.CreateStorageAsync(storageCreateDto);
    }

    [HttpPost("{storageID}/product/")]
    public async Task AddProductToStorageAsync([FromRoute]Guid storageID, [FromBody]ProductStorageCreateDto productStorageCreateDto)
    {
        productStorageCreateDto.StorageId = storageID;
        await _storageService.AddProductToStorageAsync(productStorageCreateDto);
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _storageService.GetProductsAsync());
    }

    [HttpGet("{storageId}/product")]
    public async Task<IActionResult> GetProductsByStorageIdAsync(Guid storageId)
    {
        return Ok(await _storageService.GetProductsByStorageIdAsync(storageId));
    }

    [HttpDelete("{storageId}/product/{productId}")]
    public async Task DeleteProductSorageAsync([FromRoute]Guid storageId, [FromRoute]string productId)
    {
        await _storageService.DeleteProductSorageAsync(storageId, productId);
    }

    [HttpPut("{storageId}/product/{productId}")]
    public async Task UpdateProductStorageAsync([FromRoute] Guid storageId, [FromRoute] Guid productId, [FromBody]int quantity)
    {
        await _storageService.UpdateProductStorageAsync(new ProductStorageUpdateDto
        {
            StorageId = storageId,
            ProductId = productId,
            Quantity = quantity
        });
    }
}