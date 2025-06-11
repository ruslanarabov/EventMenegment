using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<IEnumerable<Notification>> GetAllWithDetailsAsync();
    Task<Notification> GetByIdWithDetailsAsync(int id);
    Task<Notification> UpdateAsync(Notification entity);

    
}