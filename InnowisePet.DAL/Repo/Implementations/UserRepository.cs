using System.Data;
using Dapper;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Implementations;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _dbConnection;

    public UserRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        const string sql = @"
                            SELECT
                                u.id,
                                u.firstname,
                                u.lastname,
                                u.email,
                                u.mobile
                            FROM [dbo].[user] u
                            ";
        
        return await _dbConnection.QueryAsync<User>(sql);
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        string sql = $@"
                            SELECT
                                u.id,
                                u.firstname,
                                u.lastname,
                                u.email,
                                u.mobile
                            FROM [dbo].[user] u
                            WHERE id = '{id}'
                            ";

        return await _dbConnection.QueryFirstAsync<User>(sql);
    }
    
    public async Task<bool> CreateUserAsync(User user)
    {
        const string sql = @"
                            INSERT INTO [dbo].[user] 
                                (id, firstname, lastname, email, mobile, password_hash)
                            VALUES(@id, @firstname, @lastname, @email, @mobile, @password_hash)
                            ";
        
        int result =  await _dbConnection.ExecuteAsync(sql, user);
        
        return result > 0;
    }
    
    public async Task<bool> UpdateUserAsync(Guid id, User user)
    {
        string sql = $@"
                            UPDATE [dbo].[user]
                            SET
                                firstname = @firstname,
                                lastname = @lastname,
                                email = @email,
                                mobile = @mobile,
                                password_hash = password_hash
                            WHERE id = '{id}'
                            ";
        
        int result = await _dbConnection.ExecuteAsync(sql, user);

        return result > 0;
    }
    
    public async Task<bool> DeleteUserAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[user]
                            WHERE id = '{id}'
                        ";
        
        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}