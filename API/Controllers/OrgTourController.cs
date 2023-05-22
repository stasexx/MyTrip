using Domain.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrgTourController:BaseApiController
{
    private readonly IOrgTourService _orgTourService;

    public OrgTourController(IOrgTourService orgTourService)
    {
        _orgTourService = orgTourService;
    }
    
    [HttpGet("get/getAllOrgTours")]
    public async Task<ActionResult<List<OrgTour>>> GetAllOrgTours()
    {
        return await _orgTourService.GetAllOrgTour();
    }
    
    [HttpGet("get/orgTour/orgTourId={id}")]
    public async Task<ActionResult<OrgTour>> GetOrgTourById(int id)
    {
        return await _orgTourService.GetOrgTourById(id);
    }
    
    [HttpGet("get/getAllOrgToursWithTourInfo")]
    public async Task<ActionResult<List<OrgTour>>> GetAllOrgTourWithTourInfo()
    {
        return await _orgTourService.GetAllOrgTourWithTourInfo();
    }
}