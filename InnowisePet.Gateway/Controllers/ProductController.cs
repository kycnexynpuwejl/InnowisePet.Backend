using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly ProductClient _productClient;

    public ProductController(ProductClient productClient)
    {
        _productClient = productClient;
    }

    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _productClient.GetProductsAsync());
    }

    /// <summary>
    /// Gets specified product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _productClient.GetProductByIdAsync(id));
    }

    /// <summary>
    /// Creates product
    /// </summary>
    /// <param name="productCreateDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _productClient.CreateProductAsync(productCreateDto);
        
        return Ok();
    }

    /// <summary>
    /// Updates product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="productUpdateDto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id,
        [FromBody] ProductUpdateDto productUpdateDto)
    {
        productUpdateDto.Id = id;
        await _productClient.UpdateProductAsync(productUpdateDto);
        
        return Ok();
    }

    /// <summary>
    /// Deletes product by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
    {
        await _productClient.DeleteProductAsync(id);
        
        return Ok();
    }

    
}