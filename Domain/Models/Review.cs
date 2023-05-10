namespace Domain.Models;

public class Review
{
    public int ReviewId { get; set; }
    public Order Order { get; set; }
    public DateTime ReviewDate { get; set; }
    public double Rate { get; set; }
    public string Text { get; set; }
}