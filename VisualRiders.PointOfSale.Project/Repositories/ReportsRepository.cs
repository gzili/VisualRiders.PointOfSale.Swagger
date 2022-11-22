using VisualRiders.PointOfSale.Project.Controllers;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ReportsRepository
{

    private readonly OrdersRepository _ordersRepository;
    private readonly CustomersRepository _customersRepository;

    private readonly List<Receipt> _receipts = Data.Receipts;

    public ReportsRepository(OrdersRepository ordersRepository, CustomersRepository customersRepository)
    {
        _ordersRepository = ordersRepository;
        _customersRepository = customersRepository;
    }

    public List<Receipt> GetByCustomer()
    {
        return _receipts;
    }

    public SalesAnalysis GetSalesAnalysis()
    {
        var rand = new Random();
        var sales = new List<decimal>();
        for (var i = 0; i < 31; i++)
        {
            sales.Add(new decimal(rand.NextDouble()) % 30000 + 1000);
        }
        sales.Sort();
        
        var totalSum = new decimal(0);
        var min = new decimal(Double.MaxValue);
        var max = new decimal(Double.MinValue);
        for (var i = 0; i < 31; i++)
        {
            min = Math.Min(min, sales[i]);
            max = Math.Max(max, sales[i]);
            totalSum += sales[i];
        }
        var average = totalSum / new decimal(sales.Count);
        var analysis = new SalesAnalysis()
        {
            Id = Guid.NewGuid(),
            Average = average,
            Branch = new Guid(),
            Max = max,
            Median = sales[sales.Count / 2],
            Min = min,
            TotalAmount = totalSum,
            TotalSold = sales
        };
        return analysis;
    }
}