using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Models
{
    public enum EmployeeStatus
    {
        Active,
        Deleted
    }

    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EmployeeStatus Status { get; set; }
        //public Role Role { get; set; }
        //public Company Company { get; set; }
    }
}
