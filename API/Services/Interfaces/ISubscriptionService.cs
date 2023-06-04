using Domain.Models;

namespace API.Services.Interfaces;

public interface ISubscriptionService
{
    Task<bool> CreateSubscription(int price, int duration);

    Task<List<Subscription>> GetAllSubs();
}