namespace EventPR.Entity;

public class Organizer : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public ICollection<Event> Events { get; set; }
}