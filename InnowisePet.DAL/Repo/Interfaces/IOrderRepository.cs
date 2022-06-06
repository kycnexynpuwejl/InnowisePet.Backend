using InnowisePet.Models.Entities;

namespace InnowisePet.DAL.Repo.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid id);
    Task<bool> CreateOrderAsync(Order order);
    Task<bool> UpdateOrderAsync(Guid id, Order order);
    Task<bool> DeleteOrderAsync(Guid id);
}