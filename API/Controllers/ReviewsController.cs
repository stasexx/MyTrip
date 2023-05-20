using API.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ReviewsController:BaseApiController
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    [HttpGet("api/getAllReviews")]//api/users 
    public async Task<ActionResult<List<Review>>> GetReviews()
    {
        return await _reviewService.GetAllReviewsAsync();
    }
}