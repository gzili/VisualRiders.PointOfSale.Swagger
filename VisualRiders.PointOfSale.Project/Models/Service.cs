using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Models;

public class Service
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ServiceStatus Status { get; set; }
    public Guid DiscountId { get; set; }
    public Guid BranchId { get; set; }
}