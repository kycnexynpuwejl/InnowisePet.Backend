using InnowisePet.DTO.DTO.Order;
using InnowisePet.Services.Order.BLL;
using MassTransit;

namespace InnowisePet.Services.Order.API;

public class OrderUpdateConsumer : IConsumer<OrderUpdateDto>
{
    private readonly IOrderService _orderService;
    public OrderUpdateConsumer(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task Consume(ConsumeContext<OrderUpdateDto> context)
    {
        await _orderService.UpdateOrderAsync(context.Message.Id, context.Message);
    }
}
