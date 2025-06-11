using EventPR.Data;
using EventPR.Entity;
using EventPR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Repository.Implementations;

public class NotificationRepository : GenericRepository<Notification> ,INotificationRepository
{
    private readonly AppDbContext _context;
    public NotificationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notification>> GetAllWithDetailsAsync()
    {
        return await _context.Notifications
            .Include(n => n.Event)
            .ToListAsync();
    }

    public async Task<Notification> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Notifications
            .Include(n => n.Event)
            .FirstOrDefaultAsync(n => n.Id == id) 
            ?? throw new Exception($"Notification with ID {id} not found.");
    }
    public async Task<Notification> UpdateAsync(Notification entity)
    {
        _context.Notifications.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}