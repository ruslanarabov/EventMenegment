namespace EventPR.Entity;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public bool IsDeletet { get; set; }
}