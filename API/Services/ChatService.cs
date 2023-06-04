using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Chat> EditBudget(int budget, int chatId)
    {
        var chat = _context.Chats.FirstOrDefault(c => c.ChatId == chatId);
        if (chat!=null)
        {
            chat.Budget = budget;
            await _context.SaveChangesAsync();
        }
        return chat;
    }

    public async Task<bool> DeleteChat(int chatId)
    {
        var chat = _context.Chats.FirstOrDefault(c => c.ChatId == chatId);
        if (chat!=null)
        {
            _context.Remove(chat);
            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
        }
        return false;
    }
}