using Domain.Models;

namespace API.Services.Interfaces;

public interface IUserService
{ 
    Task<List<User>> GetAllUsersAsync();
}