using Domain.Models;

namespace API.Services.Interfaces;

public interface ITourPhotosService
{
    Task<List<TourPhoto>> GetTourPhotosByTourId(int id);
}