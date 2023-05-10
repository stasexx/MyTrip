namespace Domain.Models;

public class Membership
{
    public int MembershipId { get; set; }
    public User User { get; set; }
    public string Role { get; set; }
}