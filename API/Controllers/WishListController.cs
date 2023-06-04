﻿using API.Services.Interfaces;
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
    public async Task<ActionResult<List<Favourite>>> GetAllWishListForUser(string email)
    {
        return await _wishListService.GetAllWshListForUser(email);
    }
    
    [HttpPost("create/newFavourite/tourId={tourId}/email={email}")]
    public async Task<ActionResult> AddNewFavourite(string email, int tourId)
    {
        if (await _wishListService.AddNewTourToWshList(email, tourId))
        {
            return Ok();
        }
        return NotFound();
    }
    
    [HttpPost("delete/favourite/tourId={id}/email={email}")]
    public async Task<ActionResult> DeleteTourFromWshList(int id, string email)
    {
        if (await _wishListService.DeleteTourFromWshList(id, email))
        {
            return Ok();
        }
        return NotFound();
    }
}