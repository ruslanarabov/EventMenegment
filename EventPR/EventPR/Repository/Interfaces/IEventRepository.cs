using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IEventRepository : IGenericRepository<Event>
{
    Task<IEnumerable<Event>> GetAllWithDetailsAsync();
    
    Task<Event> UpdateAsync (Event entity);
}