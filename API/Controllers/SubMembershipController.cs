using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SubMembershipController:BaseApiController
{
    private readonly ISubMembershipService _subMembership;

    public SubMembershipController(ISubMembershipService subMembership)
    {
        _subMembership = subMembership;
    }

    [HttpPost("create/subMembership/subId={subId}/user={userId}")]
    public async Task<bool> TakeSubMembership(int subId, int userId)
    {
        return await _subMembership.TakeSubscription(subId, userId);
    }
    
    [HttpGet("get/checkerForSub/user={userId}")]
    public async Task<bool> CheckerForSub(int userId)
    {
        return await _subMembership.CheckerForSubscription(userId);
    }
}