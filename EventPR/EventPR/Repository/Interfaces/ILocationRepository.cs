using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface ILocationRepository : IGenericRepository<Location>
{
    Task<IEnumerable<Location>> GetAllWithDetailsAsync();
    Task<Location> GetByIdWithDetailsAsync(int id);
    Task<Location> UpdateAsync(Location entity);
}