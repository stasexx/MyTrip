using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces;

public interface IUserService
{ 
    Task<List<User>> GetAllUsersAsync();
    
    Task<ActionResult<User>> GetUserAsync(int id);
}