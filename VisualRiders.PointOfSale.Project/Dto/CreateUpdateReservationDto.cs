using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateReservationDto
{
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public ReservationStatus ReservationStatus { get; set; }
    
    public Guid ServiceId { get; set; }
    
    public Guid TaxId { get; set; }
    
    public Guid OrderId { get; set; }
    
    public Guid EmployeeId { get; set; }
}