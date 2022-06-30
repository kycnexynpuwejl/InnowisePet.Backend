using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Product.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    /*[HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _productService.GetProductsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync(ProductCreateDto productCreateDto)
    {
        await _productService.AddProductAsync(productCreateDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] string id, [FromBody] ProductUpdateDto productUpdateDto)
    {
        productUpdateDto.Id = id;
        await _productService.UpdateProductAsync(productUpdateDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute]string id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok();
    }*/
}