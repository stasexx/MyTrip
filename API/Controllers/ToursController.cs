using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ToursController : BaseApiController
{
    private readonly ITourService _tourService;
    
    public ToursController(ITourService tourService)
    {
        _tourService = tourService;
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
}