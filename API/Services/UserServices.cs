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
    
    public async Task<List<User>> Registration(string email, string password, string firstName, string lastName)
    {
        User user = new User()
        {
            Password = password,
            Email = email,
            Login = "none",
            OrgRights = true,
            Agency = "none",
            Experience = 120,
            firstName = firstName,
            lastName = lastName,
            phoneNumber = 12345,
            City = "none",
            Avatar = "none",
            availabilityOfProfile = true,
            availabilityOfTours = true,
            IsBanned = false,
            RegDate = DateTime.Today
        };
    
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    
        return await _context.Users.ToListAsync();
    }
    
}