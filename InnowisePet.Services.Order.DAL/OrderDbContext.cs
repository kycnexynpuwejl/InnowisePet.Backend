using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Order.DAL;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public DbSet<Models.Entities.OrderModel> Orders { get; set; }
}