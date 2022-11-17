using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Dto
{
    public class CreateUpdatePurchasableItemDto
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public PurchasableItemType Type { get; set; }
        public PurchasableItemStatus Status { get; set; }
    }
}
