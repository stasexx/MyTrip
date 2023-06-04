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
    
    [HttpPost("delete/deleteOrder/orderId={orderId}")]
    public async Task<bool> DeleteOrder(int orderId)
    {
        return await _orderService.DeleteOrder(orderId);
    }
    
    [HttpPost("change/changeDateOfOrder/orderId={orderId}/newDate={newDate}")]
    public async Task<bool> ChangeDateOfOrder(int orderId, DateTime newDate)
    {
        return await _orderService.ChangeDate(orderId, newDate);
    }
    
    [HttpGet("get/getOrdersByUserId/userId={userId}")]
    public async Task<List<Order>> GetAllOrdersByUserId(int userId)
    {
        return await _orderService.GetAllOrdersByUserId(userId);
    }
    
    [HttpGet("get/getOrdersByOrgTourId/userId={userId}")]
    public async Task<List<Order>> GetAllOrdersByOrgTourId(int orgTourId)
    {
        return await _orderService.GetAllOrdersByOrgTourId(orgTourId);
    }
}