namespace VisualRiders.PointOfSale.Project.Models;

public enum OrderStatus
{
    Created,
    Returned,
    Completed,
    Cancelled
}

public class Order
{
    public Guid Id { get; set; }
    
    public DateTime SubmissionDate { get; set; }
    
    public DateTime? FulfillmentDate { get; set; }
    
    public decimal Tip { get; set; }
    
    // public bool RequiresDelivery { get; set; }
    
    public string Comment { get; set; }
    
    public OrderStatus Status { get; set; }
    
    public object? Customer { get; set; }
    
    public object? Employee { get; set; }
    
    public object? Discount { get; set; }
    
    public object? Delivery { get; set; }
    
    public List<OrderItem> Items { get; set; }
}