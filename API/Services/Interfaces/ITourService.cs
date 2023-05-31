using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces;

public interface ITourService
{ 
    Task<List<Tour>> GetAllToursAsync();
    
    Task<ActionResult<Tour>> GetTourByIdAsync(int id);

    Task<Tour> CreateTour(string name, string description, float rate, string typeOfTour, string category,
        DateTime startDate,
        DateTime endDate, string destination, string placeOfDeparture, int countOfUser, string mainPhoto,
        string allPhotos, string tags);

    Task<Tour> ChangeName(int id, string newName);

    Task<Tour> ChangeDescription(int id, string newDescription);
    
    Task<Tour> ChangeRate(int id, Task<List<Review>> reviews);
    
    Task<Tour> ChangeTypeOfTour(int id, string newTypeOfTour);
    
    Task<Tour> ChangeCategory(int id, string newCategory);
    
    Task<Tour> ChangeDestination(int id, string newDestination);
    
    Task<Tour> ChangePlaceOfDeparture(int id, string newPlaceOfDeparture);
    
    Task<Tour> ChangeCountOfUser(int id, string newCountOfUser);
    
    Task<Tour> ChangeMainPhoto(int id, string newMainPhoto);
    
    Task<Tour> ChangeAllPhotos(int id, string newAllPhotos);
    
    Task<Tour> ChangeTags(int id, string newTags);

    Task<List<Tour>> FilterForTourByCategory(string category);
    
    Task<List<Tour>> FilterForTourByCountry(string country);
}