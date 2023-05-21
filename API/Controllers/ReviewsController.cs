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
    
    [HttpGet("getAllReviews")]
    public async Task<ActionResult<List<Review>>> GetReviews()
    {
        return await _reviewService.GetAllReviewsAsync();
    }
    
    [HttpGet("get/reviews/tourId={id}")]
    public async Task<ActionResult<List<Review>>> GetAllReviewsByTourIdAsync(int id)
    {
        return await _reviewService.GetAllReviewsByTourIdAsync(id);
    }
}