using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class OrderService:IOrderService
{
    private readonly DataContext _context;
    
    public OrderService(DataContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrder(int orgTourId, int userId)
    {
        var orgTour = await _context.OrgTours.FirstOrDefaultAsync(o => o.Id == orgTourId);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        Order order = new Order()
        {
            Date = DateTime.Now.Date,
            OrgTour = orgTour,
            User = user
        };
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }
    
}