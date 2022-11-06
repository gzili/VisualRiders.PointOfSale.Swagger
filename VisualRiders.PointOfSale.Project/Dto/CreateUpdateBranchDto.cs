using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateBranchDto
{
    public string Address { get; set; }
    
    public TimeSpan WorkingHourStart { get; set; }
    
    public TimeSpan WorkingHourEnd { get; set; }
    
    public WorkingDays WorkingDays { get; set; }
    
    public string Contacts { get; set; }
    
    public BranchStatus BranchStatus { get; set; }
    
    public Guid CompanyId { get; set; }
}