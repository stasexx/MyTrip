namespace Domain.Models;

public class Message
{
    public int MessageId { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public Membership Membership { get; set; }
    public Chat Chat { get; set; }
}