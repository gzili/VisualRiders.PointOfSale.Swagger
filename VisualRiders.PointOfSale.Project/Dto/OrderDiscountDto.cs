using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class OrderDiscountDto
{
    public Guid Id { get; set; }
    
    public decimal Amount { get; set; }
    
    public DiscountMeasure Measure { get; set; }
}