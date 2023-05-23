using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Services;

public class TourServices:ITourService
{
    private readonly DataContext _context;
    
    public TourServices(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Tour>> GetAllToursAsync()
    {
        return await _context.Tours.ToListAsync();
    }
    
    public async Task<ActionResult<Tour>> GetTourByIdAsync(int id)
    {
        return await _context.Tours.FindAsync(id);
    }

    public async Task<Tour> CreateTour(string name, string description, float rate, string typeOfTour, string category,
        DateTime startDate, DateTime endDate, string destination, string placeOfDeparture, int countOfUser, string mainPhoto,
        string allPhotos, string tags)
    {
        Tour tour = new Tour()
        {
            Name = name,
            Description = description,
            Rate = rate,
            typeOfTour = typeOfTour,
            Category = category,
            startDate = startDate,
            endDate = endDate,
            Destination = description,
            placeOfDeparture = placeOfDeparture,
            countOfUser = countOfUser,
            mainPhoto = mainPhoto,
            allPhotos = allPhotos,
            Tags = tags
        };
        await _context.Tours.AddAsync(tour);
        await _context.SaveChangesAsync();
        return tour;
    }

    public async Task<Tour> ChangeName(int id, string newName)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newName !="")
            {
                tour.Name = newName;
            }

            await _context.SaveChangesAsync();
            return tour;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Tour> ChangeDescription(int id, string description)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && description !="")
            {
                tour.Description = description;
            }

            await _context.SaveChangesAsync();
            return tour;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /*public async Task<Tour> ChangeRate(int id, List<Review> reviews)
    {
        double sum = 0;
        int countOfReview = reviews.Count;
        foreach (var review in reviews)
        {
            sum += review.Rate;
        }
        
        
    }*/
    

}