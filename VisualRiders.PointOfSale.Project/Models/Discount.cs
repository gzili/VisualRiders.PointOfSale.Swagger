namespace VisualRiders.PointOfSale.Project.Models
{
    public enum DiscountMeasureType
    {
        Percentage,
        Absolute
    }
    public class Discount
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }
        public Decimal Amount { get; set; }
        public DiscountMeasureType DiscountMeasure { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
