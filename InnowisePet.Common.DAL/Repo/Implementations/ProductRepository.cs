using System.Data;
using Dapper;
using InnowisePet.Common.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.Common.DAL.Repo.Implementations;

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
                            SELECT DISTINCT
                                p.id,
                                p.category_id,
                                p.title,
                                p.description,
                                p.price,
                                c.title as CategoryName,
                                SUM(ps.quantity) OVER(PARTITION BY p.id) as Quantity
                            FROM [dbo].[product] p
                                JOIN [dbo].[category] c
                                ON p.category_id = c.id
                                LEFT JOIN [dbo].[product_storage] ps
                                ON p.id = ps.product_id
                            ";

        return await _dbConnection.QueryAsync<Product>(sql);
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        string sql = $@"
                            SELECT DISTINCT
                                p.id,
                                p.category_id,
                                p.title,
                                p.description,
                                p.price,
                                c.title as CategoryName,
                                SUM(ps.quantity) OVER(PARTITION BY p.id) as Quantity
                            FROM [dbo].[product] p
                                JOIN [dbo].[category] c ON p.category_id = c.id
                                LEFT JOIN [dbo].[product_storage] ps ON p.id = ps.product_id
                            WHERE p.id = '{id}'
                            ";

        return await _dbConnection.QueryFirstAsync<Product>(sql);
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        const string sql = @"
                            INSERT INTO [dbo].[product] 
                                (id, category_id, title, description, price)
                            VALUES(@Id, @CategoryId, @Title, @Description, @Price)
                            ";

        int result = await _dbConnection.ExecuteAsync(sql, product);

        return result > 0;
    }

    public async Task<bool> UpdateProductAsync(Guid id, Product product)
    {
        string sql = $@"
                            UPDATE [dbo].[product]
                            SET
                                category_id = @CategoryId,
                                title = @Title,
                                description = @Description,
                                price = @Price
                            WHERE id = '{id}'
                            ";

        int result = await _dbConnection.ExecuteAsync(sql, product);

        return result > 0;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[product]
                        WHERE id = '{id}'
                        ";

        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}