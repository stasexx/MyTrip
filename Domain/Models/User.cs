using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class User
{
    public int UserId { get; set; }

    public string Password;

    public string Login { get; set; }
    
    public string Email { get; set; }
    
    public bool OrgRights { get; set; }
    
    public string Agency { get; set; }
    
    public int Experience { get; set; }
    
    public string firstName { get; set; }

    public string lastName { get; set; }
    
    public int phoneNumber { get; set; }
    
    public string City { get; set; }
    
    public string Avatar { get; set; }
    
    public bool availabilityOfTours { get; set; }
    
    public bool availabilityOfProfile { get; set; }

    public bool IsBanned { get; set; }
    
    public DateTime RegDate { get; set; }
}