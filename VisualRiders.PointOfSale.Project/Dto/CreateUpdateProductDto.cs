using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateProductDto
{
    [Required]
    public string Name { get; set; }
}