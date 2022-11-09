using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Enums;
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
                Type = ServiceType.Type2,
                Status = ServiceStatus.Deleted,
                DiscountId = Guid.NewGuid(),
                BranchId = Guid.NewGuid()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Service 2",
                Description = "Description 2",
                Price = 2.0M,
                Type = ServiceType.Type2,
                Status = ServiceStatus.Active,
                DiscountId = Guid.NewGuid(),
                BranchId = Guid.NewGuid()
            }
        };

        public Service Create(CreateUpdateServiceDto dto)
        {
            var service = new Service
            {
                Id = Guid.NewGuid(),
                Price = dto.Price,
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type,
                Status = ServiceStatus.Active,
                DiscountId= Guid.Empty,
                BranchId = Guid.Empty
            };

            _services.Add(service);

            return service;
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

        public void Update(Service service, CreateUpdateServiceDto dto)
        {
            service.Price = dto.Price;
            service.Name = dto.Name;
            service.Description = dto.Description;
            service.Type = dto.Type;
        }

        public void ChangeStatus(Service service, UpdateServiceStatusDto dto)
        {
            service.Status = dto.Status;
        }

        public void DeleteById(Guid id)
        {
            var index = _services.FindIndex(s => s.Id == id);

            if(index != -1)
            {
                _services[index].Status = Enums.ServiceStatus.Deleted;
            }
        }
    }
}
