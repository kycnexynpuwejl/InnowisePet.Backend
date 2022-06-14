using System.Data;
using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Implementations;

public class LocationRepository : ILocationRepository
{
    private readonly IDbConnection _dbConnection;

    public LocationRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Location>> GetLocationsAsync()
    {
        const string sql = @"
                            SELECT *
                                FROM [dbo].[location]
                            ";

        return await _dbConnection.QueryAsync<Location>(sql);
    }

    public async Task<Location> GetLocationByIdAsync(Guid id)
    {
        string sql = $@"
                        SELECT *
                            FROM [dbo].[location]
                            WHERE id = '{id}'
                        ";

        return await _dbConnection.QueryFirstOrDefaultAsync<Location>(sql);
    }

    public async Task<bool> CreateLocationAsync(Location location)
    {
        string sql = @"
                        INSERT INTO [dbo].[location]
                            (id, city)
                        VALUES(@id, @city)
                        ";

        int result = await _dbConnection.ExecuteAsync(sql, location);

        return result > 0;
    }

    public async Task<bool> UpdateLocationAsync(Guid id, Location location)
    {
        string sql = $@"
                        UPDATE [dbo].[location]
                        SET city = @city
                        WHERE id = '{id}'
                        ";

        int result = await _dbConnection.ExecuteAsync(sql, location);

        return result > 0;
    }

    public async Task<bool> DeleteLocationAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[location]
                        WHERE id = '{id}'
                        ";

        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}