using InnowisePet.Common.BLL.Services.Interfaces;
using InnowisePet.DTO.DTO.Location;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Common.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocationsAsync()
    {
        return Ok(await _locationService.GetLocationsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocationById(Guid id)
    {
        return Ok(await _locationService.GetLocatioByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocationAsync(LocationCreateDto locationCreateDto)
    {
        return Ok(await _locationService.CreateLocationAsync(locationCreateDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocationAsync(Guid id, LocationUpdateDto locationUpdateDto)
    {
        return Ok(await _locationService.UpdateLocationAsync(id, locationUpdateDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocationAsync(Guid id)
    {
        return Ok(await _locationService.DeleteLocationAsync(id));
    }
}