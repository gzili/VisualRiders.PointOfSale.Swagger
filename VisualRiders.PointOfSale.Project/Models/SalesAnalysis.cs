namespace VisualRiders.PointOfSale.Project.Models;

public class SalesAnalysis
{
    public Guid Id { get; set; }
    
    public Guid Branch { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public decimal Min { get; set; }
    
    public decimal Max { get; set; }
    
    public decimal Median { get; set; }
    
    public decimal Average { get; set; }
    
    public List<decimal> TotalSold { get; set; }
}