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
        const string sql = @"
                            SELECT
                                p.id,
                                p.category_id,
                                p.title,
                                p.description,
                                p.price,
                                c.title as CategoryName
                                FROM [dbo].[product] p
                                JOIN [dbo].[category] c
                                ON p.category_id = c.id
                            ";
        return await _dbConnection.QueryAsync<Product>(sql);
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        string sql = $@"
                            SELECT *
                                FROM [dbo].[product]
                                WHERE id = '{id}'
                            ";
        return await _dbConnection.QueryFirstAsync<Product>(sql);
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        const string sql = @"
                            INSERT INTO [dbo].[product] 
                                (title, description, price, id, category_id)
                            VALUES(@title, @description, @price, @id, @category_id)
                            ";
        var result =  await _dbConnection.ExecuteAsync(sql, product);
        
        return result > 0;
    }
    
}