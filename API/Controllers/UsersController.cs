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

    [HttpGet("get/Users")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _userService.GetAllUsersAsync();
    }

    [HttpGet("get/userById={id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        return await _userService.GetUserAsync(id);
    }
    
    [HttpPost("registration/email={email}/password={password}/firstname={firstName}/lastname={lastName}")]
    public async Task<List<User>> Registration(string email, string password, string firstName, string lastName)
    {
        return await _userService.Registration(email, password, firstName, lastName);
    }
    
    [HttpPost("registration/oauth/email={email}/avatar={avatar}/firstname={firstName}/lastname={lastName}")]
    public async Task<ActionResult<User>> RegistrationByOauth(string email, string avatar, string firstName, string lastName)
    {
        return await _userService.AuthorizationWithOAut(email, avatar, firstName, lastName);
    }
    
    
    [HttpGet("get/userByEmail={email}")]
    public async Task<ActionResult<User>> FindForEmail(string email)
    {
        return await _userService.GetUserByEmailAsync(email);
    }
    
    [HttpGet("get/getAllToursWitchCreateBydUser/userId={userId}")]
    public async Task<List<int>> GetAllToursWitchCreateBydUser(int userId)
    {
        return await _userService.GetAllToursWitchCreateBydUser(userId);
    }
    
    [HttpGet("get/userDateForProfile/userId={userId}")]
    public async Task<ActionResult<object>> GetDateForUser(int userId)
    {
        var data = await _userService.GetDateForUser(userId);
    
        var result = new
        {
            travelCount = data.travelCount,
            createdTourCount = data.createdTourCount,
            latestBookingStartDate = data.latestBookingStartDate
        };

        return result;
    }

    [HttpGet("get/getAllToursIdForUser/userId={userId}")]
    public async Task<List<int>> GetAllToursIdForUser(int userId)
    {
        return await _userService.GetAllToursIdForUser(userId);
    }
    [HttpGet("get/userRecentBookedTourBuLast30DaysIds/userId={userId}")]
    public async Task<List<int>> GetRecentBookedTourBuLast30DaysIds(int userId)
    {
        return await _userService.GetRecentBookedTourIdsByLast30Days(userId);
    }
    
    [HttpPost("change/oldPassword={oldPassword}/newPassword={newPassword}/email={email}")]
    public async Task<ActionResult> ChangePassword(string email, string oldPassword, string newPassword)
    {
        if (await _userService.ChangePassword(email,oldPassword, newPassword))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/newLogin={newLogin}/email={email}")]
    public async Task<ActionResult> ChangeLogin(string email, string newLogin)
    {
        if (await _userService.ChangeLogin(email, newLogin))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/newCity={newCity}/email={email}")]
    public async Task<ActionResult> ChangeCity(string email, string newCity)
    {
        if (await _userService.ChangeCity(email, newCity))
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPost("change/newAvatar={newAvatar}/email={email}")]
    public async Task<ActionResult> ChangeAvatar(string email, string newAvatar)
    {
        if (await _userService.ChangeAvatar(email, newAvatar))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/newPhoneNumber={newPhoneNumber}/email={email}")]
    public async Task<ActionResult> ChangePhoneNumber(string email, string newPhoneNumber)
    {
        if (await _userService.ChangePhoneNumber(email, newPhoneNumber))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/newOrgRights={newOrgRights}/email={email}")]
    public async Task<ActionResult> ChangeOrgRights(string email, bool newOrgRights)
    {
        if (await _userService.ChangeOrgRights(email, newOrgRights))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/email={email}/password={password}/newEmail={newEmail}")]
    public async Task<ActionResult> ChangeEmail(string email, string password, string newEmail)
    {
        if (await _userService.ChangeEmail(email, password, newEmail))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/firstName={firstName}/email={email}")]
    public async Task<ActionResult> ChangeFirstName(string email, string firstName)
    {
        if (await _userService.ChangeFirstName(email, firstName))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/lastName={lastName}/email={email}")]
    public async Task<ActionResult> ChangeLastName(string email, string lastName)
    {
        if (await _userService.ChangeLastName(email, lastName))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/isBanned={isBanned}/email={email}")]
    public async Task<ActionResult> ChangeBannedStatus(string email, bool isBanned)
    {
        if (await _userService.ChangeBannedStatus(email, isBanned))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/availabilityOfTours={availabilityOfTours}/email={email}")]
    public async Task<ActionResult> ChangeAvailabilityOfTours(string email, bool availabilityOfTours)
    {
        if (await _userService.ChangeAvailabilityOfTours(email, availabilityOfTours))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("change/availabilityOfProfile={availabilityOfProfile}/email={email}")]
    public async Task<ActionResult> ChangeAvailabilityOfProfile(string email, bool availabilityOfProfile)
    {
        if (await _userService.ChangeAvailabilityOfProfile(email, availabilityOfProfile))
        {
            return Ok();
        }
        return NotFound();
    }
}