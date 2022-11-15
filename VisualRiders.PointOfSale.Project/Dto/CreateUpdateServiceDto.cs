using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Dto
{
    public class CreateUpdateServiceDto
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ServiceType Type { get; set; }
        public ServiceStatus Status { get; set; }

    }
}
