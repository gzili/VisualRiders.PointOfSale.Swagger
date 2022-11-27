using System.ComponentModel.DataAnnotations;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdateBranchWorkingHoursDto
{
    [Required]
    public Time WorkingHourStart { get; set; }

    [Required]
    public Time WorkingHourEnd { get; set; }
}