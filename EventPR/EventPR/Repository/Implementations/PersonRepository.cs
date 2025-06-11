using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Person>> GetAllWithDetailsAsync()
    {
        return await _context.Persons
            .Include(p => p.Invitations)
            .Include(p => p.Feedbacks)
            .ToListAsync();
    }

    public async Task<Person?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Persons
            .Include(p => p.Invitations)
            .Include(p => p.Feedbacks)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Person> UpdateAsync(Person entity)
    {
        _context.Persons.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
}