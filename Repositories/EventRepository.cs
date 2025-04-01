using API.Models;
using EventApi.Data;
using Microsoft.EntityFrameworkCore;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Event>> GetByDateAsync(DateTime date)
    {
        return await _dbSet.Where(x => x.Date.Date == date.Date) // Compare only the date part
            .ToListAsync(); // Asynchronously fetch the list of events for the given date
    }

    public async Task<IEnumerable<Event>> GetUpcomingEvents()
    {
        // This method can be used to fetch all events if needed
        return await _dbSet.Where(x => x.Date >= DateTime.UtcNow).ToListAsync(); // Asynchronously fetch all events from the database
    }
}