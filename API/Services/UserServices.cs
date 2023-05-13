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
    
    public async Task<ActionResult<User>> GetUserAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    public async Task<List<User>> Registration(string email, string password)
    {
        User user = new User()
        {
            Password = password,
            Email = email,
            RegDate = DateTime.Today
        };
    
        _context.Users.Add(user);
        await _context.SaveChangesAsync(); // Сохранение изменений в базе данных
    
        return await _context.Users.ToListAsync();
    }
    
}