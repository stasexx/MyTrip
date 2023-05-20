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
}