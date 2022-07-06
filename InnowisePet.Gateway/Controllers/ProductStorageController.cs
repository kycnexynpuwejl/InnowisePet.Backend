using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.ProductStorage;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductStorageController : Controller
{
    private readonly ProductStorageClient _productStorageClient;

    public ProductStorageController(ProductStorageClient productStorageClient)
    {
        _productStorageClient = productStorageClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _productStorageClient.GetProductStoragesAsync());
    }

    [HttpGet("{storageId}")]
    public async Task<IActionResult> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        return Ok(await _productStorageClient.GetProductStoragesByStorageIdAsync(storageId));
    }
    
    [HttpPost("{storageId}")]
    public async Task<IActionResult> CreateProductStorageAsync(
        [FromRoute] Guid storageId,
        [FromBody] ProductStorageCreateDto productStorageCreateDto)
    {
        productStorageCreateDto.StorageId = storageId;
        await _productStorageClient.CreateProductStorageAsync(productStorageCreateDto);
        
        return Ok();
    }

    [HttpPut("{storageId}/{productId}")]
    public async Task<IActionResult> UpdateProductStorageAsync(
        [FromRoute]Guid storageId,
        [FromRoute]Guid productId,
        [FromBody]int quantity)
    {
        await _productStorageClient.UpdateProductStorageAsync(storageId, productId, quantity);

        return Ok();
    }

    [HttpDelete("{storageId}/{productId}")]
    public async Task<IActionResult> DeleteProductStorageAsync([FromRoute] Guid storageId, [FromRoute] Guid productId)
    {
        await _productStorageClient.DeleteProductStorageAsync(storageId, productId);

        return Ok();
    }
}