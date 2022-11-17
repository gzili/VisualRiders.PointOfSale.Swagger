using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public EmployeeStatus Status { get; set; }
    public Role Role { get; set; }
    public Company Company { get; set; }
}