using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class AdminService:IAdminService
{
    private readonly DataContext _context;
    
    public AdminService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> BanUser(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (user!=null)
        {
            user.IsBanned = true;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<bool> UnBanUser(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (user!=null)
        {
            user.IsBanned = false;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<bool> DeleteUser(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (user!=null)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<int> GetCountOfAllUsers()
    {
        return await _context.Users.CountAsync();
    }
    
    public async Task<int> GetCountOfAllTours()
    {
        return await _context.Tours.CountAsync();
    }
}