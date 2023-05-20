using Domain.Models;

namespace API.Services.Interfaces;

public interface IReviewService
{
    Task<List<Review>> GetAllReviewsAsync();
}