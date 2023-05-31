using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class FriendsService:IFriendsService
{
    private readonly DataContext _context;
    
    public FriendsService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Friends>> GetFriendsByUserId(int id)
    {
        return await _context.Friends
            .Include(us1=>us1.User1)
            .Include(us2=>us2.User2)
            .Where(u => u.User1.UserId == id || u.User2.UserId == id).ToListAsync();
    }
    
    public async Task<bool> CreateFriendShip(int user1Id, int user2Id)
    {
        var user1 = _context.Users.FirstOrDefaultAsync(u => u.UserId == user1Id);
        var user2 = _context.Users.FirstOrDefaultAsync(u => u.UserId == user2Id);
        if (user1!=null && user2!=null)
        {
            Friends friends = new Friends()
            {
                User1 = user1.Result,
                User2 = user2.Result
            };
            _context.Friends.Add(friends);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<bool> DeleteFriendShip(int user1Id, int user2Id)
    {
        var friends = _context.Friends
            .FirstOrDefaultAsync(u1 => u1.User1.UserId == user1Id && u1.User2.UserId == user2Id).Result;
        if (friends==null)
        {
            friends = _context.Friends
                .FirstOrDefaultAsync(u1 => u1.User1.UserId == user2Id && u1.User2.UserId == user1Id).Result;
        }
        if (friends!=null)
        {
            _context.Remove(friends);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}