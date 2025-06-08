namespace EventPR.Entity;

public class EventType : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Event> Events { get; set; }
}