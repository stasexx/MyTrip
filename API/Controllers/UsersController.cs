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

    [HttpGet("api/get/Users")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _userService.GetAllUsersAsync();
    }

    [HttpGet("api/get/UserById")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        return await _userService.GetUserAsync(id);
    }
    
    [HttpPost("api/registration/email={email}/password={password}/firstname={firstName}/lastname={lastName}")]
    public async Task<List<User>> Registration(string email, string password, string firstName, string lastName)
    {
        return await _userService.Registration(email, password, firstName, lastName);
    }
    
    
    [HttpGet("api/get/userByEmail")]
    public async Task<ActionResult<User>> FindForEmail(string email)
    {
        return await _userService.GetUserByEmailAsync(email);
    }
    
    [HttpPost("api/change/Password")]
    public async Task<ActionResult> ChangePassword(string email, string oldPassword, string newPassword)
    {
        if (await _userService.ChangePassword(email,oldPassword, newPassword))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/Login")]
    public async Task<ActionResult> ChangeLogin(string email, string newLogin)
    {
        if (await _userService.ChangeLogin(email, newLogin))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/City")]
    public async Task<ActionResult> ChangeCity(string email, string newCity)
    {
        if (await _userService.ChangeCity(email, newCity))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/PhoneNumber")]
    public async Task<ActionResult> ChangePhoneNumber(string email, string newPhoneNumber)
    {
        if (await _userService.ChangePhoneNumber(email, newPhoneNumber))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/OrgRights")]
    public async Task<ActionResult> ChangeOrgRights(string email, bool newOrgRights)
    {
        if (await _userService.ChangeOrgRights(email, newOrgRights))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/Email")]
    public async Task<ActionResult> ChangeEmail(string email, string password, string newEmail)
    {
        if (await _userService.ChangeEmail(email, password, newEmail))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/FirstName")]
    public async Task<ActionResult> ChangeFirstName(string email, string firstName)
    {
        if (await _userService.ChangeFirstName(email, firstName))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/LastName")]
    public async Task<ActionResult> ChangeLastName(string email, string lastName)
    {
        if (await _userService.ChangeLastName(email, lastName))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/IsBanned")]
    public async Task<ActionResult> ChangeBannedStatus(string email, bool isBanned)
    {
        if (await _userService.ChangeBannedStatus(email, isBanned))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/AvailabilityOfTours")]
    public async Task<ActionResult> ChangeAvailabilityOfTours(string email, bool availabilityOfTours)
    {
        if (await _userService.ChangeAvailabilityOfTours(email, availabilityOfTours))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/change/AvailabilityOfProfile")]
    public async Task<ActionResult> ChangeAvailabilityOfProfile(string email, bool availabilityOfProfile)
    {
        if (await _userService.ChangeAvailabilityOfProfile(email, availabilityOfProfile))
        {
            return Ok();
        }
        return NotFound();
    }
}