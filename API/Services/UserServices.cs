using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace API.Services;

public class UserServices : IUserService
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
            Experience = 0,
            firstName = firstName,
            lastName = lastName,
            phoneNumber = "0",
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
    
    
    public async Task<List<User>> AuthorizationWithOAut(string email, string avatar, string firstName, string lastName)
    {
        if (!_context.Users.Any(u => u.Email.Contains(email)))
        {
            User user = new User()
            {
                Password = "none",
                Email = email,
                Login = "none",
                OrgRights = true,
                Agency = "none",
                Experience = 0,
                firstName = firstName,
                lastName = lastName,
                phoneNumber = "0",
                City = "none",
                Avatar = avatar,
                availabilityOfProfile = true,
                availabilityOfTours = true,
                IsBanned = false,
                RegDate = DateTime.Today
            };
            _context.Users.Add(user);
        }
        
        await _context.SaveChangesAsync();
    
        return await _context.Users.ToListAsync();
    }
    

    public async Task<ActionResult<User>> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> ChangePassword(string email, string oldPassword, string newPassword)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == oldPassword);
        if (user != null)
        {
            user.Password = newPassword;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> ChangeLogin(string email, string newLogin)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.Login = newLogin;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<bool> ChangeCity(string email, string newCity)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.City = newCity;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<bool> ChangePhoneNumber(string email, string newPhoneNumber)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.phoneNumber = newPhoneNumber;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<bool> ChangeOrgRights(string email, bool newOrgRights)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.OrgRights = newOrgRights;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }


}