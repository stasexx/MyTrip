namespace API.Services.Interfaces;

public interface IAdminService
{
    Task<bool> BanUser(int userId);

    Task<bool> UnBanUser(int userId);

    Task<bool> DeleteUser(int userId);

    Task<int> GetCountOfAllUsers();
    
    Task<int> GetCountOfAllTours();
}