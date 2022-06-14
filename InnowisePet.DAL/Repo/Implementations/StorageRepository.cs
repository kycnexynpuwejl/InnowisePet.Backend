using System.Data;
using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Implementations;

public class StorageRepository : IStorageRepository
{
    private readonly IDbConnection _dbConnection;

    public StorageRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Storage>> GetStoragesAsync()
    {
        const string sql = @"
                            SELECT
                                s.id,
                                s.location_id,
                                s.title,
                                l.city as LocationName
                                FROM [dbo].[storage] s
                                JOIN [dbo].[location] l
                                ON s.location_id = l.id
                            ";

        return await _dbConnection.QueryAsync<Storage>(sql);
    }

    public async Task<Storage> GetStorageByIdAsync(Guid id)
    {
        string sql = $@"
                            SELECT *
                                FROM [dbo].[storage]
                                WHERE id = '{id}'
                            ";

        return await _dbConnection.QueryFirstAsync<Storage>(sql);
    }

    public async Task<bool> CreateStorageAsync(Storage storage)
    {
        const string sql = @"
                            INSERT INTO [dbo].[storage] 
                                (id, location_id, title)
                            VALUES(@id, @location_id, @title)
                            ";

        int result = await _dbConnection.ExecuteAsync(sql, storage);

        return result > 0;
    }

    public async Task<bool> UpdateStorageAsync(Guid id, Storage storage)
    {
        string sql = $@"
                            UPDATE [dbo].[storage]
                            SET
                                location_id = @location_id,
                                title = @title
                            WHERE id = '{id}'
                            ";

        int result = await _dbConnection.ExecuteAsync(sql, storage);

        return result > 0;
    }

    public async Task<bool> DeleteStorageAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[storage]
                            WHERE id = '{id}'
                        ";

        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}