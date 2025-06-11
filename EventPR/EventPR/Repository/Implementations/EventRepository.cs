using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class EventRepository :  GenericRepository<Event>, IEventRepository
{
    private readonly AppDbContext _context;
    public EventRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Event>> GetAllWithDetailsAsync()
    {
        return await _context.Events
            .Include(e=>e.Location)
            .Include(e => e.EventType)
            .Include(e=> e.Organizer)
            .ToListAsync();
    }
 

    public async Task<Event> UpdateAsync(Event entity)
    {
        var existingEntity = await _context.Events.FindAsync(entity.Id);
        if (existingEntity == null) return null;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        return existingEntity;
    }
    
}