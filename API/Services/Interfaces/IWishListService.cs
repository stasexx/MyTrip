using Domain.Models;

namespace API.Services.Interfaces;

public interface IWishListService
{
    Task<List<Favourite>> GetAllWshListForUser(string email);
    
    Task<bool> AddNewTourToWshList(string email, int id);
    
    Task<bool> DeleteTourFromWshList(int id);
}