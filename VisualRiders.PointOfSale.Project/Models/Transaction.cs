using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VisualRiders.PointOfSale.Project.Models;

/// <summary>
/// `0` - cash, `1` - card, `2` - bank transfer
/// </summary>
public enum PaidWith
{
    Cash,
    Card,
    BankTransfer
}

[SwaggerSchemaFilter(typeof(TransactionSchemaFilter))]
public class Transaction
{
    [SwaggerSchema(ReadOnly = true)]
    public Guid Id { get; set; }
    
    [SwaggerSchema(ReadOnly = true)]
    public DateTime Date { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public PaidWith PaidWith { get; set; }

    [Required]
    public Guid OrderId { get; set; }
    
    public Guid CustomerId { get; set; }
}

public class TransactionSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["id"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["date"] = new OpenApiDateTime(DateTimeOffset.Now),
            ["amount"] = new OpenApiDouble(99.99),
            ["paidWith"] = new OpenApiInteger((int) PaidWith.Card),
            ["orderId"] = new OpenApiString(Guid.NewGuid().ToString()),
            ["customerId"] = new OpenApiString(Guid.NewGuid().ToString())
        };
    }
}