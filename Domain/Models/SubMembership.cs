namespace Domain.Models;

public class SubMembership
{
    public int SubMembershipId { get; set; }
    
    public DateTime beginSubDate { get; set; }
    
    public Subscription Subscription { get; set; }
    
    public User User { get; set; }
}