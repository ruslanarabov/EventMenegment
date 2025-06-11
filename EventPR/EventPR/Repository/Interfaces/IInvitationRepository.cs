using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IInvitationRepository : IGenericRepository<Invitation>
{
    Task<IEnumerable<Invitation>> GetAllWithDetailsAsync();
    Task<Invitation> GetByIdWithDetailsAsync(int id);
    Task<Invitation> UpdateAsync(Invitation entity);
}