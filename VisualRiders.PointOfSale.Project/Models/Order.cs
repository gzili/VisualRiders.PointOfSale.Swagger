using VisualRiders.PointOfSale.Project.Dto;

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
    
    public string Comment { get; set; }
    
    public OrderStatus Status { get; set; }
    
    public OrderCustomerDto Customer { get; set; }
    
    public OrderEmployeeDto Employee { get; set; }
    
    public OrderDiscountDto Discount { get; set; }

    public List<OrderItem> Items { get; set; }
    
    public List<OrderReservationDto> Reservations { get; set; }
    
    public List<Transaction> Transactions { get; set; }
}