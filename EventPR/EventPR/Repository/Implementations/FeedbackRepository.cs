using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class FeedbackRepository : GenericRepository<Feedback> , IFeedbackRepository
{
    private readonly AppDbContext _context;
    
    public FeedbackRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Feedback>> GetAllWithDetailsAsync()
    {
        return await _context.Feedbacks
            .Include(f => f.Event)
            .Include(f => f.Person)
            .ToListAsync();
    }

    public async Task<Feedback> GetByIdWithDetailsAsync(int id)
    {
        var feedback = await _context.Feedbacks
            .Include(f => f.Event)
            .Include(f => f.Person)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (feedback == null)
            throw new Exception($"Feedback with ID {id} not found.");

        return feedback;
    }

    public async Task<Feedback> UpdateAsync(Feedback entity)
    {
        _context.Feedbacks.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
}