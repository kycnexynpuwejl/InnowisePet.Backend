using System.Data;
using Dapper;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Storage.DAL.Repo.Interfaces;

namespace InnowisePet.Services.Storage.DAL.Repo.Implementations;

public class ProductStorageRepository : IProductStorageRepository
{
    private readonly IDbConnection _dbConnection;

    public ProductStorageRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<IEnumerable<ProductStorageModel>> GetProductStoragesAsync()
    {
        const string sql = @"
                            SELECT Id, ProductId, StorageId, Quantity
                            FROM [dbo].[ProductStorages]
                            ";

        return await _dbConnection.QueryAsync<ProductStorageModel>(sql);
    }

    public async Task<IEnumerable<ProductStorageModel>> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        string sql = $@"
                        SELECT Id, ProductId, StorageId, Quantity
                            FROM [dbo].[ProductStorages] ps
                        JOIN [dbo].[Storages] s ON ps.StorageId = s.Id
                        WHERE s.Id = '{storageId}'
                        ";
        
        return await _dbConnection.QueryAsync<ProductStorageModel>(sql);
    }
    
    public async Task<bool> CreateProductStorageAsync(ProductStorageModel productStorageModel)
    {
        const string sql = @"
                        SELECT * FROM [dbo].[ProductStorages]
                        WHERE ProductId = @ProductId AND StorageId = @StorageId
                        ";
        var productStorageFromDb = await _dbConnection.QueryFirstOrDefaultAsync<ProductStorageModel>(sql, productStorageModel);

        if (productStorageFromDb != null)
        {
            const string sqlToUpdate = @"
                            UPDATE [dbo].[ProductStorages]
                                SET Quantity = Quantity + @Quantity
                            WHERE ProductId = @ProductId AND StorageId = @StorageId 
                            ";
            var updatedProductStorage = await _dbConnection.ExecuteAsync(sqlToUpdate, productStorageModel);

            return updatedProductStorage > 0;
        }
        else
        {
            const string sqlToInsert = @"
                            INSERT INTO [dbo].[ProductStorages]
                                (Id,ProductId, StorageId, Quantity)
                            VALUES (@Id, @ProductId, @StorageId, @Quantity)
                            ";
            var insertedProductStorage = await _dbConnection.ExecuteAsync(sqlToInsert, productStorageModel);

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
        var result = await _dbConnection.ExecuteAsync(sql, productStorageModel);

        return result > 0;
    }
    
    public async Task<bool> DeleteProductStorageAsync(Guid storageId, Guid productId)
    {
        string sql = $@"
                        DELETE FROM [dbo].[ProductStorages]
                        WHERE ProductId = '{productId}' AND StorageId = '{storageId}'
                        ";
        var result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}