using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Services;

public class TourServices:ITourService
{
    private readonly DataContext _context;
    
    public TourServices(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Tour>> GetAllToursAsync()
    {
        return await _context.Tours.ToListAsync();
    }

    public async Task<List<Tour>> GetToursBySortRateAsync()
    {
        return await _context.Tours.OrderByDescending(t => t.Rate).ToListAsync();
    }
    
    public async Task<ActionResult<Tour>> GetTourByIdAsync(int id)
    {
        return await _context.Tours.FindAsync(id);
    }
}