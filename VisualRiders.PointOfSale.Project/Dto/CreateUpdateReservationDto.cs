using System.ComponentModel.DataAnnotations;
using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateReservationDto
{
    [Required]
    public DateTime StartTime { get; set; }
    
    [Required]
    public DateTime EndTime { get; set; }
    
    public ReservationStatus ReservationStatus { get; set; }
    
    [Required]
    public Guid ServiceId { get; set; }

    public Guid OrderId { get; set; }
    
    [Required]
    public Guid EmployeeId { get; set; }
}