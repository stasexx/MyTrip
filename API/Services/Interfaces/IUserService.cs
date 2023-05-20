using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces;

public interface IUserService
{ 
    Task<List<User>> GetAllUsersAsync();
    
    Task<ActionResult<User>> GetUserAsync(int id);

    Task<List<User>> Registration(string email, string password, string firstName, string lastName);
    
    Task<List<User>> AuthorizationWithOAut(string email, string avatar, string firstName, string lastName);
    
    Task<ActionResult<User>> GetUserByEmailAsync(string email);
    
    Task<bool> ChangePassword(string email, string oldPassword, string newPassword);
    
    Task<bool> ChangeLogin(string email, string newLogin);
    
    Task<bool> ChangeCity(string email, string newCity);
    
    Task<bool> ChangePhoneNumber(string email, string newPhoneNumber);
    
    Task<bool> ChangeOrgRights(string email, bool newOrgRights);
    
}