using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VisualRiders.PointOfSale.Project.Models;

[SwaggerSchemaFilter(typeof(PermissionSchemaFilter))]
public class Permission
{
    [SwaggerSchema(ReadOnly = true)]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; }
}

public class PermissionSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["id"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["title"] = new OpenApiString("Create products")
        };
    }
}