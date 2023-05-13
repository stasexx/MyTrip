using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using API.Services.Interfaces;


namespace API.Services;

public class UserServices:IUserService
{
    private readonly DataContext _context;
    
    public UserServices(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}