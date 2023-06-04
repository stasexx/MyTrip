using Domain.Models;

namespace API.Services.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrder(int orgTourId, int userId);

    Task<bool> DeleteOrder(int orderId);

    Task<bool> ChangeDate(int orderId, DateTime newDate);

    Task<List<Order>> GetAllOrdersByUserId(int userId);
    
    Task<List<Order>> GetAllOrdersByOrgTourId(int orgTourId);
}