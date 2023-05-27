using Domain.Models;

namespace API.Services.Interfaces;

public interface ITourPhotos
{
    Task<List<TourPhoto>> GetTourPhotosByTourId(int id);
}