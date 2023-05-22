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
    
    public Task<List<OrgTour>> GetAllOrgTour()
    {
        return _context.OrgTours.ToListAsync();
    }

    public Task<OrgTour> GetOrgTourById(int id)
    {
        return _context.OrgTours.FirstOrDefaultAsync(h => h.Id == id);
    }
    
    public Task<List<OrgTour>> GetAllOrgTourWithTourInfo()
    {
        return _context.OrgTours
            .Include(t => t.Tour).ToListAsync();
    }
    
}