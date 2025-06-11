using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class LocationRepository : GenericRepository<Location>, ILocationRepository
{
    private readonly AppDbContext _context;
    public LocationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAllWithDetailsAsync()
    {
        return await _context.Locations
            .Include(l => l.Events) 
            .ToListAsync();
    }

    public async Task<Location> GetByIdWithDetailsAsync(int id)
    {
        var location = await _context.Locations
            .Include(l => l.Events)
            .FirstOrDefaultAsync(l => l.Id == id);
        
        if (location == null)
            throw new Exception($"Location with ID {id} not found.");
            
        return location;
    }

    public async Task<Location> UpdateAsync(Location entity)
    {
        _context.Locations.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
}