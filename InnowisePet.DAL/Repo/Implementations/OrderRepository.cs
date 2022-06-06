using System.Data;
using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly IDbConnection _dbConnection;

    public OrderRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        const string sql = @"
                            SELECT *
                                FROM [dbo].[order]
                            ";

        return await _dbConnection.QueryAsync<Order>(sql);
    }
    
    public async Task<Order> GetOrderByIdAsync(Guid id)
    {
        string sql = $@"
                        SELECT *
                            FROM [dbo].[order]
                            WHERE id = '{id}'
                        ";

        return await _dbConnection.QueryFirstOrDefaultAsync<Order>(sql);
    }
    
    public async Task<bool> CreateOrderAsync(Order order)
    {
        const string sql = @"
                            INSERT INTO [dbo].[order]
                                (id, firstname, lastname, address, city, country)
                            VALUES(@id, @firstname, @lastname, @address, @city, @country)
                            ";
        
        int result = await _dbConnection.ExecuteAsync(sql, order);

        return result > 0;
    }
    
    public async Task<bool> UpdateOrderAsync(Guid id, Order order)
    {
        string sql = $@"
                        UPDATE [dbo].[order]
                            SET firstname = @firstname,
                                lastname = lastname,
                                address = address,
                                city = city,
                                country = country
                            WHERE id = '{id}'
                        ";
        
        int result = await _dbConnection.ExecuteAsync(sql, order);

        return result > 0;
    }
    
    public async Task<bool> DeleteOrderAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[order]
                            WHERE id = '{id}'
                        ";
        
        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}