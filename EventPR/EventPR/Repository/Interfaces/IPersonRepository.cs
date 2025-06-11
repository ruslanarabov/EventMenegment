using EventPR.Entity;

namespace EventPR.Repository.Interfaces;

public interface IPersonRepository : IGenericRepository<Person>
{
    Task<List<Person>> GetAllWithDetailsAsync();
    Task<Person?> GetByIdWithDetailsAsync(int id);
    Task<Person> UpdateAsync(Person entity);
}