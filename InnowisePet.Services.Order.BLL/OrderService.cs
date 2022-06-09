using AutoMapper;
using InnowisePet.DTO.DTO.Order;
using InnowisePet.Services.Order.DAL;

namespace InnowisePet.Services.Order.BLL;

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
        var result = await _orderRepository.GetOrdersAsync();
        
        return _mapper.Map<IEnumerable<OrderGetDto>>(result);
    }
    
    public async Task<OrderGetDto> GetOrderByIdAsync(Guid id)
    {
        var result = await _orderRepository.GetOrderByIdAsync(id);

        return _mapper.Map<OrderGetDto>(result);
    }
    
    public async Task CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        var order = _mapper.Map<DAL.Order>(orderCreateDto);

        await _orderRepository.CreateOrderAsync(order);
    }
    
    public async Task UpdateOrderAsync(Guid id, OrderUpdateDto orderUpdateDto)
    {
        DAL.Order product = _mapper.Map<DAL.Order>(orderUpdateDto);

        await _orderRepository.UpdateOrderAsync(id, product);
    }
    
    public async Task DeleteOrderAsync(Guid id)
    {
        await _orderRepository.DeleteOrderAsync(id);
    }
}