namespace Domain.Models;

public class TourPhoto
{
    public int TourPhotoId { get; set; }
    public Tour Tour { get; set; }
    public string UUID { get; set; }
}