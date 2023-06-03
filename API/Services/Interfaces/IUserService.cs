using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces;

public interface IUserService
{ 
    Task<List<User>> GetAllUsersAsync();
    
    Task<ActionResult<User>> GetUserAsync(int id);

    Task<List<User>> Registration(string email, string password, string firstName, string lastName);
    
    Task<ActionResult<User>> AuthorizationWithOAut(string email, string avatar, string firstName, string lastName);
    
    Task<ActionResult<User>> GetUserByEmailAsync(string email);

    Task<(int travelCount, int createdTourCount, DateTime? latestBookingStartDate)> GetDateForUser(int userId);

    Task<List<int>> GetRecentBookedTourIdsByLast30Days(int userId);
    
    Task<List<int>> GetAllToursIdForUser(int userId);

    Task<List<int>> GetAllToursWitchCreateBydUser(int userId);
    
    Task<bool> ChangePassword(string email, string oldPassword, string newPassword);
    
    Task<bool> ChangeLogin(string email, string newLogin);
    
    Task<bool> ChangeAvatar(string email, string newAvatar);
    
    Task<bool> ChangeCity(string email, string newCity);
    
    Task<bool> ChangePhoneNumber(string email, string newPhoneNumber);
    
    Task<bool> ChangeOrgRights(string email, bool newOrgRights);
    
    Task<bool> ChangeFirstName(string email, string newFirstName);
    
    Task<bool> ChangeLastName(string email, string newLastName);
    
    Task<bool> ChangeEmail(string email, string password, string newOrgRights);
    
    Task<bool> ChangeAvailabilityOfProfile(string email, bool availabilityOfProfile);
    
    Task<bool> ChangeAvailabilityOfTours(string email, bool availabilityOfTours);
    
    Task<bool> ChangeBannedStatus(string email, bool isBanned);
    
}