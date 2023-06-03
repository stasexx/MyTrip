using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ToursController : BaseApiController
{
    private readonly ITourService _tourService;
    private readonly IReviewService _reviewService;
    
    public ToursController(ITourService tourService, IReviewService reviewService)
    {
        _tourService = tourService;
        _reviewService = reviewService;
    }

    [HttpGet("get/allTours")]
    public async Task<ActionResult<List<Tour>>> GetAllTours()
    {
        return await _tourService.GetAllToursAsync();
    }

    [HttpGet("get/toursById={id}")]
    public async Task<ActionResult<Tour>> GetTourById(int id)
    {
        return await _tourService.GetTourByIdAsync(id);
    }
    
    [HttpGet("get/tourFilter/country={country}")]
    public async Task<List<Tour>> FilterForTourByCountry(string country)
    {
        return await _tourService.FilterForTourByCountry(country);
    }
    
    [HttpGet("get/tourFilter/category={category}")]
    public async Task<List<Tour>> FilterForTourByCategory(string category)
    {
        return await _tourService.FilterForTourByCategory(category);
    }
    
    [HttpGet("get/tourFilter/country={country}/category={category}")]
    public async Task<List<Tour>> FilterForTourByCategoryAndCategory(string country, string category)
    {
        return await _tourService.FilterForTourByCategoryAndCategory(country, category);
    }

    [HttpPost("create/tour/name={name}/description={description}/rate={rate}/" +
              "typeOfTour={typeOfTour}/category={category}/startDate={startDate}/endDate={endDate}/destination={destination}/" +
              "placeOfDeparture={placeOfDeparture}/countOfUser={countOfUser}/mainPhoto={mainPhoto}/allPhotos={allPhotos}/" +
              "tags={tags}")]
    public async Task<Tour> CreateTour(string name, string description, float rate, string typeOfTour, string category,
        DateTime startDate, DateTime endDate, string destination, string placeOfDeparture, int countOfUser, string mainPhoto,
        string allPhotos, string tags)
    {
        return await _tourService.CreateTour(name, description, rate, typeOfTour, category, startDate, endDate,
            destination, placeOfDeparture, countOfUser, mainPhoto, allPhotos, tags);
    }

    [HttpPost("change/newName={newName}/tourId={id}")]
    public async Task<Tour> ChangeTourName(int id, string newName)
    {
        return await _tourService.ChangeName(id, newName);
    }
    
    [HttpPost("change/rate/tourId={id}")]
    public async Task<Tour> ChangeTourRate(int id)
    {
        var reviews = _reviewService.GetAllReviewsByTourIdAsync(id);
        return await _tourService.ChangeRate(id, reviews);
    }
    
    [HttpPost("change/newCategory={newCategory}/tourId={id}")]
    public async Task<Tour> ChangeTourCategory(int id, string newCategory)
    {
        return await _tourService.ChangeCategory(id, newCategory);
    }
    
    [HttpPost("change/newDestination={newDestination}/tourId={id}")]
    public async Task<Tour> ChangeTourDestination(int id, string newDestination)
    {
        return await _tourService.ChangeDestination(id, newDestination);
    }
    
    [HttpPost("change/newPlaceOfDeparture={newPlaceOfDeparture}/tourId={id}")]
    public async Task<Tour> ChangePlaceOfDeparture(int id, string newPlaceOfDeparture)
    {
        return await _tourService.ChangePlaceOfDeparture(id, newPlaceOfDeparture);
    }
    
    [HttpPost("change/newCountOfUser={newCountOfUser}/tourId={id}")]
    public async Task<Tour> ChangeCountOfUser(int id, string newCountOfUser)
    {
        return await _tourService.ChangeCountOfUser(id, newCountOfUser);
    }
    
    [HttpPost("change/newMainPhoto={newMainPhoto}/tourId={id}")]
    public async Task<Tour> ChangeMainPhoto(int id, string newMainPhoto)
    {
        return await _tourService.ChangeMainPhoto(id, newMainPhoto);
    }
    
    [HttpPost("change/newAllPhotos={newAllPhotos}/tourId={id}")]
    public async Task<Tour> ChangeAllPhotos(int id, string newAllPhotos)
    {
        return await _tourService.ChangeAllPhotos(id, newAllPhotos);
    }
    
    [HttpPost("change/newTags={newTags}/tourId={id}")]
    public async Task<Tour> ChangeTags(int id, string newTags)
    {
        return await _tourService.ChangeTags(id, newTags);
    }
}