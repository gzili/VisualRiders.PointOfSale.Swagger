using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories
{
    public class DiscountsRepository
    {
        private static List<Discount> _discounts = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Amount = 10,
                Measure = DiscountMeasure.Percentage,
                Code = "Free10",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now + TimeSpan.FromDays(7)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Amount = 5,
                Measure = DiscountMeasure.Absolute,
                Code = "5Bucks",
                StartDate = DateTime.Now - TimeSpan.FromDays(3),
                EndDate = DateTime.Now + TimeSpan.FromDays(7)
            }
        };

        public void Create(Discount discount)
        {
            discount.Id = Guid.NewGuid();

            _discounts.Add(discount);
        }

        public List<Discount> GetAll()
        {
            return _discounts;
        }

        public Discount? GetById(Guid id) => _discounts.Find(p => p.Id == id);

        public void Update(Discount discount)
        {
            for (int i = 0; i < _discounts.Count; i++)
            {
                if (discount.Id != _discounts[i].Id) continue;
                _discounts[i] = discount;
            }
        }

        public void Delete(Discount discount)
        {
            _discounts.Remove(discount);
        }
    }
}
