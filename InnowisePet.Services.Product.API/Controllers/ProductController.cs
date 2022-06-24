using InnowisePet.Services.Product.BLL.DTO;
using InnowisePet.Services.Product.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Product.API.Controllers;

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
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _productService.GetProducts());
    }

    [HttpPost]
    public async Task AddProduct(ProductCreateDto productCreateDto)
    {
        await _productService.AddProduct(productCreateDto);
    }
}