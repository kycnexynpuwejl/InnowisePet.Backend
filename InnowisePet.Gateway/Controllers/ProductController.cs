using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;
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
    public async Task<IActionResult> GetProductsAsync([FromQuery]int pageSize = 6,[FromQuery] int pageNumber = 1, [FromQuery]string search = null)
    {
        return Ok(await _productClient.GetProductsAsync(pageSize, pageNumber, search));
    }

    /// <summary>
    /// Gets specified product by productId
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid productId)
    {
        return Ok(await _productClient.GetProductByIdAsync(productId));
    }

    /// <summary>
    /// Gets all products from specified category by categoryId
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategoryIdAsync(Guid categoryId, [FromQuery]int pageSize,[FromQuery] int pageNumber, [FromQuery]string search)
    {
        return Ok(await _productClient.GetProductsByCategoryIdAsync(categoryId, pageSize, pageNumber, search));
    }

    [HttpPost("filter")]
    public async Task<IActionResult> GetProductsByFilterAsync([FromBody]FilterModel filter)
    {
        return Ok(await _productClient.GetProductsByFilterAsync(filter));
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