using System.ComponentModel.DataAnnotations;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateBranchDto
{
    [Required]
    public string Address { get; set; }
    
    [Required]
    public Time WorkingHourStart { get; set; }
    
    [Required]
    public Time WorkingHourEnd { get; set; }
    
    [Required]
    public WorkingDays WorkingDays { get; set; }
    
    [Required]
    public string Contacts { get; set; }
    
    public BranchStatus BranchStatus { get; set; }
    
    public Guid CompanyId { get; set; }
}