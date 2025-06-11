using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class InvitationRepository : GenericRepository<Invitation> ,IInvitationRepository  
{
    private readonly AppDbContext _context;

    public InvitationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invitation>> GetAllWithDetailsAsync()
    {
        return await _context.Invitations
            .Include(i => i.Event)
            .Include(i => i.Person)
            .ToListAsync();
    }

    public async Task<Invitation> GetByIdWithDetailsAsync(int id)
    {
        var invatation = await _context.Invitations
            .Include(i => i.Event)
            .Include(i => i.Person)
            .FirstOrDefaultAsync(i => i.Id == id);
        if (invatation == null)
            throw new Exception($"Invitation with ID {id} not found.");
        return invatation;
    }

    public async Task<Invitation> UpdateAsync(Invitation entity)
    {
        _context.Invitations.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


}