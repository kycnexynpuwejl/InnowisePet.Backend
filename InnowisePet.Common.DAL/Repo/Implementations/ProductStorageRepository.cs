using System.Data;
using Dapper;
using InnowisePet.Common.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.Common.DAL.Repo.Implementations;

public class ProductStorageRepository : IProductStorageRepository
{
    private readonly IDbConnection _dbConnection;

    public ProductStorageRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<ProductStorage>> GetProductStoragesAsync()
    {
        const string sql = @"
                            SELECT
                                ps.id,
                                ps.product_id,
                                ps.storage_id,
                                ps.quantity,
                                p.title as ProductName,
                                s.title as StorageName
                                FROM [dbo].[product_storage] ps
                                JOIN [dbo].[product] p
                                ON p.id = ps.product_id
                                JOIN [dbo].[storage] s
                                ON s.id = ps.storage_id
                            ";

        return await _dbConnection.QueryAsync<ProductStorage>(sql);
    }

    public async Task<ProductStorage> GetProductStorageByIdAsync(Guid id)
    {
        string sql = $@"
                            SELECT
                                ps.id,
                                ps.product_id,
                                ps.storage_id,
                                ps.quantity,
                                p.title as ProductName,
                                s.title as StorageName
                            FROM [dbo].[product_storage] ps
                                JOIN [dbo].[product] p
                                ON p.id = ps.product_id
                                JOIN [dbo].[storage] s
                                ON s.id = ps.storage_id
                            WHERE ps.id = '{id}'
                            ";

        return await _dbConnection.QueryFirstAsync<ProductStorage>(sql);
    }

    public async Task<bool> CreateProductStorageAsync(ProductStorage productStorage)
    {
        const string sql = @"
                            INSERT INTO [dbo].[product_storage] 
                                (id, product_id, storage_id, quantity)
                            VALUES(@Id, @ProductId, @StorageId, @Quantity)
                            ";

        int result = await _dbConnection.ExecuteAsync(sql, productStorage);

        return result > 0;
    }

    public async Task<bool> UpdateProductStorageAsync(Guid id, ProductStorage productStorage)
    {
        string sql = $@"
                            UPDATE [dbo].[product_storage] 
                            SET 
                                product_id = @ProductId,
                                storage_id = @StorageId,
                                quantity = @Quantity
                            WHERE id = '{id}'
                            ";

        int result = await _dbConnection.ExecuteAsync(sql, productStorage);

        return result > 0;
    }

    public async Task<bool> DeleteProductStorageAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[product_storage]
                            WHERE id = '{id}'
                        ";

        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}