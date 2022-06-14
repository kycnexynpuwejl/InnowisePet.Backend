using InnowisePet.BLL.Services.Interfaces;
using InnowisePet.DTO.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetUsersAsync()
    {
        return Ok(await _userService.GetUsersAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _userService.GetUserByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(UserCreateDto userCreateDto)
    {
        return Ok(await _userService.CreateUserAsync(userCreateDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] UserUpdateDto userUpdateDto)
    {
        return Ok(await _userService.UpdateUserAsync(id, userUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id)
    {
        return Ok(await _userService.DeleteUserAsync(id));
    }
}