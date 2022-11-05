using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories
{
    public class ServicesRepository
    {
        private static List<Service> _services = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Service 1",
                Description = "Description 1",
                Price = 1.0M,
                Type = Enums.ServiceType.Type2,
                Status = Enums.ServiceStatus.Deleted,
                DiscountId = Guid.NewGuid(),
                BranchId = Guid.NewGuid()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Service 2",
                Description = "Description 2",
                Price = 2.0M,
                Type = Enums.ServiceType.Type2,
                Status = Enums.ServiceStatus.Active,
                DiscountId = Guid.NewGuid(),
                BranchId = Guid.NewGuid()
            }
        };

        public void Create(Service service)
        {
            _services.Add(service);
        }

        public List<Service> GetAll()
        {
            return _services;
        }

        public List<Service> GetAllByStatus(int status)
        {
            return _services.FindAll(s => (int)s.Status == status);
        }

        public Service? GetById(Guid id) => _services.Find(s => s.Id == id);

        public void UpdateItem(Service service)
        {
            var index = _services.FindIndex(s => s.Id == service.Id);

            if (index != -1)
            {
                _services[index] = service;
            }
        }

        public void DeleteById(Guid id)
        {
            var item = _services.Find(p => p.Id == id);

            if (item != null)
            {
                _services.Remove(item);
            }
        }
    }
}
