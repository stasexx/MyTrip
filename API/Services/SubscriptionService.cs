using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class SubscriptionService:ISubscriptionService
{
    private readonly DataContext _context;
    
    public SubscriptionService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateSubscription(int price, int duration)
    {
        var sub = new Subscription()
        {
            Price = price,
            Duration = duration
        };
        await _context.Subscriptions.AddAsync(sub);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Subscription>> GetAllSubs()
    {
        return await _context.Subscriptions.ToListAsync();
    }
}