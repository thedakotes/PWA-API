using EventApi.DataTransferObjects;
using EventApi.Models;

public interface IEventService
{
    Task<EventDTO>AddEventAsync(EventDTO newEvent);
    Task<IEnumerable<EventDTO>> GetAllEventsAsync();
    Task<EventDTO?> GetEventByIdAsync(int id);
}