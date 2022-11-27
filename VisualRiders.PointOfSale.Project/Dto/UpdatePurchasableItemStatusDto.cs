using System.ComponentModel.DataAnnotations;
using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdatePurchasableItemStatusDto
{
    [Required]
    public PurchasableItemStatus Status { get; set; }  
}