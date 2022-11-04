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

    public void Create(Product product)
    {
        product.Id = Guid.NewGuid();
        
        _products.Add(product);
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(Guid id) => _products.Find(p => p.Id == id);
}