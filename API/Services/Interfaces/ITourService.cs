using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces;

public interface ITourService
{ 
    Task<List<Tour>> GetAllToursAsync();
    
    Task<List<Tour>> GetToursBySortRateAsync();
    
    Task<ActionResult<Tour>> GetTourByIdAsync(int id);
    
    Task<List<Tour>> SearchToursAsync(string searchQuery);
}