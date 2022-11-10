using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories
{
    public class ItemCategoriesRepository
    {
        private static List<ItemCategory> _itemCategories = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Category 1",
                Description = "Description 1",
                DiscountId = Guid.NewGuid()

            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Category 2",
                Description = "Description 1",
                DiscountId = Guid.NewGuid()
            }
        };

        public void Create(ItemCategory category)
        {
            category.Id = Guid.NewGuid();

            _itemCategories.Add(category);
        }

        public List<ItemCategory> GetAll()
        {
            return _itemCategories;
        }

        public ItemCategory? GetById(Guid id) => _itemCategories.Find(p => p.Id == id);

        public void UpdateCategory(ItemCategory itemCategory)
        {
            var index = _itemCategories.FindIndex(p => p.Id == itemCategory.Id);

            if (index != -1)
            {
                _itemCategories[index] = itemCategory;
            }
        }

        public void DeleteById(Guid id)
        {
            var item = _itemCategories.Find(p => p.Id == id);

            if (item != null)
            {
                _itemCategories.Remove(item);
            }
        }

    }
}
