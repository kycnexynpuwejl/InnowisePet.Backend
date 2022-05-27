using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        return Ok(await _categoryService.GetCategoriesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        return Ok(await _categoryService.GetCategoryByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        return Ok(await _categoryService.CreateCategoryAsync(categoryCreateDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto)
    {
        return Ok(await _categoryService.UpdateCategoryAsync(id, categoryUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id)
    {
        return Ok(await _categoryService.DelateCategoryAsync(id));
    }
}