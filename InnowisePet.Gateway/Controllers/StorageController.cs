using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.ProductStorage;
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

    [HttpGet]
    public async Task<IActionResult> GetStoragesAsync()
    {
        return Ok(await _storageClient.GetStoragesAsync());
    }

    [HttpGet("{storageId}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid storageId)
    {
        return Ok(await _storageClient.GetStorageByIdAsync(storageId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStorageAsync([FromBody]StorageCreateDto storageCreateDto)
    {
        await _storageClient.CreateStorageAsync(storageCreateDto);
        
        return Ok();
    }

    [HttpPut("{storageId}")]
    public async Task<IActionResult> UpdateStorageAsync(
        [FromRoute] Guid storageId,
        [FromBody] StorageUpdateDto storageUpdateDto)
    {
        storageUpdateDto.Id = storageId;
        await _storageClient.UpdateStorageAsync(storageUpdateDto);
        
        return Ok();
    }

    [HttpDelete("{storageId}")]
    public async Task<IActionResult> DeleteStorageAsync([FromRoute] Guid storageId)
    {
        await _storageClient.DeleteStorageAsync(new StorageDeleteDto() { Id = storageId });
        
        return Ok();
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _storageClient.GetProductStoragesAsync());
    }

    [HttpGet("{storageId}/product")]
    public async Task<IActionResult> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        return Ok(await _storageClient.GetProductStoragesByStorageIdAsync(storageId));
    }

    [HttpPost("{storageId}/product")]
    public async Task<IActionResult> CreateProductStorageAsync(
        [FromRoute] Guid storageId,
        [FromBody] ProductStorageCreateDto productStorageCreateDto)
    {
        productStorageCreateDto.StorageId = storageId;
        await _storageClient.CreateProductStorageAsync(productStorageCreateDto);
        
        return Ok();
    }

    [HttpPut("{storageId}/product/{productId}")]
    public async Task<IActionResult> UpdateProductStorageAsync(
        [FromRoute]Guid storageId,
        [FromRoute]Guid productId,
        [FromBody]int quantity)
    {
        await _storageClient.UpdateProductStorageAsync(storageId, productId, quantity);

        return Ok();
    }

    [HttpDelete("{storageId}/product/{productId}")]
    public async Task<IActionResult> DeleteProductStorageAsync([FromRoute] Guid storageId, [FromRoute] Guid productId)
    {
        await _storageClient.DeleteProductStorageAsync(storageId, productId);

        return Ok();
    }
}