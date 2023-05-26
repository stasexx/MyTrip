using Domain.Models;

namespace API.Services.Interfaces;

public interface IOrgTourService
{
    Task<List<OrgTour>> GetAllOrgTour();

    Task<OrgTour> GetOrgTourById(int id);
    
    Task<List<OrgTour>> GetAllOrgTourWithTourInfo();
}