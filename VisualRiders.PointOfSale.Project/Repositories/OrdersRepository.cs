using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class OrdersRepository
{
    private readonly List<Order> _orders = Data.Orders;

    public Order Create(CreateOrderDto dto)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            SubmissionDate = DateTime.Now,
            Tip = 0,
            Comment = dto.Comment,
            Status = OrderStatus.Created,
            Items = new List<OrderItem>()
        };

        foreach (var itemDto in dto.Items)
        {
            var item = new OrderItem
            {
                PurchasableItemId = itemDto.PurchasableItemId,
                Amount = itemDto.Amount
            };
            
            order.Items.Add(item);
        }
        
        _orders.Add(order);

        return order;
    }
}