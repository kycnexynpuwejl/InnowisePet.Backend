using InnowisePet.DTO.DTO.Order;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    public OrderController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        await _publishEndpoint.Publish("");
        
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        await _publishEndpoint.Publish<OrderCreateDto>(orderCreateDto);
        
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrderAsync(OrderUpdateDto orderUpdateDto)
    {
        await _publishEndpoint.Publish<OrderUpdateDto>(orderUpdateDto);
        
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteOrderAsync(Guid id)
    {
        OrderDeleteDto orderDeleteDto = new OrderDeleteDto { Id = id };
        await _publishEndpoint.Publish<OrderDeleteDto>(orderDeleteDto);
        
        return Ok();
    }
}