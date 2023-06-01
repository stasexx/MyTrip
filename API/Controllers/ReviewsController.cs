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
    
    [HttpGet("get/getAllReviews")]
    public async Task<ActionResult<List<Review>>> GetReviews()
    {
        return await _reviewService.GetAllReviewsAsync();
    }
    
    [HttpGet("get/reviews/tourId={id}")]
    public async Task<ActionResult<List<Review>>> GetAllReviewsByTourIdAsync(int id)
    {
        return await _reviewService.GetAllReviewsByTourIdAsync(id);
    }
    
    [HttpPost("create/reviews/orderId={orderId}/reviewDate={reviewDate}/rate={rate}/text={text}")]
    public async Task<bool> CreateReviewAsync(int orderId, DateTime reviewDate, double rate, string text)
    {
        return await _reviewService.CreateReviewAsync(orderId, reviewDate, rate, text);
    }
}