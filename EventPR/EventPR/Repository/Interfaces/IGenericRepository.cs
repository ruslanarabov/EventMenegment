using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IGenericRepository <TEntity> where TEntity : BaseEntity, new()
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<int> SaveChangesAsync();

}