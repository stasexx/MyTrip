using API.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class FriendsController:BaseApiController
{
    private readonly IFriendsService _friendsService;

    public FriendsController(IFriendsService friendsService)
    {
        _friendsService = friendsService;
    }

    [HttpGet("get/getFriendsById/id={id}")]
    public async Task<List<Friends>> GetFriendsByUserId(int id)
    {
        return await _friendsService.GetFriendsByUserId(id);
    }
    
    [HttpPost("create/createFriendShip/user1id={user1id}/user2id={user2id}")]
    public async Task<bool> CreateFriendShip(int user1id, int user2id)
    {
        return await _friendsService.CreateFriendShip(user1id, user2id);
    }

    [HttpPost("delete/deleteFriendShip/user1id={user1id}/user2id={user2id}")]
    public async Task<bool> DeleteFriendShip(int user1id, int user2id)
    {
        return await _friendsService.DeleteFriendShip(user1id, user2id);
    }
}