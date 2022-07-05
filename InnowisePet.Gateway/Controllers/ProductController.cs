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

    [HttpGet("category")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        return Ok(await _productClient.GetCategoriesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _productClient.CreateProductAsync(productCreateDto);
        
        return Ok();
    }

    [HttpPost("category")]
    public async Task<IActionResult> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        await _productClient.CreateCategoryAsync(categoryCreateDto);

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

    [HttpPut("category/{id}")]
    public async Task<IActionResult> UpdateCategoryAsync([FromRoute] Guid id,
        [FromBody]CategoryUpdateDto categoryUpdateDto)
    {
        categoryUpdateDto.Id = id;
        await _productClient.UpdateCategoryAsync(categoryUpdateDto);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
    {
        await _productClient.DeleteProductAsync(id);
        
        return Ok();
    }

    [HttpDelete("category/{id}")]
    public async Task<IActionResult> DeleteCategoryASync([FromRoute] Guid id)
    {
        await _productClient.DeleteCategoryAsync(id);

        return Ok();
    }
}