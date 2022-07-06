using InnowisePet.Services.Product.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Product.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly IProductService _productService;

    public CategoryController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        return Ok(await _productService.GetCategoriesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        return Ok(await _productService.GetCategoryByIdAsync(id));
    }
}