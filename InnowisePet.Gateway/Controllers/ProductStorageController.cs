using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.ProductStorage;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductStorageController : Controller
{
    private readonly StorageClient _storageClient;

    public ProductStorageController(StorageClient storageClient)
    {
        _storageClient = storageClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _storageClient.GetProductStoragesAsync());
    }

    [HttpGet("{storageId}")]
    public async Task<IActionResult> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        return Ok(await _storageClient.GetProductStoragesByStorageIdAsync(storageId));
    }
    
    [HttpPost("{storageId}")]
    public async Task<IActionResult> CreateProductStorageAsync(
        [FromRoute] Guid storageId,
        [FromBody] ProductStorageCreateDto productStorageCreateDto)
    {
        productStorageCreateDto.StorageId = storageId;
        await _storageClient.CreateProductStorageAsync(productStorageCreateDto);
        
        return Ok();
    }

    [HttpPut("{storageId}/{productId}")]
    public async Task<IActionResult> UpdateProductStorageAsync(
        [FromRoute]Guid storageId,
        [FromRoute]Guid productId,
        [FromBody]int quantity)
    {
        await _storageClient.UpdateProductStorageAsync(storageId, productId, quantity);

        return Ok();
    }

    [HttpDelete("{storageId}/{productId}")]
    public async Task<IActionResult> DeleteProductStorageAsync([FromRoute] Guid storageId, [FromRoute] Guid productId)
    {
        await _storageClient.DeleteProductStorageAsync(storageId, productId);

        return Ok();
    }
}