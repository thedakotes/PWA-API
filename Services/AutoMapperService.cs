using AutoMapper;
using API.Models;
using API.DataTransferObjects;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        // Create a mapping configuration from Event to EventDTO
        CreateMap<Event, EventDTO>();
        // Create a mapping configuration from EventDTO to Event
        CreateMap<EventDTO, Event>();
    }
}