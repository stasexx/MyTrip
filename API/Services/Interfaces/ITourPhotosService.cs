using Domain.Models;

namespace API.Services.Interfaces;

public interface ITourPhotosService
{
    Task<List<TourPhoto>> GetTourPhotosByTourId(int id);
    
    Task<bool> AddTourPhotosByTourId(int tourId, string uuid);
    
    Task<bool> RemoveTourPhotoById(int id);
    
    Task<bool> RemoveAllTourPhotosByTourId(int tourId);
}