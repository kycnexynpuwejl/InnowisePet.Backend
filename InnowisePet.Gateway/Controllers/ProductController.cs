using InnowisePet.DTO.DTO.Product;
using InnowisePet.HttpClients;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly ProductClient _productClient;
    private readonly IPublishEndpoint _publishEndpoint;

    public ProductController(IPublishEndpoint publishEndpoint, ProductClient productClient)
    {
        _publishEndpoint = publishEndpoint;
        _productClient = productClient;
    }

    [HttpGet("list")]
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

    /*[HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id,
        [FromBody] ProductUpdateDto productUpdateDto)
    {
        return Ok(await _productService.UpdateProductAsync(id, productUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
    {
        return Ok(await _productService.DeleteProductAsync(id));
    }*/
}