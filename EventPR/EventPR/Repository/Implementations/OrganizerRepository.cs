using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class OrganizerRepository : GenericRepository<Organizer> ,IOrganizerRepository
{
    private readonly AppDbContext _context;

    public OrganizerRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Organizer>> GetAllWithDetailsAsync()
    {
        return await _context.Organizers
            .Include(o => o.Events)
            .ToListAsync();
    }

    public async Task<Organizer> GetByIdWithDetailsAsync(int id)
    {
        var organize = await _context.Organizers
            .Include(o => o.Events)
            .FirstOrDefaultAsync(o => o.Id == id);
        if (organize == null)
            throw new Exception($"Organizer with ID {id} not found.");
        return organize;
    }

    public async Task<Organizer> UpdateAsync(Organizer entity)
    {
        _context.Organizers.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<Organizer> GetByEmailAsync(string email)
    {
        var organizer = await _context.Organizers
            .FirstOrDefaultAsync(o => o.Email == email);
        
        if (organizer == null)
            throw new Exception($"Organizer with email {email} not found.");
        
        return organizer;
    }
    
}