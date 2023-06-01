using Domain.Models;

namespace API.Services.Interfaces;

public interface ISubMembershipService
{
    Task<bool> TakeSubscription(int userId, int subId);
    
    Task<bool> CheckerForSubscription(int userId);
}