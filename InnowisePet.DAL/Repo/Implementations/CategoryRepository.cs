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

    public async Task<Category> GetCategoryById(Guid id)
    {
        string sql = $@"
                            SELECT *
                                FROM [dbo].[category]
                                WHERE id = '{id}'
                            ";

        return await _dbConnection.QueryFirstOrDefaultAsync<Category>(sql);
    }
}