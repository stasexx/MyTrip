using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


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
    
    public async Task<ActionResult<User>> GetUserAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
}