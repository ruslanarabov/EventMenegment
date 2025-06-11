using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IOrganizerRepository : IGenericRepository<Organizer>
{
    Task<IEnumerable<Organizer>> GetAllWithDetailsAsync();
    Task<Organizer> GetByIdWithDetailsAsync(int id);
    Task<Organizer> UpdateAsync(Organizer entity);
    Task<Organizer> GetByEmailAsync(string email);
}