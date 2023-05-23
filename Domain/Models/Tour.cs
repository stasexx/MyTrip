namespace Domain.Models;

public class Tour
{
    public int TourId { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }
    
    public double Rate { get; set; }
    
    public string typeOfTour { get; set; }
    
    public string Category { get; set; }
    
    public DateTime startDate { get; set; }
    
    public DateTime endDate { get; set; }
    
    public string Destination { get; set; }
    
    public string placeOfDeparture { get; set; }

    public int countOfUser { get; set; }
    
    public string mainPhoto { get; set; }
    
    public string allPhotos { get; set; }
    
    public string Tags { get; set; }

}