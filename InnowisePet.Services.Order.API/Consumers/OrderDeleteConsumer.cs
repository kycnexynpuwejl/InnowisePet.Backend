using InnowisePet.DTO.DTO.Order;
using InnowisePet.Services.Order.BLL;
using MassTransit;

namespace InnowisePet.Services.Order.API.Consumers;

public class OrderDeleteConsumer : IConsumer<OrderDeleteDto>
{
    private readonly IOrderService _orderService;
    public OrderDeleteConsumer(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task Consume(ConsumeContext<OrderDeleteDto> context)
    {
        await _orderService.DeleteOrderAsync(context.Message.Id);
    }
}
