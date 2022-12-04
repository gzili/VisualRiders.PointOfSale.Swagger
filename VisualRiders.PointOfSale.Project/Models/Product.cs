using Swashbuckle.AspNetCore.Annotations;

namespace VisualRiders.PointOfSale.Project.Models;

[SwaggerSchema(Description = "A material or ingredient that purchasable items consist of")]
public class Product
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}