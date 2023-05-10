namespace Domain.Models;

public class Favourite
{
    public int FavouriteId { get; set; }
    public User User { get; set; }
    public Tour Tour { get; set; }
    
}