using Domain.Models;

namespace API.Services.Interfaces;

public interface IReviewService
{
    Task<List<Review>> GetAllReviewsAsync();
    
    Task<List<Review>> GetAllReviewsByTourIdAsync(int id);
    
    Task<bool> CreateReviewAsync(int orderId, DateTime reviewDate, double rate, string text);
}