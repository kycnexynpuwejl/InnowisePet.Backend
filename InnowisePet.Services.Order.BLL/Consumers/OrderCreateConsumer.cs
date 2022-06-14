using InnowisePet.DTO.DTO.Order;
using MassTransit;

namespace InnowisePet.Services.Order.BLL.Consumers;

public class OrderCreateConsumer : IConsumer<OrderCreateDto>
{
    private readonly IOrderService _orderService;

    public OrderCreateConsumer(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task Consume(ConsumeContext<OrderCreateDto> context)
    {
        await _orderService.CreateOrderAsync(context.Message);
    }
}