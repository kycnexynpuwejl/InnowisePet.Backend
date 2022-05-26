using System.Data;
using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models;
using Microsoft.Data.SqlClient;

namespace InnowisePet.DAL.Repo.Implementations;

public class ProductRepository : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        using IDbConnection connection = new SqlConnection();
        string sql = @"
                        SELECT *
                            FROM [dbo].[product] p
                            JOIN [dbo].[storage] s ON p.storage_id = s.id
                            JOIN [dbo].[category] c ON p.category_id = c.id
                      ";
        return connection.Query<Product>(sql);
    }
}