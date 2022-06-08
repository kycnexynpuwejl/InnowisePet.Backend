using InnowisePet.Order.Microservice.SharedModels;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Order.Microservice.Producer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    
    public OrderController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDto orderDto)
    {
        await _publishEndpoint.Publish<OrderCreated>(new
        {
            id = Guid.NewGuid(),
            orderDto.firstname,
            orderDto.lastname,
            orderDto.address,
            orderDto.city,
            orderDto.country
        });
        
        return Ok();
    }
}