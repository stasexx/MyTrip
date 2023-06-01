using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class SubMembershipService:ISubMembershipService
{
    private readonly DataContext _context;
    
    public SubMembershipService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> TakeSubscription(int userId, int subId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        var sub = await _context.Subscriptions.FirstOrDefaultAsync(s => s.SubscriptionId == subId);
        if (user!=null && sub!=null)
        {
            SubMembership subMembership = new SubMembership()
            {
                User = user,
                Subscription = sub,
                beginSubDate = DateTime.Now
            };
            await _context.SubMemberships.AddAsync(subMembership);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> CheckerForSubscription(int userId)
    {
        var membership = await _context.SubMemberships.Where(u => u.User.UserId == userId).Include(s=>s.Subscription)
            .OrderByDescending(s => s.beginSubDate.Date).FirstOrDefaultAsync();
        DateTime subTime = await _context.SubMemberships.Where(u => u.User.UserId == userId)
            .OrderByDescending(s => s.beginSubDate.Date).Select(s => s.beginSubDate.Date).FirstOrDefaultAsync();
        var result = DateTime.Now.Date - subTime;
        
        if (result.TotalDays<membership.Subscription.Duration)
        {
            return true;
        }
        return false;
    }
}