using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class HandTourService:IHandTourService
{
    private readonly DataContext _context;
    
    public HandTourService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<HandTour>> GetAllHandTour()
    {
        return await _context.HandTours.ToListAsync();
    }

    public async Task<HandTour> GetHandTourById(int id)
    {
        return await _context.HandTours.FirstOrDefaultAsync(h => h.Id == id);
    }
    
    public async Task<HandTour> GetHandTourByTourId(int id)
    {
        return await _context.HandTours.Include(t=>t.Tour)
            .Include(u=>u.User)
            .FirstOrDefaultAsync(h => h.Tour.TourId == id);
    }
    
    public async Task<List<HandTour>>GetAllHandTourWithTourAndUserInfo()
    {
        return await _context.HandTours.Include(t => t.Tour)
            .Include(u=>u.User)
            .ToListAsync();
    }
    
    
    public async Task<HandTour> CreateHandTour(Tour tour, Chat chat, User user)
    {
        HandTour handTour = new HandTour()
        {
            Tour = tour,
            Chat = chat,
            User = user
        };
        _context.AddAsync(handTour);
        _context.SaveChangesAsync();
        return await _context.HandTours.FirstOrDefaultAsync(c=>c.Chat==chat);
    }
    
}