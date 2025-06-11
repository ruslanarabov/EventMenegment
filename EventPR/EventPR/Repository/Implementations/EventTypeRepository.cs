using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class EventTypeRepository : GenericRepository<EventType>, IEventTypeRepository
{
    private readonly AppDbContext _context;

    public EventTypeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<EventType>> GetAllWithEventTypeAsync()
    {
        return await _context.EventTypes
            .Include(et => et.Events) 
            .Where(et => !et.IsDeletet)
            .ToListAsync();
    }

    public async Task<EventType?> GetByIdWithEventTypeAsync(int id)
    {
        return await _context.EventTypes
            .Include(et => et.Events)
            .FirstOrDefaultAsync(et => et.Id == id && !et.IsDeletet);
    }

    public async Task<EventType> UpdateAsync(EventType entity)
    {
        var existingEntity = await _context.EventTypes.FindAsync(entity.Id);
        if (existingEntity == null) return null;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        return existingEntity;
    }
  
}
    
  

