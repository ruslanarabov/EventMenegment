using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IFeedbackRepository : IGenericRepository<Feedback> 
{
    Task<IEnumerable<Feedback>> GetAllWithDetailsAsync();
    Task<Feedback> GetByIdWithDetailsAsync(int id);
    Task<Feedback> UpdateAsync(Feedback entity);
    
}