using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Models;

public enum EmployeeStatus
{
    Active,
    Deleted
}

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public EmployeeStatus Status { get; set; }
    public Guid RoleId { get; set; }
    public Guid CompanyId { get; set; }
}