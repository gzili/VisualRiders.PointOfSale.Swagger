using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdatePurchasableItemDto
{
    [Required]
    public decimal Price { get; set; }
        
    [Required]
    public string Name { get; set; }
        
    [Required]
    public string Description { get; set; }
}