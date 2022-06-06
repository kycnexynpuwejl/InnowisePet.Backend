using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DTO.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.API.Controllers;

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
        return Ok(await _orderService.CreateOrderAsync(orderCreateDto));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderAsync(Guid id, OrderUpdateDto orderUpdateDto)
    {
        return Ok(await _orderService.UpdateOrderAsync(id, orderUpdateDto));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderAsync(Guid id)
    {
        return Ok(await _orderService.DeleteOrderAsync(id));
    }
}