using System.Security.Claims;
using InnowisePet.DTO.DTO.Order;
using InnowisePet.HttpClient;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderClient _orderClient;
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderController(IPublishEndpoint publishEndpoint, OrderClient orderClient)
    {
        _publishEndpoint = publishEndpoint;
        _orderClient = orderClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        return Ok(await _orderClient.GetOrdersAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _orderClient.GetOrderByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        //orderCreateDto.UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        await _publishEndpoint.Publish(orderCreateDto);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderAsync(OrderUpdateDto orderUpdateDto)
    {
        await _publishEndpoint.Publish(orderUpdateDto);

        return Ok();
    }
    
    [HttpPut("list")]
    public async Task<IActionResult> UpdateOrdersAsync(IEnumerable<OrderUpdateDto> orderUpdateDtoList)
    {
        OrderUpdateDtoList list = new() { List = orderUpdateDtoList };
        await _publishEndpoint.Publish(list);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderAsync([FromRoute] Guid id)
    {
        OrderDeleteDto orderDeleteDto = new() { Id = id };
        await _publishEndpoint.Publish(orderDeleteDto);

        return Ok();
    }
}