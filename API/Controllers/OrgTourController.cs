using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrgTourController:BaseApiController
{
    private readonly IOrgTourService _orgTourService;
    private readonly IUserService _userService;
    private readonly ITourService _tourService;
    
    public OrgTourController(IOrgTourService orgTourService, IUserService userService, ITourService tourService)
    {
        _orgTourService = orgTourService;
        _userService = userService;
        _tourService = tourService;
    }
    
    [HttpGet("get/getAllOrgTours")]
    public async Task<ActionResult<List<OrgTour>>> GetAllOrgTours()
    {
        return await _orgTourService.GetAllOrgTour();
    }
    
    [HttpGet("get/orgTourById/orgTourId={id}")]
    public async Task<ActionResult<OrgTour>> GetOrgTourById(int id)
    {
        return await _orgTourService.GetOrgTourById(id);
    }
    
    [HttpGet("get/orgTourByTourId/tourId={id}")]
    public async Task<ActionResult<OrgTour>> GetOrgTourByTourId(int id)
    {
        return await _orgTourService.GetOrgTourByTourId(id);
    }
    
    [HttpGet("get/getAllOrgToursWithTourInfo")]
    public async Task<ActionResult<List<OrgTour>>> GetAllOrgTourWithTourInfo()
    {
        return await _orgTourService.GetAllOrgTourWithTourInfo();
    }
    
    [HttpGet("get/tourFilter/orgTour/country={country}")]
    public async Task<List<OrgTour>> FilterForHandTourByCountry(string country)
    {
        return await _orgTourService.FilterForOrgTourByCountry(country);
    }
    
    [HttpGet("get/tourFilter/orgTour/category={country}")]
    public async Task<List<OrgTour>> FilterForHandTourByCategory(string category)
    {
        return await _orgTourService.FilterForOrgTourByCategory(category);
    }

    [HttpPost("create/createOrgTour/name={name}/description={description}/rate={rate}/" +
              "typeOfTour={typeOfTour}/category={category}/startDate={startDate}/endDate={endDate}/destination={destination}/" +
              "placeOfDeparture={placeOfDeparture}/countOfUser={countOfUser}/mainPhoto={mainPhoto}/allPhotos={allPhotos}/" +
              "tags={tags}/experience={experience}/price={price}/promocode={promocode}/email={email}")]
    public async Task<OrgTour> CreateOrgTour(string name, string description, float rate, string typeOfTour,
        string category,
        DateTime startDate, DateTime endDate, string destination, string placeOfDeparture, int countOfUser,
        string mainPhoto,
        string allPhotos, string tags, int experience, int price, string promocode, string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        var tour = await _tourService.CreateTour(name, description, rate, typeOfTour, category, startDate, endDate,
            destination, placeOfDeparture, countOfUser, mainPhoto, allPhotos, tags);
        return await _orgTourService.CreateOrgTour(tour, user.Value, experience, price, promocode);
    }
}