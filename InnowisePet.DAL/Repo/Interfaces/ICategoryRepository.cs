using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryById(Guid id);
    Task<bool> CreateCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(Guid id, Category category);
    Task<bool> DeleteCategoryAsync(Guid id);
}