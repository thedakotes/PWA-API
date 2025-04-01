using AutoMapper;
using EventApi.DataTransferObjects;
using API.Models;

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