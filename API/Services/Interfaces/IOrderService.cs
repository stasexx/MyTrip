using Domain.Models;

namespace API.Services.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrder(int orgTourId, int userId);
}