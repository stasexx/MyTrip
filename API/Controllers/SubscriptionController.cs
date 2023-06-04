using API.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SubscriptionController:BaseApiController
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService  subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }
    
    [HttpGet("get/getAllSubs")]
    public async Task<List<Subscription>> GetAllSubs()
    {
        return await _subscriptionService.GetAllSubs();
    }
    
    [HttpGet("create/createSub/price={price}/duration={duration}")]
    public async Task<bool> CreateSub(int price, int duration)
    {
        return await _subscriptionService.CreateSubscription(price, duration);
    }
}