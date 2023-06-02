using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class WishListService : IWishListService
{
    
    private readonly DataContext _context;
    
    public WishListService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<Favourite>> GetAllWshListForUser(string email)
    {
        return await _context.Favourites
            .Include(f => f.User)
            .Include(f => f.Tour)
            .Where(f => f.User.Email == email)
            .ToListAsync();
    }

    public async Task<bool> AddNewTourToWshList(string email, int id)
    {
        if (_context.Users.FirstOrDefault(u => u.Email == email) != null && _context.Tours.FirstOrDefault(t => t.TourId == id) != null)
        {
            _context.Add(new Favourite()
            {
                User = _context.Users.FirstOrDefault(u => u.Email == email),
                Tour = _context.Tours.FirstOrDefault(t => t.TourId == id)
            });
            await _context.SaveChangesAsync();
            return true;
        }
        
        return false;
    }

    public async Task<bool> DeleteTourFromWshList(int id, string email)
    {
        var item = _context.Favourites.FirstOrDefault(f => f.FavouriteId == id && f.User.Email == email);
        if (item != null)
        {
            _context.Favourites.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
}