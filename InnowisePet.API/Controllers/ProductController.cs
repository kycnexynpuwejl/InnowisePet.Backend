using InnowisePet.BLL.Services.Implementations;
using InnowisePet.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _productService.GetProductsAsync());
    }
}