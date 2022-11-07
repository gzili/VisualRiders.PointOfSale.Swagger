using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateCompanyDto
{
    public string Name { get; set; }
    
    public string ActiveSince { get; set; }
    
    public string LegalCompanyName { get; set; }
    
    public string BillingDetails { get; set; }
    
    public CompanyStatus CompanyStatus { get; set; }
}