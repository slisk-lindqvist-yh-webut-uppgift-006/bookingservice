using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _bookingService.CreateBookingAsync(request);
        return result.Succeeded
            ? Ok()
            : StatusCode(StatusCodes.Status500InternalServerError, "Unable to create booking.");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _bookingService.GetAllBookingsAsync();

        return result.Succeeded
            ? Ok(result.Result)
            : StatusCode(result.StatusCode, result.Error ?? "Unable to retrieve bookings.");
    }
}