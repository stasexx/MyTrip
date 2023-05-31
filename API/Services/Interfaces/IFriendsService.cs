using Domain.Models;

namespace API.Services.Interfaces;

public interface IFriendsService
{
    Task<List<Friends>> GetFriendsByUserId(int id);

    Task<bool> CreateFriendShip(int user1Id, int user2Id);
    
    Task<bool> DeleteFriendShip(int user1Id, int user2Id);
}