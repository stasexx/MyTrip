using API.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WishListController : BaseApiController
{
    private readonly IWishListService _wishListService;
    
    public WishListController(IWishListService wishListService)
    {
        _wishListService = wishListService;
    }
    
    [HttpGet("api/get/wishList/{email}")]
    public async Task<ActionResult<List<Favourite>>> GetAllTours(string email)
    {
        return await _wishListService.GetAllWshListForUser(email);
    }
    
    [HttpPost("api/create/newFavourite")]
    public async Task<ActionResult> AddNewFavourite(string email, int tourId)
    {
        if (await _wishListService.AddNewTourToWshList(email, tourId))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("api/delete/favourite")]
    public async Task<ActionResult> DeleteTourFromWshList(int id)
    {
        if (await _wishListService.DeleteTourFromWshList(id))
        {
            return Ok();
        }
        return NotFound();
    }
}