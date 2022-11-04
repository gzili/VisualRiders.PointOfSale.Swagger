using Microsoft.AspNetCore.Mvc;
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
    [ProducesResponseType(201)]
    public ActionResult<Product> Create(Product product)
    {
        _productsRepository.Create(product);
        
        return CreatedAtAction("GetById", new { id = product.Id }, product);
    }

    [HttpGet]
    public List<Product> GetAll()
    {
        return _productsRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
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
    public void UpdateById(string id) {}
    
    [HttpDelete("{id:guid}")]
    public void DeleteById(string id) {}
}