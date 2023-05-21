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
    
    [HttpGet("get/wishList/email={email}")]
    public async Task<ActionResult<List<Favourite>>> GetAllTours(string email)
    {
        return await _wishListService.GetAllWshListForUser(email);
    }
    
    [HttpPost("create/newFavourite/tourId={tourId}")]
    public async Task<ActionResult> AddNewFavourite(string email, int tourId)
    {
        if (await _wishListService.AddNewTourToWshList(email, tourId))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("delete/favourite/id={id}")]
    public async Task<ActionResult> DeleteTourFromWshList(int id)
    {
        if (await _wishListService.DeleteTourFromWshList(id))
        {
            return Ok();
        }
        return NotFound();
    }
}