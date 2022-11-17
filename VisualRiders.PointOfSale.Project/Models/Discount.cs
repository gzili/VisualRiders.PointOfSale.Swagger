namespace VisualRiders.PointOfSale.Project.Models
{
    public enum DiscountMeasure
    {
        Percentage,
        Absolute
    }

    public class Discount
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DiscountMeasure Measure { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
