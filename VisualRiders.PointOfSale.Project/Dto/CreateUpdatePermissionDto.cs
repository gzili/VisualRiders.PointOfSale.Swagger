using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VisualRiders.PointOfSale.Project.Dto;

[SwaggerSchemaFilter(typeof(CreateUpdatePermissionDtoSchemaFilter))]
public class CreateUpdatePermissionDto
{
    [Required]
    public string Title { get; set; }
}

public class CreateUpdatePermissionDtoSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["title"] = new OpenApiString("Create products")
        };
    }
}