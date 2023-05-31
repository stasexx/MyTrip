using Domain.Models;

namespace API.Services.Interfaces;

public interface IOrgTourService
{
    Task<List<OrgTour>> GetAllOrgTour();

    Task<OrgTour> GetOrgTourById(int id);
    
    Task<OrgTour> GetOrgTourByTourId(int id);
    
    Task<List<OrgTour>> FilterForOrgTourByCategory(string category);

    Task<List<OrgTour>> FilterForOrgTourByCountry(string country);
    
    Task<List<OrgTour>> GetAllOrgTourWithTourInfo();

    Task<OrgTour> CreateOrgTour(Tour tour, User user, int experience, int price, string promocode);


    Task<bool> ChangePromocode(int id, string newPromocode);

    Task<bool> ChangePrice(int id, int newPrice);

    Task<bool> ChangeExperience(int id, int newExperience);
}