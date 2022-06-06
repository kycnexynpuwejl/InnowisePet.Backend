using AutoMapper;
using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DAL.Repo.Interfaces;
using InnowisePet.DTO.DTO.Order;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<OrderGetDto>> GetOrdersAsync()
    {
        IEnumerable<Order> result =  await _orderRepository.GetOrdersAsync();

        return _mapper.Map<IEnumerable<OrderGetDto>>(result);
    }
    
    public async Task<OrderGetDto> GetOrderByIdAsync(Guid id)
    {
        Order result = await _orderRepository.GetOrderByIdAsync(id);

        return _mapper.Map<OrderGetDto>(result);
    }
    
    public async Task<bool> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        Order order = _mapper.Map<Order>(orderCreateDto);

        return await _orderRepository.CreateOrderAsync(order);
    }
    
    public async Task<bool> UpdateOrderAsync(Guid id, OrderUpdateDto orderUpdateDto)
    {
        Order product = _mapper.Map<Order>(orderUpdateDto);

        return await _orderRepository.UpdateOrderAsync(id, product);
    }
    
    public async Task<bool> DeleteOrderAsync(Guid id)
    {
        return await _orderRepository.DeleteOrderAsync(id);
    }
}