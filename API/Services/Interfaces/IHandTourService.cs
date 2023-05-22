using Domain.Models;

namespace API.Services.Interfaces;

public interface IHandTourService
{
    Task<List<HandTour>> GetAllHandTour();

    Task<HandTour> GetHandTourById(int id);
    
    Task<List<HandTour>> GetAllHandTourWithTourAndUserInfo();

    Task<HandTour> CreateHandTour(Tour tour, Chat chat, User user);
}