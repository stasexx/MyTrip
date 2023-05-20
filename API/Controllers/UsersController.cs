using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class UsersController : BaseApiController
{
    private readonly IUserService _userService;
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("api/getUsers")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _userService.GetAllUsersAsync();
    }

    [HttpGet("api/getUserById")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        return await _userService.GetUserAsync(id);
    }
    
    [HttpPost("api/registration")]
    public async Task<List<User>> Registration(string email, string password, string firstName, string lastName)
    {
        return await _userService.Registration(email, password, firstName, lastName);
    }
    
    
    [HttpGet("api/checkForEmail")]
    public async Task<ActionResult<User>> FindForEmail(string email)
    {
        return await _userService.GetUserByEmailAsync(email);
    }
    
    [HttpPost("api/changePassword")]
    public async Task<ActionResult> ChangePassword(string email, string oldPassword, string newPassword)
    {
        if (await _userService.ChangePassword(email,oldPassword, newPassword))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/changeLogin")]
    public async Task<ActionResult> ChangeLogin(string email, string newLogin)
    {
        if (await _userService.ChangeLogin(email, newLogin))
        {
            return Ok();
        }
        return NotFound();
    }
}