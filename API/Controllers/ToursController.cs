using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ToursController : BaseApiController
{
    private readonly ITourService _tourService;
    
    public ToursController(ITourService tourService)
    {
        _tourService = tourService;
    }

    [HttpGet]//api/tours
    public async Task<ActionResult<List<Tour>>> GetUsers()
    {
        return await _tourService.GetAllToursAsync();
    }

    [HttpGet("{id}")]//api/tours/id
    public async Task<ActionResult<Tour>> GetUser(int id)
    {
        return await _tourService.GetTourByIdAsync(id);
    }
}