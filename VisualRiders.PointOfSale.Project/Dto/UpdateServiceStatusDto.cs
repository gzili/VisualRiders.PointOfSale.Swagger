using System.ComponentModel.DataAnnotations;
using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdateServiceStatusDto
{
    [Required]
    public ServiceStatus Status { get; set; }
}