using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VisualRiders.PointOfSale.Project.Dto;

[SwaggerSchemaFilter(typeof(CreateUpdateShiftDtoSchemaFilter))]
public class CreateUpdateShiftDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    
    [Required]
    public Guid BranchId { get; set; }
    
    [Required]
    public DateTime Begin { get; set; }
    
    [Required]
    public DateTime End { get; set; }
}

public class CreateUpdateShiftDtoSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["employeeId"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["branchId"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["begin"] = new OpenApiDateTime(new DateTimeOffset(new DateTime(2022, 12, 1, 8, 0, 0))),
            ["end"] = new OpenApiDateTime(new DateTimeOffset(new DateTime(2022, 12, 1, 15, 0, 0)))
        };
    }
}