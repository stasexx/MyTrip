using Domain.Models;

namespace Persistence;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    
    public DbSet<Tour> Tours { get; set; }
    
    public DbSet<HandTour> HandTours { get; set; }
    
    public DbSet<OrgTour> OrgTours { get; set; }
    
    public DbSet<Favourite> Favourites { get; set; }
    
    public DbSet<TourPhoto> TourPhotos { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Friends> Friends { get; set; }
    
    public DbSet<Chat> Chats { get; set; }
    
    public DbSet<Message> Messages { get; set; }
    
    public DbSet<Membership> Memberships { get; set; }
}