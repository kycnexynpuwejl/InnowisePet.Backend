using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Category;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly CategoryClient _categoryClient;

    public CategoryController(CategoryClient categoryClient)
    {
        _categoryClient = categoryClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        return Ok(await _categoryClient.GetCategoriesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        return Ok(await _categoryClient.GetCategoryByIdAsync(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        await _categoryClient.CreateCategoryAsync(categoryCreateDto);

        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync([FromRoute] Guid id, [FromBody]CategoryUpdateDto dto)
    {
        dto.Id = id;
        await _categoryClient.UpdateCategoryAsync(dto);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryASync([FromRoute] Guid id)
    {
        await _categoryClient.DeleteCategoryAsync(id);

        return Ok();
    }
}