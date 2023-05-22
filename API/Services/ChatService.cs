using API.Services.Interfaces;
using Domain.Models;
using Persistence;

namespace API.Services;

public class ChatService:IChatService
{
    private readonly DataContext _context;
    
    public ChatService(DataContext context)
    {
        _context = context;
    }

    public async Task<Chat> CreateChat(int budget)
    {
        Chat chat = new Chat()
        {
            Budget = budget
        };
        _context.Chats.AddAsync(chat);
        _context.SaveChangesAsync();
        return chat;
    }
}