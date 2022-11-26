using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController : ControllerBase
{
    /// <summary>
    /// Creates a new transaction
    /// </summary>
    /// <param name="transaction">The transaction to be created</param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the created transaction")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation failure")]
    public ActionResult<Transaction> Create(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves all transactions
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of transactions")]
    public ActionResult<List<Transaction>> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves a transaction by ID
    /// </summary>
    /// <param name="id">The ID of the transaction</param>
    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a transaction")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Transaction with the specified ID does not exist")]
    public ActionResult<Transaction> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}