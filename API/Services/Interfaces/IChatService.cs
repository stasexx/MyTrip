using Domain.Models;

namespace API.Services.Interfaces;

public interface IChatService
{
    Task<Chat> CreateChat(int budget);
}