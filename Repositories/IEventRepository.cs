using API.Models;

public interface IEventRepository : IRepository<Event>
{
    // Get events by a specific date
    Task<IEnumerable<Event>> GetByDateAsync(DateTime date);

    Task<IEnumerable<Event>> GetUpcomingEvents();
}