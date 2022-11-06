using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories
{
    public class PurchasableItemsRepository
    {
        private static List<PurchasableItem> _purchasableItems = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Price = 1.0M,
                Name = "Purchasable Item 1",
                Description = "Description 1",
                Duration = 0,
                Type = Enums.PurchasableItemType.Type1,
                Status = Enums.PurchasableItemStatus.Deleted,
                ItemCathegoryId =  Guid.NewGuid(),
                DiscountId = Guid.NewGuid()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Price = 2.0M,
                Name = "Purchasable Item 2",
                Description = "Description 2",
                Duration = 0,
                Type = Enums.PurchasableItemType.Type2,
                Status = Enums.PurchasableItemStatus.Active,
                ItemCathegoryId =  Guid.NewGuid(),
                DiscountId = Guid.NewGuid()
            }
        };

        public void Create(PurchasableItem item)
        {
            item.Id = Guid.NewGuid();

            _purchasableItems.Add(item);
        }

        public List<PurchasableItem> GetAll()
        {
            return _purchasableItems;
        }

        public List<PurchasableItem> GetAllByStatus(int itemStatus)
        {
            return _purchasableItems.FindAll(p => (int)p.Status == itemStatus);
        }

        public PurchasableItem? GetById(Guid id) => _purchasableItems.Find(p => p.Id == id);

        public void UpdateItem(PurchasableItem purchasableItem)
        {
            var index = _purchasableItems.FindIndex(p => p.Id == purchasableItem.Id);

            if (index != -1)
            {
                _purchasableItems[index] = purchasableItem;
            }
        }

        public void AddCathegory(Guid itemId, Guid categoryId)
        {
            var item = _purchasableItems.Find(p => p.Id == itemId);


            if(item != null)
            {
                item.ItemCathegoryId = categoryId;
            }
            
        }

        public void DeleteById(Guid id)
        {
            var index = _purchasableItems.FindIndex(p => p.Id == id);

            if(index != -1)
            {
                _purchasableItems[index].Status = Enums.PurchasableItemStatus.Deleted;
            }
        }
    }
}
