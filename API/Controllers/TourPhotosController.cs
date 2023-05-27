using API.Services;
using API.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TourPhotosController:BaseApiController
{
    private readonly ITourPhotosService _tourPhotos;

    public TourPhotosController(ITourPhotosService tourPhotos)
    {
        _tourPhotos = tourPhotos;
    }
    
    [HttpGet("get/allTourPhotosById/id={id}")]
    public async Task<ActionResult<List<TourPhoto>>> GetAllTourPhotosById(int id)
    {
        return await _tourPhotos.GetTourPhotosByTourId(id);
    }
}