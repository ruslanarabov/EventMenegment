using Microsoft.AspNetCore.Identity;

namespace EventPR.Entity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsApproved { get; set; } = false;
    public string LoginIpAdress { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
}