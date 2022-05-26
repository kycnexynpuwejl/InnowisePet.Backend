using InnowisePet.Models;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
}