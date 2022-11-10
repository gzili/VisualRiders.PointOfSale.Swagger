using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class OrderListItemDto
{
    public Guid Id { get; set; }
    
    public DateTime SubmissionDate { get; set; }
    
    public DateTime? FulfillmentDate { get; set; }
    
    public decimal Tip { get; set; }
    
    public string Comment { get; set; }
    
    public OrderStatus Status { get; set; }
}