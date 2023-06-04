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
    
    
    [HttpPost("create/tourPhoto/tourId={tourId}/uuid={uuid}")]
    public async Task<bool> AddTourPhotosByTourId(int tourId, string uuid)
    {
        return await _tourPhotos.AddTourPhotosByTourId(tourId, uuid);
    }

    [HttpPost("delete/deleteTourPhotoById/id={id}")]
    public async Task<bool> RemoveTourPhotoById(int id)
    {
        return await _tourPhotos.RemoveTourPhotoById(id);
    }

    [HttpPost("delete/deleteAllTourPhotoByTourId/tourId={tourId}")]
    public async Task<bool> RemoveAllTourPhotosByTourId(int tourId)
    {
        return await _tourPhotos.RemoveAllTourPhotosByTourId(tourId);
    }
}