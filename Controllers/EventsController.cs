using Microsoft.AspNetCore.Mvc;
using API.DataTransferObjects;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid event ID");
            }

            var entity = await _eventsService.GetEventByIdAsync(id);
            return Ok(entity);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
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

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] EventDTO newEvent)
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
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid event ID."); // Return a 400 Bad Request for invalid ID
        }
        try
        {
            var entity = await _eventsService.GetEventByIdAsync(id);
            if (entity == null)
            {
                return NotFound($"Event with ID {id} not found."); // Return a 404 Not Found if the event doesn't exist
            }
            // Logic to delete the event would go here (not implemented in this example)
            await _eventsService.DeleteEventAsync(id); // Call the service to delete the event
            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EventDTO updatedEvent)
    {
        if (updatedEvent == null || id != updatedEvent.Id)
        {
            return BadRequest("Event data is null."); // Return a 400 Bad Request if the input is null
        }
        try
        {
            if (updatedEvent.Id <= 0)
            {
                return BadRequest($"Event with ID {updatedEvent.Id} not found.");
            }

            await _eventsService.UpdateEventAsync(updatedEvent);
            return NoContent(); // Return a 204 No Content if the update was successful

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error {ex.Message}");
        }
    }
}