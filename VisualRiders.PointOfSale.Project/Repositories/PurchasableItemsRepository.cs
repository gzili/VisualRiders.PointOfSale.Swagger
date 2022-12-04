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
                Status = PurchasableItemStatus.Deleted,
                ItemCategoryId =  Guid.NewGuid(),
                DiscountId = Guid.NewGuid()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Price = 2.0M,
                Name = "Purchasable Item 2",
                Description = "Description 2",
                Status = PurchasableItemStatus.Active,
                ItemCategoryId =  Guid.NewGuid(),
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
                Status = PurchasableItemStatus.Active,
                ItemCategoryId = Guid.Empty,
                DiscountId = Guid.Empty
            };

            _purchasableItems.Add(item);

            return item;
        }

        public List<PurchasableItem> GetAll()
        {
            return _purchasableItems;
        }

        public List<PurchasableItem> GetAllActive() =>  _purchasableItems.FindAll(p => p.Status == PurchasableItemStatus.Active);
        public List<PurchasableItem> GetAllDeleted() =>  _purchasableItems.FindAll(p => p.Status == PurchasableItemStatus.Deleted);

        public PurchasableItem? GetById(Guid id) => _purchasableItems.Find(p => p.Id == id);

        public void Update(PurchasableItem item, CreateUpdatePurchasableItemDto dto)
        {
            item.Price = dto.Price;
            item.Name = dto.Name;
            item.Description = dto.Description;
        }

        public void ChangeCategory(PurchasableItem item, UpdatePurchasableItemCategoryDto dto)
        {
            item.ItemCategoryId = dto.CategoryId;
        }

        public void ChangeStatus(PurchasableItem item, UpdatePurchasableItemStatusDto dto)
        {
            item.Status = dto.Status;
        }

        public void DeleteById(PurchasableItem item) => item.Status = PurchasableItemStatus.Deleted;
    }
}
