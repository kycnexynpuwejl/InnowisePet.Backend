using System.Text.Json;
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
    private readonly HttpClient _httpClient;
    
    public OrderController(IPublishEndpoint publishEndpoint, HttpClient httpClient)
    {
        _publishEndpoint = publishEndpoint;
        _httpClient = httpClient;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync("https://localhost:7258/api/order");
        return Ok(await result.Content.ReadAsStringAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByIdAsync([FromRoute]Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync($"https://localhost:7258/api/order/{id}");
        return Ok(await result.Content.ReadAsStringAsync());
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderAsync([FromRoute]Guid id)
    {
        OrderDeleteDto orderDeleteDto = new OrderDeleteDto { Id = id };
        await _publishEndpoint.Publish<OrderDeleteDto>(orderDeleteDto);
        
        return Ok();
    }
}