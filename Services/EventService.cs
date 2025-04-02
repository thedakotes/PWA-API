using API.DataTransferObjects;
using API.Models;
using AutoMapper;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    
    // Retrieve all events from the repository
    public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
    {
        var events = await _eventRepository.GetAllAsync();
        var eventDTOs = _mapper.Map<IEnumerable<EventDTO>>(events);
        return eventDTOs;
    }

    // Retrieve a single event by its ID from the repository
    public async Task<EventDTO?> GetEventByIdAsync(int id)
    {
        var entity = await _eventRepository.GetByIdAsync(id);
        if (entity == null)
        {
            // Return null if the event with the specified ID does not exist
            return null;
        }
        // Map the entity to a Data Transfer Object (DTO) before returning it
        var entityDTO = _mapper.Map<EventDTO>(entity);
        return entityDTO;
    }

    public async Task<EventDTO> AddEventAsync(EventDTO newEvent)
    {
        var entity = _mapper.Map<Event>(newEvent);
        await _eventRepository.AddAsync(entity);

        return _mapper.Map<EventDTO>(entity);
    }

    public async Task DeleteEventAsync(int id)
    {
        await _eventRepository.DeleteAsync(id);
    }

    public async Task UpdateEventAsync(EventDTO updatedEvent)
    {
        if (updatedEvent == null)
        {
            throw new ArgumentNullException(nameof(updatedEvent), "Updated event cannot be null.");
        }

        var existingEvent = await _eventRepository.GetByIdAsync(updatedEvent.Id);
        if (existingEvent != null)
        {
            _mapper.Map(updatedEvent, existingEvent);
            await _eventRepository.UpdateAsync(existingEvent);
        }
    }
}