using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VisualRiders.PointOfSale.Project.Models;

public class Shift
{
    public Guid Id { get; set; }
    
    public Guid EmployeeId { get; set; }
    
    public Guid BranchId { get; set; }
    
    public DateTime Begin { get; set; }
    
    public DateTime End { get; set; }
}

public class ShiftSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["id"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["employeeId"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["branchId"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["begin"] = new OpenApiDateTime(new DateTimeOffset(new DateTime(2022, 12, 1, 8, 0, 0))),
            ["end"] = new OpenApiDateTime(new DateTimeOffset(new DateTime(2022, 12, 1, 15, 0, 0)))
        };
    }
}