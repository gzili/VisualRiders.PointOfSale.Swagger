using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdateBranchWorkingHoursDto
{
    public Time WorkingHourStart { get; set; }

    public Time WorkingHourEnd { get; set; }
}