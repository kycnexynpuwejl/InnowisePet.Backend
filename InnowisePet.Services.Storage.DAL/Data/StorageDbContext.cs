using InnowisePet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Storage.DAL.Data;

public class StorageDbContext : DbContext
{
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
    { }

    public DbSet<InnowisePet.Models.Entities.Storage> Storages { get; set; }
    public DbSet<ProductStorage> ProductStorages { get; set; }
}