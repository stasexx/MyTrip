﻿using Domain.Models;
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
    
    public async Task<(int travelCount, int createdTourCount, DateTime? latestBookingStartDate)> GetDateForUser(int userId)
    {
        var travelCount = await _context.Orders
            .CountAsync(o => o.User.UserId == userId);
        
        var createdHandTourCount = await _context.HandTours
            .CountAsync(t => t.User.UserId == userId);
        
        var createdOrgTourCount = await _context.OrgTours
            .CountAsync(t => t.User.UserId == userId);

        var latestBookingStartDate = await _context.Orders
            .Where(o => o.User.UserId == userId)
            .OrderByDescending(o => o.OrgTour.Tour.startDate)
            .Select(o => (DateTime?)o.OrgTour.Tour.startDate)
            .FirstOrDefaultAsync();

        return (travelCount, createdHandTourCount+createdOrgTourCount, latestBookingStartDate);
    }
    
    public async Task<List<int>> GetRecentBookedTourIdsByLast30Days(int userId)
    {
        var thirtyDaysAgo = DateTime.Now.AddDays(-30);

        var tourIds = await _context.Orders
            .Where(o => o.User.UserId == userId && o.OrgTour.Tour.startDate>= thirtyDaysAgo)
            .Select(o => o.OrgTour.Tour.TourId)
            .ToListAsync();


        var handToursId= await _context.HandTours.Where(h => h.User.UserId == userId && h.Tour.startDate > thirtyDaysAgo)
            .Select(h => h.Tour.TourId).ToListAsync();
        
        tourIds.AddRange(handToursId);
        
        return tourIds;
    }
    
    public async Task<List<User>> Registration(string email, string password, string firstName, string lastName)
    {
        if (!_context.Users.Any(u => u.Email.Contains(email)))
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
        }
        return await _context.Users.ToListAsync();
    }
    
    public async Task<List<int>> GetAllToursIdForUser(int userId)
    {
        return await _context.Orders.Where(u => u.User.UserId == userId).Select(i => i.OrgTour.Tour.TourId)
            .ToListAsync();
    }
    
    public async Task<List<int>> GetAllToursWitchCreateBydUser(int userId)
    {
        var orgTours = await _context.OrgTours.Where(u => u.User.UserId == userId).Select(i => i.Tour.TourId).ToListAsync();
        var handTours = await _context.HandTours.Where(u => u.User.UserId == userId).Select(i => i.Tour.TourId).ToListAsync();
        orgTours.AddRange(handTours);
        return orgTours;
    }
    public async Task<ActionResult<User>> AuthorizationWithOAut(string email, string avatar, string firstName, string lastName)
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
    
        return await _context.Users.FirstOrDefaultAsync(u=>u.Email==email);
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

    public async Task<bool> ChangeAvatar(string email, string newAvatar)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.Avatar = newAvatar;
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
    
    public async Task<bool> ChangeEmail(string email, string password, string newEmail)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            user.Email = newEmail;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<bool> ChangeFirstName(string email, string firstName)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.firstName = firstName;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<bool> ChangeLastName(string email, string lastName)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.lastName = lastName;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<bool> ChangeAvailabilityOfProfile(string email, bool availabilityOfProfile)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.availabilityOfProfile = availabilityOfProfile;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<bool> ChangeAvailabilityOfTours(string email, bool availabilityOfTours)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.availabilityOfTours = availabilityOfTours;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<bool> ChangeBannedStatus(string email, bool isBanned)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            user.IsBanned = isBanned;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }


}