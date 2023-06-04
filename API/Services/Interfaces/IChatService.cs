using Domain.Models;

namespace API.Services.Interfaces;

public interface IChatService
{
    Task<Chat> CreateChat(int budget);

    Task<Chat> EditBudget(int budget, int chatId);
    
    Task<bool> DeleteChat(int chatId);
    
}