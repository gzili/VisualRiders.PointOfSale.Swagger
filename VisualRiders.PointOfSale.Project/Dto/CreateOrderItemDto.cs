using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateOrderItemDto
{
    [Required]
    public Guid PurchasableItemId { get; set; }
    
    [Required]
    public int Amount { get; set; }
}