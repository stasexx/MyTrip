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

    public async Task<bool> DeleteOrder(int orderId)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        if (order!=null)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> ChangeDate(int orderId, DateTime newDate)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        
        if (order!=null)
        {
            order.Date = newDate;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<List<Order>> GetAllOrdersByUserId(int userId)
    {
        return await _context.Orders.Where(o => o.User.UserId == userId).ToListAsync();
    }
    
    public async Task<List<Order>> GetAllOrdersByOrgTourId(int orgTourId)
    {
        return await _context.Orders.Where(o => o.OrgTour.Id==orgTourId).ToListAsync();
    }

}