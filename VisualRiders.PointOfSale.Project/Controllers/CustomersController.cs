using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/customers")]
[Produces("application/json")]
public class CustomersController : ControllerBase
{
    private readonly CustomersRepository _customersRepository;

    public CustomersController(CustomersRepository customersRepository)
    {
        _customersRepository = customersRepository;
    }

    /// <summary>
    /// Creates a customer account
    /// </summary>
    /// <param name="payload">The account details</param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public ActionResult<Customer> Create(CreateCustomerDto payload)
    {
        return _customersRepository.Create(payload);
    }

    /// <summary>
    /// Retrieves a customer profile if given valid credentials
    /// </summary>
    /// <param name="payload">The account credentials</param>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the customer profile if credentials are valid")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid payload")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid credentials")]
    public ActionResult<Customer> GetByCredentials(CustomerCredentialsDto payload) 
    {
        var customer = _customersRepository.GetByCredentials(payload);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }
}