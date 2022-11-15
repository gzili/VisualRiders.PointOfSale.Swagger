using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Models;

public class Company
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string ActiveSince { get; set; }
    
    public string LegalCompanyName { get; set; }
    
    public string BillingDetails { get; set; }
    
    public CompanyStatus Status { get; set; }
}