using EventPR.Entity;
using Microsoft.EntityFrameworkCore;

namespace EventPR.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Invitation> Invitations { get; set; }
    public DbSet<Participation> Participations { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}   