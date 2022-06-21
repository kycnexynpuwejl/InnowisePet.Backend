using InnowisePet.Services.Storage.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Storage.DAL.Data;

public class StorageDbContext : DbContext
{
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
    { }

    public DbSet<Models.Storage> Storages { get; set; }
    public DbSet<ProductStorage> ProductStorages { get; set; }
}