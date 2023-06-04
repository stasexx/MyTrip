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
            Destination = destination,
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

    public async Task<Tour> ChangeRate(int id, Task<List<Review>> reviews)
    {
        double sum = 0;
        int countOfReview = reviews.Result.Count;
        foreach (var review in reviews.Result)
        {
            sum += review.Rate;
        }

        var newRate = sum / countOfReview;
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        tour.Rate = newRate;
        await _context.SaveChangesAsync();
        return tour;
    }
    
    public async Task<Tour> ChangeTypeOfTour(int id, string newTypeOfTour)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newTypeOfTour !="")
            {
                tour.typeOfTour = newTypeOfTour;
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
    
    public async Task<Tour> ChangeCategory(int id, string newCategory)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newCategory !="")
            {
                tour.Category = newCategory;
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
    public async Task<Tour> ChangeDestination(int id, string newDestination)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newDestination !="")
            {
                tour.Destination = newDestination;
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
    
    public async Task<Tour> ChangePlaceOfDeparture(int id, string newPlaceOfDeparture)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newPlaceOfDeparture !="")
            {
                tour.placeOfDeparture = newPlaceOfDeparture;
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
    
    public async Task<Tour> ChangeCountOfUser(int id, int newCountOfUser)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newCountOfUser !=0)
            {
                tour.countOfUser = newCountOfUser;
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
    
    public async Task<Tour> ChangeMainPhoto(int id, string newMainPhoto)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newMainPhoto !="")
            {
                tour.mainPhoto = newMainPhoto;
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
    
    public async Task<Tour> ChangeAllPhotos(int id, string newAllPhoto)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newAllPhoto !="")
            {
                tour.Description = newAllPhoto;
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
    
    public async Task<Tour> ChangeTags(int id, string newTags)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        try
        {
            if (tour!=null && newTags !="")
            {
                tour.Description = newTags;
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
    
    public async Task<Tour> DeleteTour(int id)
    {
        var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
        if (tour!=null)
        {
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
        }

        return tour;
    }
    
    public async Task<List<Tour>> FilterForTourByCountry(string country)
    {
        return await _context.Tours.Where(t => t.Destination == country).ToListAsync();
    }
    
    public async Task<List<Tour>> FilterForTourByCategory(string category)
    {
        return await _context.Tours.Where(t => t.Category == category).ToListAsync();
    }
    
    public async Task<List<Tour>> FilterForTourByCategoryAndCategory(string country, string category)
    {
        return await _context.Tours.Where(t => t.Category == category && t.Destination==country).ToListAsync();
    }

    public async Task<List<OrgTour>> FilterForTourByPrice(double price1, double price2)
    {
        return await _context.OrgTours.Include(t=>t.Tour).Where(t => t.Price >= price1 && t.Price <= price2).ToListAsync();
    }

    public async Task<List<OrgTour>> FilterForTourByPriceAndCategory(double price1, double price2, string category)
    {
        return await _context.OrgTours.Include(t=>t.Tour).
            Where(t => t.Price >= price1 && t.Price <= price2 && t.Tour.Category==category).ToListAsync();
    }
    
    public async Task<List<OrgTour>> FilterForTourByPriceAndCountry(double price1, double price2, string country)
    {
        return await _context.OrgTours.Include(t=>t.Tour).
            Where(t => t.Price >= price1 && t.Price <= price2 && t.Tour.Destination==country).ToListAsync();
    }

    public async Task<List<OrgTour>> FilterForTourByPriceAndCountryAndCategory(double price1, double price2, string country,
        string category)
    {
        return await _context.OrgTours.Include(t=>t.Tour).
            Where(t => t.Price >= price1 && t.Price <= price2 && t.Tour.Destination==country && t.Tour.Category==category).ToListAsync();
    }

    public async Task<List<Tour>> SearchByName(string name)
    {
        return await _context.Tours.Where(t => t.Name == name).ToListAsync();
    }
}