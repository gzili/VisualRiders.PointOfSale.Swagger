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

        public List<Service> GetAllActive() => _services.FindAll(s => s.Status == ServiceStatus.Active);
        public List<Service> GetAllDeleted() => _services.FindAll(s => s.Status == ServiceStatus.Deleted);

        public Service? GetById(Guid id) => _services.Find(s => s.Id == id);

        public void Update(Service service, CreateUpdateServiceDto dto)
        {
            service.Price = dto.Price;
            service.Name = dto.Name;
            service.Description = dto.Description;
        }

        public void ChangeStatus(Service service, UpdateServiceStatusDto dto) => service.Status = dto.Status;

        public void DeleteById(Service service) => service.Status = ServiceStatus.Deleted;
    }
}
