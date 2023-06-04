using API.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ChatController:BaseApiController
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost("change/changeBudget/budget={budget}/chatId={chatId}")]
    public async Task<Chat> ChatBudgetEdit(int budget, int chatId)
    {
        return await _chatService.EditBudget(budget, chatId);
    }

    [HttpPost("delete/deleteChat/chatId={chatId}")]
    public async Task<bool> DeleteChat(int chatId)
    {
        return await _chatService.DeleteChat(chatId);
    }

    [HttpPost("create/createChat/budget={budget}")]
    public async Task<Chat> CreateChat(int budget)
    {
        return await _chatService.CreateChat(budget);
    }

}