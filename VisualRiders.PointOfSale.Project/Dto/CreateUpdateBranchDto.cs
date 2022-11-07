using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateBranchDto
{
    public string Address { get; set; }
    
    public Time WorkingHourStart { get; set; }
    
    public Time WorkingHourEnd { get; set; }
    
    public WorkingDays WorkingDays { get; set; }
    
    public string Contacts { get; set; }
    
    public BranchStatus BranchStatus { get; set; }
    
    public Guid CompanyId { get; set; }
}