using System.Data;
using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _dbConnection;
    
    public ProductRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        string sql = @"
                        SELECT *
                            FROM [dbo].[product] p
                            JOIN [dbo].[storage] s ON p.storage_id = s.id
                            JOIN [dbo].[category] c ON p.category_id = c.id
                      ";
        return await _dbConnection.QueryAsync<Product>(sql);
    }
}