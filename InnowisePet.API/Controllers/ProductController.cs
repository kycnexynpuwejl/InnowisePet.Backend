using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.DTO.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _productService.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _productService.GetProductByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        return Ok(await _productService.CreateProductAsync(productCreateDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id, [FromBody] ProductUpdateDto productUpdateDto)
    {
        return Ok(await _productService.UpdateProductAsync(id, productUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
    {
        return Ok(await _productService.DeleteProductAsync(id));
    }
}