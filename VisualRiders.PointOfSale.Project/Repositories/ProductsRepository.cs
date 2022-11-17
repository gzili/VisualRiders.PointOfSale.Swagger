using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ProductsRepository
{
    private static List<Product> _products = new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Product 1"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Product 2"
        }
    };

    public Product Create(CreateUpdateProductDto dto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        };

        _products.Add(product);

        return product;
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(Guid id) => _products.Find(p => p.Id == id);

    public void Update(Product product, CreateUpdateProductDto dto)
    {
        product.Name = dto.Name;
    }

    public void Remove(Product product)
    {
        _products.Remove(product);
    }
}