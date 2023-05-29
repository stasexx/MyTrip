using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class OrgTourService:IOrgTourService
{
    private readonly DataContext _context;
    
    public OrgTourService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<OrgTour>> GetAllOrgTour()
    {
        return await _context.OrgTours
            .Include(t=>t.Tour)
            .Include(u=>u.User)
            .ToListAsync();
    }

    public async Task<OrgTour> GetOrgTourById(int id)
    {
        return await _context.OrgTours
            .Include(t=>t.Tour)
            .Include(u=>u.User)
            .FirstOrDefaultAsync(h => h.Id == id);
    }
    
    public async Task<List<OrgTour>> GetAllOrgTourWithTourInfo()
    {
        return await _context.OrgTours
            .Include(t => t.Tour).ToListAsync();
    }
    
    public async Task<OrgTour> CreateOrgTour(Tour tour, User user, int experience, int price, string promocode)
    {
        OrgTour orgTour= new OrgTour()
        {
            Experience = experience,
            Price = price,
            Promocode = promocode,
            Tour = tour,
            User = user
        };
        _context.AddAsync(orgTour);
        _context.SaveChangesAsync();
        return await _context.OrgTours.FirstOrDefaultAsync(o=>o.Id == orgTour.Id);
    }
    
}