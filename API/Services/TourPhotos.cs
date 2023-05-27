using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class TourPhotos:ITourPhotos
{
    private readonly DataContext _context;
    
    public TourPhotos(DataContext context)
    {
        _context = context;
    }

    public async Task<List<TourPhoto>> GetTourPhotosByTourId(int id)
    {
        return await _context.TourPhotos.Where(pt => pt.Tour.TourId == id).ToListAsync();
    }
}