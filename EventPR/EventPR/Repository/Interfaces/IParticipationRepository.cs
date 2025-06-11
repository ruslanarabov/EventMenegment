using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IParticipationRepository : IGenericRepository<Participation>
{
    Task<IEnumerable<Participation>> GetAllWithDetailsAsync();
    Task<Participation> GetParticipationByInvitationIdAsync(int invitationId);
    Task<Participation> UpdateAsync(Participation entity);
    
}