using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Models;

public class Branch
{
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public Time WorkingHourStart { get; set; }
    
    public Time WorkingHourEnd { get; set; }
    
    public WorkingDays WorkingDays { get; set; }
    
    public string Contacts { get; set; }
    
    public BranchStatus Status { get; set; }
    
    public Company Company { get; set; }
}