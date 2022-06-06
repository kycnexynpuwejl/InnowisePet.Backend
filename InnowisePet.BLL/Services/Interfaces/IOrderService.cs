using InnowisePet.DTO.DTO.Order;

namespace InnowisePet.BLL.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderGetDto>> GetOrdersAsync();
    Task<OrderGetDto> GetOrderByIdAsync(Guid id);
    Task<bool> CreateOrderAsync(OrderCreateDto orderCreateDto);
    Task<bool> UpdateOrderAsync(Guid id, OrderUpdateDto orderUpdateDto);
    Task<bool> DeleteOrderAsync(Guid id);
}