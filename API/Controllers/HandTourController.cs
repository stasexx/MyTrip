using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class HandTourController:BaseApiController
{
    private readonly IHandTourService _handTourService;
    private readonly IUserService _userService;
    private readonly ITourService _tourService;
    private readonly IChatService _chatService;

    public HandTourController(IHandTourService handTourService, IUserService userService, ITourService tourService, IChatService chatService)
    {
        _handTourService = handTourService;
        _userService = userService;
        _tourService = tourService;
        _chatService = chatService;
    }
    
    [HttpGet("get/getAllHandTours")]
    public async Task<ActionResult<List<HandTour>>> GetAllHandTours()
    {
        return await _handTourService.GetAllHandTour();
    }
    
    [HttpGet("get/handTour/handTourId={id}")]
    public async Task<ActionResult<HandTour>> GetHandTourById(int id)
    {
        return await _handTourService.GetHandTourById(id);
    }
    
    [HttpGet("get/handTourByTour/tourId={id}")]
    public async Task<ActionResult<HandTour>> GetHandTourByTourId(int id)
    {
        return await _handTourService.GetHandTourByTourId(id);
    }
    
    [HttpGet("get/getAllHandToursWithTourAndUserInfo")]
    public async Task<ActionResult<List<HandTour>>> GetAllHandTourWithTourAndUserInfo()
    {
        return await _handTourService.GetAllHandTourWithTourAndUserInfo();
    }
    
    [HttpPost("create/createHandTour/name={name}/description={description}/rate={rate}/" +
             "typeOfTour={typeOfTour}/category={category}/startDate={startDate}/endDate={endDate}/destination={destination}/" +
             "placeOfDeparture={placeOfDeparture}/countOfUser={countOfUser}/mainPhoto={mainPhoto}/allPhotos={allPhotos}/" +
             "tags={tags}/budget={budget}/email={email}")]
    public async Task<HandTour> CreateHandTour(string name, string description, float rate, string typeOfTour, string category,
        DateTime startDate, DateTime endDate, string destination, string placeOfDeparture, int countOfUser, string mainPhoto,
        string allPhotos, string tags, int budget, string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        var tour = await _tourService.CreateTour(name, description, rate, typeOfTour, category, startDate, endDate,
            destination, placeOfDeparture, countOfUser, mainPhoto, allPhotos, tags);
        var chat = await _chatService.CreateChat(budget);
        return await _handTourService.CreateHandTour(tour, chat, user.Value);
    }
    
}