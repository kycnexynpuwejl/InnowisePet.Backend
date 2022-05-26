using InnowisePet.Models;
using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
}