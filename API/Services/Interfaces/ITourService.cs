using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces;

public interface ITourService
{ 
    Task<List<Tour>> GetAllToursAsync();
    
    Task<ActionResult<Tour>> GetTourByIdAsync(int id);

    Task<Tour> CreateTour(string name, string description, float rate, string typeOfTour, string Category,
        DateTime startDate,
        DateTime endDate, string destination, string placeOfDeparture, int countOfUser, string mainPhoto,
        string allPhotos, string tags);
}