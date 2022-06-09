using InnowisePet.DTO.DTO.Order;
using InnowisePet.Services.Order.BLL;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetOrdersAsync()
    {
        return Ok(await _orderService.GetOrdersAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByIdAsync(Guid id)
    {
        return Ok(await _orderService.GetOrderByIdAsync(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        await _orderService.CreateOrderAsync(orderCreateDto);
        
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderAsync(Guid id, OrderUpdateDto orderUpdateDto)
    {
        await _orderService.UpdateOrderAsync(id, orderUpdateDto);
        
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderAsync(Guid id)
    {
        await _orderService.DeleteOrderAsync(id);
        
        return Ok();
    }
}