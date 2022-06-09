namespace InnowisePet.Services.Order.DAL;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid id);
    Task CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Guid id, Order order);
    Task DeleteOrderAsync(Guid id);
}