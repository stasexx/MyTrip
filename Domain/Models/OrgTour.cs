using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class OrgTour
{
    public int Id { get; set; }
    
    public int Price { get; set; }
    
    public int Experience { get; set; }

    public string Promocode { get; set; }
    
    [Required]
    public Tour Tour { get; set; }
    
}