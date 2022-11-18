using Swashbuckle.AspNetCore.Annotations;

namespace VisualRiders.PointOfSale.Project.Models;

public class Delivery
{
    [SwaggerSchema(ReadOnly = true)]
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public Guid DeliveryOptionId { get; set; }
}