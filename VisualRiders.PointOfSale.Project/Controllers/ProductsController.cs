using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsRepository _productsRepository;

    public ProductsController(ProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Product> Create(CreateUpdateProductDto dto)
    {
        var product = _productsRepository.Create(dto);
        
        return CreatedAtAction("GetById", new { id = product.Id }, product);
    }

    [HttpGet]
    public List<Product> GetAll()
    {
        return _productsRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> GetById(Guid id)
    {
        var product = _productsRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPut("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> UpdateById(Guid id, CreateUpdateProductDto dto)
    {
        var product = _productsRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }
        
        _productsRepository.Update(product, dto);

        return product;
    }

    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteById(Guid id)
    {
        var product = _productsRepository.GetById(id);
        
        if (product == null)
        {
            return NotFound();
        }
        
        _productsRepository.Remove(product);

        return Ok();
    }
}