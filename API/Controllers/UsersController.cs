﻿using Domain.Models;
using API.Services.Interfaces;
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

    [HttpGet("api/getUsers")]//api/users 
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _userService.GetAllUsersAsync();
    }

    [HttpGet("api/getUserById")]//api/users/fdsfdsf
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
    public async Task<ActionResult<User>> FindForName(string email)
    {
        return await _userService.GetUserByEmailAsync(email);
    }
}