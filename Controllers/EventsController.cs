using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventApi.Data;
using EventApi.Models;
using EventApi.DataTransferObjects;

namespace EventApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventsService;

    public EventsController(IEventService eventsService)
    {
        _eventsService = eventsService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetEvents()
    {
        try
        {
            // Retrieve all events from the service
            var events = await _eventsService.GetAllEventsAsync();
            return Ok(events); // Return a 200 OK response with the list of events
        }
        catch (Exception ex)
        {
            // Handle any exceptions and return a 500 Internal Server Error response
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddEvent([FromBody] EventDTO newEvent)
    {
        if (newEvent == null)
        {
            return BadRequest("Event data is null."); // Return a 400 Bad Request if the input is null
        }

        try
        {
            // Add the new event using the service
            EventDTO entity = await _eventsService.AddEventAsync(newEvent);
            return Ok(entity); // Return a 201 Created response
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}"); // Handle exceptions
        }
    }
}