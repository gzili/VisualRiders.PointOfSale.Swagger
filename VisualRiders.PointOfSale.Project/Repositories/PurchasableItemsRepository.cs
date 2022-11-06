using VisualRiders.PointOfSale.Project.Dto;
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
                Type = PurchasableItemType.Type1,
                Status = PurchasableItemStatus.Deleted,
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
                Type = PurchasableItemType.Type2,
                Status = PurchasableItemStatus.Active,
                ItemCathegoryId =  Guid.NewGuid(),
                DiscountId = Guid.NewGuid()
            }
        };

        public PurchasableItem Create(CreateUpdatePurchasableItemDto dto)
        {
            var item = new PurchasableItem
            {
                Id = Guid.NewGuid(),
                Price = dto.Price,
                Name = dto.Name,
                Description = dto.Description,
                Duration = dto.Duration,
                Type = dto.Type,
                Status = PurchasableItemStatus.Active,
                ItemCathegoryId = Guid.Empty,
                DiscountId = Guid.Empty
            };

            _purchasableItems.Add(item);

            return item;
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

        public void Update(PurchasableItem item, CreateUpdatePurchasableItemDto dto)
        {
            item.Price = dto.Price;
            item.Name = dto.Name;
            item.Description = dto.Description;
            item.Duration = dto.Duration;
            item.Type = dto.Type;
        }

        public void ChangeCategory(PurchasableItem item, UpdatePurchasableItemCategoryDto dto)
        {
            item.ItemCathegoryId = dto.CategoryId;
        }

        public void ChangeStatus(PurchasableItem item, UpdatePurchasableItemStatusDto dto)
        {
            item.Status = dto.Status;
        }

        public void DeleteById(Guid id)
        {
            var index = _purchasableItems.FindIndex(p => p.Id == id);

            if(index != -1)
            {
                _purchasableItems[index].Status = PurchasableItemStatus.Deleted;
            }
        }
    }
}
