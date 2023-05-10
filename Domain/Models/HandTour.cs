using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class HandTour
{
    public int Id { get; set; }
    
    [Required]
    public Tour Tour { get; set; }
    
    [Required]
    public User User { get; set; }
    
    [Required]
    public Chat Chat { get; set; }

}