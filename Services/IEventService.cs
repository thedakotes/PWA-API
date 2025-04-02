using API.DataTransferObjects;

public interface IEventService
{
    Task<EventDTO> AddEventAsync(EventDTO newEvent);
    Task DeleteEventAsync(int id);
    Task<IEnumerable<EventDTO>> GetAllEventsAsync();
    Task<EventDTO?> GetEventByIdAsync(int id);
    Task UpdateEventAsync(EventDTO updatedEvent);
}