using Domain.Models;

namespace API.Services.Interfaces;

public interface IOrgTourService
{
    Task<List<OrgTour>> GetAllOrgTour();

    Task<OrgTour> GetOrgTourById(int id);
    
    Task<List<OrgTour>> GetAllOrgTourWithTourInfo();

    Task<OrgTour> CreateOrgTour(Tour tour, User user, int experience, int price, string promocode);
}