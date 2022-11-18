using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Models;

public class Reservation
{
    public Guid Id { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public ReservationStatus ReservationStatus { get; set; }
    
    public Service Service { get; set; }
    
    public Guid Tax { get; set; }
    
    public Guid Order { get; set; }
    
    public Employee Employee { get; set; }
}
