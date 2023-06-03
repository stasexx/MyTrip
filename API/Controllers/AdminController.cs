using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AdminController:BaseApiController
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("ban/banUser/userId={userId}")]
    public async Task<bool> BanUser(int userId)
    {
        return await _adminService.BanUser(userId);
    }
    
    [HttpPost("ban/unbanUser/userId={userId}")]
    public async Task<bool> UnBanUser(int userId)
    {
        return await _adminService.UnBanUser(userId);
    }
    
    [HttpPost("delete/deleteUser/userId={userId}")]
    public async Task<bool> DeleteUser(int userId)
    {
        return await _adminService.DeleteUser(userId);
    }
    
    [HttpGet("stats/countOfAllUsers")]
    public async Task<int> CountOfAllUsers()
    {
        return await _adminService.GetCountOfAllUsers();
    }
    
    [HttpGet("stats/countOfAllTours")]
    public async Task<int> CountOfAllTours()
    {
        return await _adminService.GetCountOfAllTours();
    }
}