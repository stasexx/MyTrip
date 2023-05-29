using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrderController:BaseApiController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("create/createOrder/orgTourId={orgTourId}/userId={userId}")]
    public async Task<Order> CreateOrder(int orgTourId, int userId)
    {
        return await _orderService.CreateOrder(orgTourId, userId);
    }
}