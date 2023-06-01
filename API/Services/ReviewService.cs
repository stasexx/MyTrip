using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class ReviewService : IReviewService
{
    private readonly DataContext _context;
    
    public ReviewService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Review>> GetAllReviewsAsync()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task<List<Review>> GetAllReviewsByTourIdAsync(int id)
    {
        return await _context.Reviews.Include(o=>o.Order)
            .Include(o=>o.Order.OrgTour)
            .Include(o=>o.Order.OrgTour.Tour)
            .Include(o=>o.Order.User)
            .Where(r => r.Order.OrgTour.Tour.TourId == id).ToListAsync();
    }

    public async Task<bool> CreateReviewAsync(int orderId, DateTime reviewDate, double rate, string text)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        if (order!=null)
        {
            Review review = new Review()
            {
                Order = order,
                ReviewDate = reviewDate,
                Rate = rate,
                Text = text
            };
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}