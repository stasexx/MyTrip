using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class SubMembership
{
    public int SubMembershipId { get; set; }
    
    public DateTime beginSubDate { get; set; }
    
    [Required]
    public Subscription Subscription { get; set; }
    
    [Required]
    public User User { get; set; }
}