using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetCategoryById(Guid id);
}