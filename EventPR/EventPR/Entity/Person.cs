namespace EventPR.Entity;
public class Person : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Role Role { get; set; } 
    public ICollection<Invitation> Invitations { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
public enum Role
{
    Admin = 1 ,
    User,
    Guest
}