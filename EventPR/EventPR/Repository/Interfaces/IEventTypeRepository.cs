using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IEventTypeRepository : IGenericRepository<EventType>
{
    Task<List<EventType>> GetAllWithEventTypeAsync();
    Task<EventType?> GetByIdWithEventTypeAsync(int id);
    Task<EventType> UpdateAsync(EventType entity);
    
}