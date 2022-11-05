using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories
{
    public class ItemCategoriesRepository
    {
        private static List<ItemCathegory> _itemCathegories = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Cathegory 1",
                Description = "Description 1",
                DiscountId = Guid.NewGuid()

            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Cathegory 2",
                Description = "Description 1",
                DiscountId = Guid.NewGuid()
            }
        };

        public void Create(ItemCathegory cathegory)
        {
            cathegory.Id = Guid.NewGuid();

            _itemCathegories.Add(cathegory);
        }

        public List<ItemCathegory> GetAll()
        {
            return _itemCathegories;
        }

        public ItemCathegory? GetById(Guid id) => _itemCathegories.Find(p => p.Id == id);

        public void UpdateCathegory(ItemCathegory itemCathegory)
        {
            var index = _itemCathegories.FindIndex(p => p.Id == itemCathegory.Id);

            if (index != -1)
            {
                _itemCathegories[index] = itemCathegory;
            }
        }

        public void DeleteById(Guid id)
        {
            var item = _itemCathegories.Find(p => p.Id == id);

            if (item != null)
            {
                _itemCathegories.Remove(item);
            }
        }

    }
}
