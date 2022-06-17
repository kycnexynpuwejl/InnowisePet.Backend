using InnowisePet.Models.Entities;

namespace InnowisePet.Common.DAL.Repo.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(Guid id);
    Task<bool> CreateCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(Guid id, Category category);
    Task<bool> DeleteCategoryAsync(Guid id);
}