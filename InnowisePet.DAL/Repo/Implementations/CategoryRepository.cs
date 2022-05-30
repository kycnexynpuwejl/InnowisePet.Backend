using System.Data;
using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _dbConnection;
    
    public CategoryRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        const string sql = @"
                            SELECT *
                                FROM [dbo].[category]
                            ";

        return await _dbConnection.QueryAsync<Category>(sql);
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        string sql = $@"
                        SELECT *
                            FROM [dbo].[category]
                            WHERE id = '{id}'
                        ";

        return await _dbConnection.QueryFirstOrDefaultAsync<Category>(sql);
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        const string sql = @"
                            INSERT INTO [dbo].[category]
                                (id, title)
                            VALUES(@id, @title)
                            ";
        int result = await _dbConnection.ExecuteAsync(sql, category);

        return result > 0;
    }

    public async Task<bool> UpdateCategoryAsync(Guid id, Category category)
    {
        string sql = $@"
                        UPDATE [dbo].[category]
                            SET title = @title
                            WHERE id = '{id}'
                        ";
        int result = await _dbConnection.ExecuteAsync(sql, category);

        return result > 0;
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[category]
                            WHERE id = '{id}'
                        ";
        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}