namespace Domain.Models;

public class Order
{
    public int OrderId { get; set; }
    
    public DateTime Date { get; set; }
    
    public OrgTour OrgTour { get; set; }
    
    public User User { get; set; }
}