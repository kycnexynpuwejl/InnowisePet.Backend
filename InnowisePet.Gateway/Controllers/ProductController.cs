using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly ProductClient _productClient;

    public ProductController(ProductClient productClient)
    {
        _productClient = productClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _productClient.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _productClient.GetProductByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _productClient.CreateProductAsync(productCreateDto);
        
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id,
        [FromBody] ProductUpdateDto productUpdateDto)
    {
        productUpdateDto.Id = id;
        await _productClient.UpdateProductAsync(productUpdateDto);
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
    {
        await _productClient.DeleteProductAsync(id);
        
        return Ok();
    }

    
}