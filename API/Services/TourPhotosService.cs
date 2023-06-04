using API.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class TourPhotosService:ITourPhotosService
{
    private readonly DataContext _context;
    
    public TourPhotosService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<TourPhoto>> GetTourPhotosByTourId(int id)
    {
        return await _context.TourPhotos.Where(pt => pt.Tour.TourId == id).ToListAsync();
    }

    public async Task<bool> AddTourPhotosByTourId(int tourId, string uuid)
    {
        var tour = await _context.Tours.FirstOrDefaultAsync(t => t.TourId == tourId);
        if (tour!=null)
        {
            var tourPhoto = new TourPhoto()
            {
                Tour = tour,
                UUID = uuid
            };
            await _context.TourPhotos.AddAsync(tourPhoto);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> RemoveTourPhotoById(int id)
    {
        var tourPhoto = await _context.TourPhotos.FirstOrDefaultAsync(p => p.TourPhotoId == id);
        if (tourPhoto!=null)
        {
            _context.TourPhotos.Remove(tourPhoto);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<bool> RemoveAllTourPhotosByTourId(int tourId)
    {
        await _context.TourPhotos.Where(t=>t.Tour.TourId==tourId).ExecuteDeleteAsync();
        return true;
    }
}