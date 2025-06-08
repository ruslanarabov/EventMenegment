using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IGenericRepository <TEntity> where TEntity : BaseEntity, new()
{
    
}