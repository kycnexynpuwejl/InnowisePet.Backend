using System.Data;
using InnowisePet.Models.Entities;
using Dapper;


namespace InnowisePet.Services.Storage.DAL.Repo;

public class StorageRepository : IStorageRepository
{
    private readonly IDbConnection _connection;

    public StorageRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<StorageModel>> GetStoragesAsync()
    {
        const string sql = @"
                            SELECT Id, Title
                            FROM [dbo].[Storages]
                            ";

        return await _connection.QueryAsync<StorageModel>(sql);
    }

    public async Task<StorageModel> GetStorageByIdAsync(Guid id)
    {
        string sql = $@"
                        SELECT Id, Title
                        FROM [dbo].[Storages]
                        WHERE Id = '{id}'
                       ";

        return await _connection.QueryFirstAsync<StorageModel>(sql);
    }

    public async Task<bool> CreateStorageAsync(StorageModel storageModel)
    {
        const string sql = @"
                            INSERT INTO [dbo].[Storages]
                                (Id, Title)
                            VALUES(@Id, @Title)
                            ";
        int result = await _connection.ExecuteAsync(sql, storageModel);

        return result > 0;
    }

    public async Task<bool> UpdateStorageAsync(StorageModel storageModel)
    {
        const string sql = @"
                        UPDATE [dbo].[Storages]
                        SET
                            Title = @Title
                        WHERE Id = @Id
                        ";

        int result = await _connection.ExecuteAsync(sql, storageModel);

        return result > 0;
    }

    public async Task<bool> DeleteStorageAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[Storages]
                        WHERE Id = '{id}'
                        ";
        int result = await _connection.ExecuteAsync(sql);

        return result > 0;
    }

    public async Task<IEnumerable<ProductStorageModel>> GetProductStoragesAsync()
    {
        const string sql = @"
                            SELECT Id, ProductId, StorageId, Quantity
                            FROM [dbo].[ProductStorages]
                            ";

        return await _connection.QueryAsync<ProductStorageModel>(sql);
    }

    public async Task<IEnumerable<ProductStorageModel>> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        string sql = $@"
                        SELECT Id, ProductId, StorageId, Quantity
                            FROM [dbo].[ProductStorages] ps
                        JOIN [dbo].[Storages] s ON ps.StorageId = s.Id
                        WHERE s.Id = '{storageId}'
                        ";
        
        return await _connection.QueryAsync<ProductStorageModel>(sql);
    }
    
    public async Task<bool> CreateProductStorageAsync(ProductStorageModel productStorageModel)
    {
        const string sql = @"
                        SELECT * FROM [dbo].[ProductStorages]
                        WHERE ProductId = @ProductId AND StorageId = @StorageId
                        ";
        var productStorageFromDb = await _connection.QueryFirstOrDefaultAsync<ProductStorageModel>(sql, productStorageModel);

        if (productStorageFromDb != null)
        {
            const string sqlToUpdate = @"
                            UPDATE [dbo].[ProductStorages]
                                SET Quantity = Quantity + @Quantity
                            WHERE ProductId = @ProductId AND StorageId = @StorageId 
                            ";
            var updatedProductStorage = await _connection.ExecuteAsync(sqlToUpdate, productStorageModel);

            return updatedProductStorage > 0;
        }
        else
        {
            const string sqlToInsert = @"
                            INSERT INTO [dbo].[ProductStorages]
                                (Id,ProductId, StorageId, Quantity)
                            VALUES (@Id, @ProductId, @StorageId, @Quantity)
                            ";
            var insertedProductStorage = await _connection.ExecuteAsync(sqlToInsert, productStorageModel);

            return insertedProductStorage > 0;
        }
    }

    public async Task<bool> UpdateProductStorageAsync(ProductStorageModel productStorageModel)
    {
        const string sql = @"
                            UPDATE [dbo].[ProductStorages]
                                SET Quantity = @Quantity
                            WHERE ProductId = @ProductId AND StorageId = @StorageId
                            ";
        var result = await _connection.ExecuteAsync(sql, productStorageModel);

        return result > 0;
    }
    
    public async Task<bool> DeleteProductStorageAsync(Guid storageId, Guid productId)
    {
        string sql = $@"
                        DELETE FROM [dbo].[ProductStorages]
                        WHERE ProductId = '{productId}' AND StorageId = '{storageId}'
                        ";
        var result = await _connection.ExecuteAsync(sql);

        return result > 0;
    }
}