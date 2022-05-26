using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models;
using Microsoft.Data.SqlClient;

namespace InnowisePet.DAL.Repo.Implementations;

public class ProductRepository : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        string cs = "Server=.\\;Database=InnowisePetDB;User Id=SA;Password=yourStrong(!)Password;TrustServerCertificate=True";
        using var connection = new SqlConnection(cs);
        string sql = @"
                        SELECT p.id, p.title, p.quantity
                            FROM [dbo].[product] p
                            JOIN [dbo].[storage] s ON p.storage_id = s.id
                            JOIN [dbo].[category] c ON p.category_id = c.id
                      ";
        return connection.Query<Product>(sql);
    }
}