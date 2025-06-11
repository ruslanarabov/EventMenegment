using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class ParticipationRepository : GenericRepository<Participation>, IParticipationRepository
{
    private readonly AppDbContext _context;

    public ParticipationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Participation>> GetAllWithDetailsAsync()
    {
        return await _context.Participations
            .Include(p => p.Invitation)
            .ThenInclude(i => i.Event)
            .Include(p => p.Invitation)
            .ThenInclude(i => i.Person)
            .ToListAsync();
    }

    public async Task<Participation> GetParticipationByInvitationIdAsync(int invitationId)
    {
        return await _context.Participations
            .Include(p => p.Invitation)
            .ThenInclude(i => i.Event)
            .Include(p => p.Invitation)
            .ThenInclude(i => i.Person)
            .FirstOrDefaultAsync(p => p.InvitationId == invitationId);
    }

    public async Task<Participation> UpdateAsync(Participation entity)
    {
        _context.Participations.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
}