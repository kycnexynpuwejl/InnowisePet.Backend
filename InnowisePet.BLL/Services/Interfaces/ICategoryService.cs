using InnowisePet.DTO.DTO;
using InnowisePet.DTO.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(Guid id);
    Task<bool> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
    Task<bool> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto);
    Task<bool> DeleteCategoryAsync(Guid id);
}